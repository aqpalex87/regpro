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
    public class TblRegproDocumentoService : ITblRegproDocumentoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public TblRegproDocumentoService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        public async Task<TblRegproDocumento> GetAllDocumentoById(long NIdDocumento)
        {
            return await _unitOfWork.TblRegproDocumentoRepository.GetAllDocumentoById(NIdDocumento);
        }

        public async Task InsertDocumento(TblRegproDocumento documento)
        {
            documento.DFeccre = DateTime.Now;
            await _unitOfWork.TblRegproDocumentoRepository.Add(documento);
            await _unitOfWork.SaveChangesAsync();
        }


    }
}
