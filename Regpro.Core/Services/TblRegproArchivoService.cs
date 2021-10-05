using Microsoft.Extensions.Options;
using Regpro.Core.CustomEntities;
using Regpro.Core.Entities;
using Regpro.Core.Exceptions;
using Regpro.Core.Interfaces;
using Regpro.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Regpro.Core.Services
{
    public class TblRegproArchivoService : ITblRegproArchivoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public TblRegproArchivoService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }
        public async Task<IEnumerable<TblRegproArchivo>> GetAllArchivo()
        {
            return await _unitOfWork.TblRegproArchivoRepository.GetAllArchivo();

        }

        public async Task<TblRegproArchivo> GetArchivoById(long NIdArchivo)
        {
            return await _unitOfWork.TblRegproArchivoRepository.GetArchivoById(NIdArchivo);
        }

        public async Task InsertArchivo(TblRegproArchivo archivo)
        {
            archivo.DFeccre = DateTime.Now;
            await _unitOfWork.TblRegproArchivoRepository.Add(archivo);
            await _unitOfWork.SaveChangesAsync();
        }
 
    }
}
