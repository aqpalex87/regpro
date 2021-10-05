using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Regpro.Api.Responses;
using Regpro.Core.CustomEntities;
using Regpro.Core.DTOs;
using Regpro.Core.Entities;
using Regpro.Core.Interfaces;
using Regpro.Core.QueryFilters;
using Regpro.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Regpro.Api.Controllers
{
    [Authorize]
    //[AllowAnonymous]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TblRegproSolicitudController : ControllerBase
    {
        private readonly ITblRegproSolicitudService _tblRegproSolicitudService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public TblRegproSolicitudController(ITblRegproSolicitudService tblRegproSolicitudService, IMapper mapper, IUriService uriService)
        {
            _tblRegproSolicitudService = tblRegproSolicitudService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Obtiene una solicitud por IdSolicitud
        /// </summary>
        /// <returns></returns> 

        [HttpGet("GetFindRequest/{NIdSolicitud}")]
        public async Task<IActionResult> GetFindRequest(long NIdSolicitud)
        {
            var nidsolicitud = await _tblRegproSolicitudService.GetFindRequest(NIdSolicitud);
            var nidsolicitudDto = _mapper.Map<TblRegproSolicitudSelectDto>(nidsolicitud);
            var response = new ApiResponse<TblRegproSolicitudSelectDto>(nidsolicitudDto);
            return Ok(response);
        }


        //[HttpPost]
        //public async Task<IActionResult> Solicitud([FromBody] TblRegproSolicitudCreateDto solicitudDto)
        //{
        //    IFormFile croquis = Request.Form.Files[0];
        //    if (croquis == null)
        //    {
        //        return BadRequest();
        //    }
        //    IFormFile file1 = Request.Form.Files[0];
        //    IFormFile file2 = Request.Form.Files[0];
        //    IFormFile file3 = Request.Form.Files[0];
        //    IFormFile file4 = Request.Form.Files[0];
        //    IFormFile file5 = Request.Form.Files[0];


        //    List<IFormFile> archivos = new List<IFormFile>();
        //    archivos.Add(file1);
        //    archivos.Add(file2);
        //    archivos.Add(file3);
        //    archivos.Add(file4);
        //    archivos.Add(file5);

        //    var solicitud = _mapper.Map<TblRegproSolicitud>(solicitudDto);
        //    await _tblRegproSolicitudService.InsertSolicitud(solicitud, archivos, croquis);
        //    solicitudDto = _mapper.Map<TblRegproSolicitudCreateDto>(solicitud);
        //    var response = new ApiResponse<TblRegproSolicitudCreateDto>(solicitudDto);
        //    return Ok(response);
        //}

        [HttpPost]
        public async Task<IActionResult> Solicitud([FromForm] TblRegproSolicitudCreateDto solicitudDto)
        {
            List<IFormFile> archivos = new List<IFormFile>();
            archivos.Add(solicitudDto.file1);
            archivos.Add(solicitudDto.file2);
            archivos.Add(solicitudDto.file3);
            archivos.Add(solicitudDto.file4);
            archivos.Add(solicitudDto.file5);

            var solicitud = _mapper.Map<TblRegproSolicitud>(solicitudDto);
            await _tblRegproSolicitudService.InsertSolicitud(solicitud, archivos, solicitudDto.croquis);
            solicitudDto = _mapper.Map<TblRegproSolicitudCreateDto>(solicitud);
            var response = new ApiResponse<TblRegproSolicitudCreateDto>(solicitudDto);
            return Ok(response);
        }


    }
}