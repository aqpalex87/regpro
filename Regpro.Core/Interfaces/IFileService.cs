using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace Regpro.Core.Interfaces
{
   public interface IFileService
    {
        Task<bool> UploadFile(IFormFile file, string FileName);
        (string fileType, byte[] archiveData, string archiveName) DownloadFiles();
        string SizeConverter(long bytes);
    }
}
