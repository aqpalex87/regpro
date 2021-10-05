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
    public class DistritoService : IDistritoService 
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public DistritoService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }
        public async Task<IEnumerable<Distrito>> GetAllDistrito()
        {
            return await _unitOfWork.DistritoRepository.GetAllDistrito();
        }
        public async Task<IEnumerable<Distrito>> GetDistritoByCodUgel(string codUgel, string IdProvincial)
        {
            if (string.IsNullOrEmpty(codUgel))
            {
                throw new BusinessException("codUgel no puede ser nullo o vacio");
            }

            if (string.IsNullOrEmpty(IdProvincial))
            {
                throw new BusinessException("IdProvincial no puede ser nullo o vacio");
            }

            if (codUgel.Length == 5)
            {
                throw new BusinessException("codUgel tiene que tener 6 digitos");
            }

            var provincia = await _unitOfWork.ProvinciaRepository.GetProvinciaById(IdProvincial);

            if (provincia == null)
            {
                throw new BusinessException("Provincia no existe");
            }

            var result = new List<Distrito>();

            var geos = await _unitOfWork.DreGeoRepository.GetAllDreGeoByCodUgel(codUgel);

            foreach (var item in geos)
            {
                var region = await _unitOfWork.DistritoRepository.GetDistritoById(item.IdDistrito);
                result.Add(region);
            }


            return result.Where(x=>x.IdProvincia == IdProvincial).Distinct().ToList();
        }


    }
}
