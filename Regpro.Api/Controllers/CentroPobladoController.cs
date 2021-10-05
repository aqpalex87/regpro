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
    public class CentroPobladoController : ControllerBase
    {
        private readonly ICentroPobladoService _centroPobladoService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public CentroPobladoController(ICentroPobladoService centroPobladoService, IMapper mapper, IUriService uriService)
        {
            _centroPobladoService = centroPobladoService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Obtiene todos los centros poblados
        /// </summary>
        /// <returns></returns> 
        [HttpGet("GetAllCentrosPoblado/{ubigeo}/{codUgel}")]
        public IActionResult GetCentroPoblado(string ubigeo, string codUgel)
        {
            var centroPoblado =  _centroPobladoService.GetAllCentrosPoblado(ubigeo);

            return Ok(centroPoblado);
        }
   

    }
}