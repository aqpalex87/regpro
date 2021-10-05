using Regpro.Core.Entities;
using Regpro.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Regpro.Core.Services
{
    public class DreGeoService : IDreGeoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DreGeoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<DreGeo>> GetAllDreGeo()
        {
            return await _unitOfWork.DreGeoRepository.GetAllDreGeo();
        }
    }
}
