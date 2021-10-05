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
    public class TblRegproMaestroController : ControllerBase
    {
        private readonly ITblRegproMaestroService _tblRegproMaestroService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public TblRegproMaestroController(ITblRegproMaestroService tblRegproMaestroService, IMapper mapper, IUriService uriService)
        {
            _tblRegproMaestroService = tblRegproMaestroService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Obtiene todas los Maestros por codigo Grupo
        /// </summary>
        /// <returns></returns> 

        [HttpGet("GetAllByCodGrop/{CCodgrup}")]
        public async Task<IActionResult> GetAllByCodGrop(string CCodgrup)
        {
            var ccodgrup = await _tblRegproMaestroService.GetAllByCodGrop(CCodgrup);
            var ccodgrupDto = _mapper.Map<IEnumerable<TblRegproMaestroDto>>(ccodgrup);
            var response = new ApiResponse<IEnumerable<TblRegproMaestroDto>>(ccodgrupDto);
            return Ok(response);
        }

        /// <summary>
        /// Obtiene todas los Maestros por codigo Grupo
        /// </summary>
        /// <returns></returns> 

        [HttpGet("GetAllByCodGropAndIdMaestropadre/{CCodgrup}/{NIdMaestropadre}")]
        public async Task<IActionResult> GetAllByCodGropAndIdMaestropadre(string CCodgrup, long NIdMaestropadre)
        {
            var ccodgrup = await _tblRegproMaestroService.GetAllByCodGropAndIdMaestropadre(CCodgrup, NIdMaestropadre);
            var ccodgrupDto = _mapper.Map<IEnumerable<TblRegproMaestroDto>>(ccodgrup);
            var response = new ApiResponse<IEnumerable<TblRegproMaestroDto>>(ccodgrupDto);
            return Ok(response);
        }

        ///// <summary>
        ///// Obtiene todas los Maestros por Estado
        ///// </summary>
        ///// <returns></returns> 
        //[HttpGet("GetAllByCodGropWithOutState/{CEstado}")]
        //public async Task<IActionResult> GetAllByCodGropWithOutState(string CEstado)
        //{
        //    var cestado = await _tblRegproMaestroService.GetAllByCodGropWithOutState(CEstado);
        //    var cestadoDto = _mapper.Map<IEnumerable<TblRegproMaestroDto>>(cestado);
        //    var response = new ApiResponse<IEnumerable<TblRegproMaestroDto>>(cestadoDto);
        //    return Ok(response);
        //}
        ///// <summary>
        ///// Obtiene todas los Maestros por IdMaestroPadre
        ///// </summary>
        ///// <returns></returns> 
        //[HttpGet("GetAllByMaestroPadre/{NIdMaestropadre}")]
        //public async Task<IActionResult> GetAllByMaestroPadre(long NIdMaestropadre)
        //{
        //    var nidmaestropadre = await _tblRegproMaestroService.GetAllByMaestroPadre(NIdMaestropadre);
        //    var nidmaestropadreDtos = _mapper.Map<IEnumerable<TblRegproMaestroDto>>(nidmaestropadre);
        //    var response = new ApiResponse<IEnumerable<TblRegproMaestroDto>>(nidmaestropadreDtos);
        //    return Ok(response);
        //}

        ///// <summary>
        ///// Obtiene todos los maestros filtrados por CGrop y Estado (SI EL VALOR ES "ALL" TRAE TODOS)
        ///// </summary>
        ///// <returns></returns> 
        //[HttpGet("GetMaestroByCodGropAndEstado/{CCodgrup}/{CEstado}")]
        //public async Task<IActionResult> GetMaestroByCodGropAndEstado(string CCodgrup,string CEstado)
        //{
        //    var nidmaestropadre = await _tblRegproMaestroService.GetMaestroByCodGropAndEstado(CCodgrup, CEstado);
        //    var nidmaestropadreDtos = _mapper.Map<IEnumerable<TblRegproMaestroDto>>(nidmaestropadre);
        //    var response = new ApiResponse<IEnumerable<TblRegproMaestroDto>>(nidmaestropadreDtos);
        //    return Ok(nidmaestropadre);
        //}
    }
}