using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Regpro.Core.Interfaces;

namespace Regpro.Api.Controllers
{
    [Authorize]
    //[AllowAnonymous]
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class FilesController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly ILogger<FilesController> _logger;


        public FilesController(ILogger<FilesController> logger, IFileService fileService)
        {
            _logger = logger;
            _fileService = fileService;
        }

        /// <summary>
        /// Upload five files.
        /// </summary>
        /// <param name="file1"></param>
        /// <param name="file2"></param>
        /// <param name="file3"></param>
        /// <param name="file4"></param>
        /// <param name="file5"></param>
        /// <returns></returns>
        [HttpPost("five-files")]
        public async Task Upload(IFormFile file1, IFormFile file2, IFormFile file3, IFormFile file4, IFormFile file5)
        {

                List<IFormFile> archivos = new List<IFormFile>();
                archivos.Add(file1);
                archivos.Add(file2);
                archivos.Add(file3);
                archivos.Add(file4);
                archivos.Add(file5);
                foreach (var item in archivos ?? Enumerable.Empty<IFormFile>())
                {
                    if (item!=null) {
                       await _fileService.UploadFile(item, item.FileName);
                    }
          
                }
               

        }

        [HttpGet(nameof(Download))]
        public IActionResult Download()
        {

            try
            {
                var (fileType, archiveData, archiveName) = _fileService.DownloadFiles();

                return File(archiveData, fileType, archiveName);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
