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
    public class TblRegproDocumentoController : ControllerBase
    {
        private readonly ITblRegproDocumentoService _tblRegproDocumentoService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public TblRegproDocumentoController(ITblRegproDocumentoService tblRegproDocumentoService, IMapper mapper, IUriService uriService)
        {
            _tblRegproDocumentoService = tblRegproDocumentoService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Inserta un nuevo documento
        /// </summary>
        /// <returns></returns> 

        [HttpPost]
        public async Task<IActionResult> Documento([FromBody]TblRegproDocumentoDto documentoDto)
        {
            var documento = _mapper.Map<TblRegproDocumento>(documentoDto);

            await _tblRegproDocumentoService.InsertDocumento(documento);

            documentoDto = _mapper.Map<TblRegproDocumentoDto>(documento);

            var response = new ApiResponse<TblRegproDocumentoDto>(documentoDto);
            return Ok(response);
        }

        /// <summary>
        /// Obtiene todos un documento por Id
        /// </summary>
        /// <returns></returns> 

        [HttpGet("GetAllDocumento/{NIdDocumento}")]
        public async Task<IActionResult> GetAllDocumento(long NIdDocumento)
        {
            var documento = await _tblRegproDocumentoService.GetAllDocumentoById(NIdDocumento);
            var documentoDto = _mapper.Map<TblRegproDocumentoDto>(documento);
            var response = new ApiResponse<TblRegproDocumentoDto>(documentoDto);
            return Ok(response);
        }


    }
}