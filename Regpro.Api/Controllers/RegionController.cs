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
    public class RegionController : ControllerBase
    {
        private readonly IRegionService _regionService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public RegionController(IRegionService regionService, IMapper mapper, IUriService uriService)
        {
            _regionService = regionService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// obtiene todas las Regiones por codigoUgel
        /// </summary>
        /// <returns></returns>
       
        [HttpGet("GetAllRegionByCodUgel/{codUgel}")]
        public async Task<IActionResult> GetAllRegionByCodUgel(string codUgel)
        {
            var region = await _regionService.GetAllRegionByCodUgel(codUgel);
            var regionDto = _mapper.Map<IEnumerable<RegionDto> >(region);
            var response = new ApiResponse<IEnumerable<RegionDto>>(regionDto);
            return Ok(response);
        }
             


      

    }
}