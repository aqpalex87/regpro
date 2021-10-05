using Regpro.Core.Entities;
using Regpro.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Regpro.Core.Services
{
    public class DetRegproSolDocService : IDetRegproSolDocService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DetRegproSolDocService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<DetRegproSolDoc>> GetDetRegproSolDocByIdDocumentoIdSolicitud(long NIdDocumento, long NIdSolicitud)
        {
            return await _unitOfWork.DetRegproSolDocRepository.GetDetRegproSolDocByIdDocumentoIdSolicitud(NIdDocumento, NIdSolicitud);
        }

        public async Task InsertDetRegproSolDoc(DetRegproSolDoc detRegproSolDoc)
        {

            await _unitOfWork.DetRegproSolDocRepository.Add(detRegproSolDoc);
            await _unitOfWork.SaveChangesAsync();
        }

    }
}
