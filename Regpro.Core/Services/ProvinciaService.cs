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
    public class ProvinciaService : IProvinciaService 
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public ProvinciaService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        public async Task<Provincia> GetProvincia(string id)
        {
            return await _unitOfWork.ProvinciaRepository.GetProvinciaById(id);
        }

        public PagedList<Provincia> GetProvincias(ProvinciaQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var provincia = _unitOfWork.ProvinciaRepository.GetAll();

            if(filters.IdRegion != null)
            {
                provincia = provincia.Where(x => x.IdRegion.ToLower().Contains(filters.IdRegion.ToLower())).ToList();
            }


            var pagedProvincias = PagedList<Provincia>.Create(provincia, filters.PageNumber, filters.PageSize);
            return pagedProvincias;
        }

        public async Task InsertProvincia(Provincia provincia)
        {

            await _unitOfWork.ProvinciaRepository.Add(provincia);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateProvincia(Provincia provincia)
        {
            var existingProvincia = await _unitOfWork.ProvinciaRepository.GetProvinciaById(provincia.IdProvincia);
            existingProvincia.IdRegion = provincia.IdRegion;
            existingProvincia.Provincia1 = provincia.Provincia1;
            existingProvincia.IndVerna = provincia.IndVerna;
            existingProvincia.PointX = provincia.PointX;
            existingProvincia.PointY = provincia.PointY;
            existingProvincia.Zoom = provincia.Zoom;

            _unitOfWork.ProvinciaRepository.Update(existingProvincia);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProvincia(int id)
        {
            await _unitOfWork.ProvinciaRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<Provincia>> GetProvinciaByCodUgel(string codUgel, string IdRegion)
        {
            if (string.IsNullOrEmpty(codUgel))
            {
                throw new BusinessException("codUgel no puede ser nullo o vacio");
            }
            if (string.IsNullOrEmpty(IdRegion))
            {
                throw new BusinessException("IdRegion no puede ser nullo o vacio");
            }
            if (codUgel.Length == 5)
            {
                throw new BusinessException("codUgel tiene que tener 6 digitos");
            }
            var region = await _unitOfWork.RegionRepository.GetRegionById(IdRegion);
            if (region == null)
            {
                throw new BusinessException("Region no existe");
            }
            var result = new List<Provincia>();

            var geos = await _unitOfWork.DreGeoRepository.GetAllDreGeoByCodUgel(codUgel);

            foreach (var item in geos)
            {
                var provincia = await _unitOfWork.ProvinciaRepository.GetProvinciaById(item.IdDistrito.Substring(0, 4));
                result.Add(provincia);
            }

            return result.Where(x=>x.IdRegion == IdRegion).Distinct().ToList();
        }

    }
}
