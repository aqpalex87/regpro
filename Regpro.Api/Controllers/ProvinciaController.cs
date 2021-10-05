using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Regpro.Api.Responses;
using Regpro.Core.CustomEntities;
using Regpro.Core.DTOs;
using Regpro.Core.Entities;
using Regpro.Core.Interfaces;
using Regpro.Core.QueryFilters;
using Regpro.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Regpro.Api.Controllers
{
    [Authorize]
    //[AllowAnonymous]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciaController : ControllerBase
    {
        private readonly IProvinciaService _provinciaService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public ProvinciaController(IProvinciaService provinciaService, IMapper mapper, IUriService uriService)
        {
            _provinciaService = provinciaService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Obtiene todas Provincias paginado
        /// </summary>
        /// <returns></returns> 
        [HttpGet(Name = nameof(GetProvincias))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ProvinciaDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetProvincias([FromQuery]ProvinciaQueryFilter filters)
        {
            var provincias = _provinciaService.GetProvincias(filters);
            var provinciasDtos = _mapper.Map<IEnumerable<ProvinciaDto>>(provincias);

            var metadata = new Metadata
            {
                TotalCount = provincias.TotalCount,
                PageSize = provincias.PageSize,
                CurrentPage = provincias.CurrentPage,
                TotalPages = provincias.TotalPages,
                HasNextPage = provincias.HasNextPage,
                HasPreviousPage = provincias.HasPreviousPage,
                //NextPageUrl = _uriService.GetProvinciaPaginationUri(filters, Url.RouteUrl(nameof(GetProvincias))).ToString(),
                //PreviousPageUrl = _uriService.GetProvinciaPaginationUri(filters, Url.RouteUrl(nameof(GetProvincias))).ToString()
            };

            var response = new ApiResponse<IEnumerable<ProvinciaDto>>(provinciasDtos)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(response);
        }
        /// <summary>
        /// Obtiene una Provincia por Id
        /// </summary>
        /// <returns></returns> 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProvincia(string id)
        {
            var provincia = await _provinciaService.GetProvincia(id);
            var provinciaDto = _mapper.Map<ProvinciaDto>(provincia);
            var response = new ApiResponse<ProvinciaDto>(provinciaDto);
            return Ok(response);
        }
        /// <summary>
        /// Inserta una provincia nueva
        /// </summary>
        /// <returns></returns> 

        [HttpPost]
        public async Task<IActionResult> Provincia(ProvinciaDto provinciaDto)
        {
            var provincia = _mapper.Map<Provincia>(provinciaDto);

            await _provinciaService.InsertProvincia(provincia);

            provinciaDto = _mapper.Map<ProvinciaDto>(provincia);
            var response = new ApiResponse<ProvinciaDto>(provinciaDto);
            return Ok(response);
        }
        /// <summary>
        /// Actualiza una provincia 
        /// </summary>
        /// <returns></returns> 

        [HttpPut]
        public async Task<IActionResult> Put(string IdProvincia, ProvinciaDto provinciaDto)
        {
            var provincia = _mapper.Map<Provincia>(provinciaDto);
            provincia.IdProvincia = IdProvincia;

            var result = await _provinciaService.UpdateProvincia(provincia);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        /// <summary>
        /// Elimina una provincia 
        /// </summary>
        /// <returns></returns> 

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _provinciaService.DeleteProvincia(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
        /// <summary>
        /// Obtiene todas las Provincias por Codigo Ugel
        /// </summary>
        /// <returns></returns> 
        [HttpGet("GetProvinciaByCodUgel/{CodUgel}/{IdProvincia}")]
        public async Task<IActionResult> GetProvinciaByCodUgel(string CodUgel, string IdProvincia)
        {
            var provincia = await _provinciaService.GetProvinciaByCodUgel(CodUgel, IdProvincia);
            var provinciaDto = _mapper.Map<IEnumerable<ProvinciaDto>>(provincia);
            var response = new ApiResponse<IEnumerable<ProvinciaDto>>(provinciaDto);
            return Ok(response);
        }

    }
}