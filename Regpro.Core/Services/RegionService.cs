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
    public class RegionService : IRegionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public RegionService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }
     
               
        public async Task<IEnumerable<Regione>> GetAllRegionByCodUgel(string codUgel)
        {
            if (string.IsNullOrEmpty(codUgel))
            {
                throw new BusinessException("codUgel no puede ser nullo o vacio");
            }

            if (codUgel.Length == 5)
            {
                throw new BusinessException("codUgel tiene que tener 6 digitos");
            }

            var result = new List<Regione>();

            var geos = await _unitOfWork.DreGeoRepository.GetAllDreGeoByCodUgel(codUgel);

            foreach (var item in geos)
            {
                var region = await _unitOfWork.RegionRepository.GetRegionById(item.IdDistrito.Substring(0,2));
                result.Add(region);
            }

            return result.Distinct().ToList();
        }
    }
}
