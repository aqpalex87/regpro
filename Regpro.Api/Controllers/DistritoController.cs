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
    public class DistritoController : ControllerBase
    {
        private readonly IDistritoService _distritoService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public DistritoController(IDistritoService distritoService, IMapper mapper, IUriService uriService)
        {
            _distritoService = distritoService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Obtiene todos los distritos por Codigo Ugel
        /// </summary>
        /// <returns></returns>                 
        
        [HttpGet("GetDistritoByIdProvincia/{CodUgel}/{IdProvincia}")]

        public async Task<IActionResult> GetDistritoByIdProvincia (string CodUgel,string IdProvincia)
        {
            var distrito = await _distritoService.GetDistritoByCodUgel(CodUgel, IdProvincia);
            var distritoDto = _mapper.Map<IEnumerable<DistritoDto>>(distrito);
            var response = new ApiResponse<IEnumerable<DistritoDto>>(distritoDto);
            return Ok(response);
        }

    }
}