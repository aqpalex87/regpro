using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Regpro.Api.Responses;
using Regpro.Core.CustomEntities;
using Regpro.Core.DTOs;
using Regpro.Core.DTOs.TblRegproPrograma;
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
    public class TblRegproProgramaController : ControllerBase
    {
        private readonly ITblRegproProgramaService _tblRegproProgramaService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public TblRegproProgramaController(ITblRegproProgramaService tblRegproProgramaService, IMapper mapper, IUriService uriService)
        {
            
            _tblRegproProgramaService = tblRegproProgramaService;         
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Obtiene un Programa por Id
        /// </summary>
        /// <returns></returns> 

        [HttpGet("{nIdPrograma}")]
        public async Task<IActionResult> GetProgramaById(long nIdPrograma)
        {
            var programa = await _tblRegproProgramaService.GetProgramaById(nIdPrograma);
            var programaDto = _mapper.Map<TblRegproProgramaDto>(programa);
            var response = new ApiResponse<TblRegproProgramaDto>(programaDto);
            return Ok(response);
        }
        /// <summary>
        /// Inserta un nuevo Programa
        /// </summary>
        /// <returns></returns> 

        [HttpPost]
        public async Task<IActionResult> InsertPrograma([FromBody]TblRegproProgramaDto programaDto)
        {
            var programa = _mapper.Map<TblRegproPrograma>(programaDto);

            await _tblRegproProgramaService.InsertPrograma(programa);
            programaDto = _mapper.Map<TblRegproProgramaDto>(programa);
            var response = new ApiResponse<TblRegproProgramaDto>(programaDto);
            return Ok(response);
        }

        /// <summary>
        /// Obtiene un Programa por Codigo Modular
        /// </summary>
        /// <returns></returns> 

        [HttpGet("GetProgramaByCodigoModular/{cCodMod}/{Codooii}")]
        public async Task<IActionResult> GetProgramaByCcodMod(string cCodMod, string Codooii)
        {
            var programaccod = await _tblRegproProgramaService.GetProgramaByCcodMod(cCodMod, Codooii);
            var programaDto = _mapper.Map<TblRegproProgramaDto>(programaccod);
            var response = new ApiResponse<TblRegproProgramaDto>(programaDto);
            return Ok(response);
        }

        /// <summary>
        /// Actualiza una programa 
        /// </summary>
        /// <returns></returns> 

        [HttpPut("{NIdPrograma}")]
        public async Task<IActionResult> Put(long NIdPrograma, [FromBody]TblRegproProgramaDto provinciaDto)
        {
            var programa = _mapper.Map<TblRegproPrograma>(provinciaDto);
            programa.NIdPrograma = NIdPrograma;

            var result = await _tblRegproProgramaService.UpdatePrograma(programa);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        /// <summary>
        /// Obtiene un Programa para centro poblado mas cercano
        /// </summary>
        /// <returns></returns> 

        [HttpGet("GetCenterEducationalNear/{cCodMod}/{CodUgel}")]
        public async Task<IActionResult> GetCenterEducationalNear(string cCodMod, string CodUgel)
        {
            var programaccod = await _tblRegproProgramaService.GetCenterEducationalNear(cCodMod, CodUgel);
            var programaDto = _mapper.Map<CenterEducationalNearSelectDto>(programaccod);
            var response = new ApiResponse<CenterEducationalNearSelectDto>(programaDto);
            return Ok(response);
        }

    }
}