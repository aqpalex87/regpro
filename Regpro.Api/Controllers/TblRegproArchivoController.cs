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
    public class TblRegproArchivoController : ControllerBase
    {
        private readonly ITblRegproArchivoService _tblRegproArchivoService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public TblRegproArchivoController(ITblRegproArchivoService tblRegproArchivoService, IMapper mapper, IUriService uriService)
        {
            _tblRegproArchivoService = tblRegproArchivoService;
            _mapper = mapper;
            _uriService = uriService;
        }
        /// <summary>
        /// Inserta un archivo nuevo 
        /// </summary>
        /// <returns></returns> 

        [HttpPost]
        public async Task<IActionResult> Provincia([FromBody]TblRegproArchivoDto archivoDto)
        {
            var archivo = _mapper.Map<TblRegproArchivo>(archivoDto);
            await _tblRegproArchivoService.InsertArchivo(archivo);
            archivoDto = _mapper.Map<TblRegproArchivoDto>(archivo);
            var response = new ApiResponse<TblRegproArchivoDto>(archivoDto);
            return Ok(response);
        }

        /// <summary>
        /// Get Archivo por Id
        /// </summary>
        /// <returns></returns> 

        [HttpGet("GetArchivoById/{NIdArchivo}")]
        public async Task<IActionResult> GetArchivoById(long NIdArchivo)
        {
            var archivo = await _tblRegproArchivoService.GetArchivoById(NIdArchivo);
            var archivoDto = _mapper.Map<TblRegproArchivo>(archivo);
            var response = new ApiResponse<TblRegproArchivo>(archivoDto);
            return Ok(response);
        }

    }
}