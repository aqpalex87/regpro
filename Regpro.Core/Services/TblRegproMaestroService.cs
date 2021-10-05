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
    public class TblRegproMaestroService : ITblRegproMaestroService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TblRegproMaestroService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<TblRegproMaestro>> GetAllByCodGrop(string CCodgrup)
        {
            var result = await _unitOfWork.TblRegproMaestroRepository.GetAllByCodGrop(CCodgrup);
            return result;
        }

        public async Task<IEnumerable<TblRegproMaestro>> GetAllByCodGropAndIdMaestropadre(string CCodgrup, long NIdMaestropadre)
        {
            return await _unitOfWork.TblRegproMaestroRepository.GetAllByCodGropAndIdMaestropadre(CCodgrup, NIdMaestropadre);
        }
        public async Task<IEnumerable<TblRegproMaestro>> GetAllByCodGropWithOutState(string CEstado)
        {
            return await _unitOfWork.TblRegproMaestroRepository.GetAllByCodGropWithOutState(CEstado);
        }

        public async Task<IEnumerable<TblRegproMaestro>> GetAllByMaestroPadre(long NIdMaestropadre)

        {
            return await _unitOfWork.TblRegproMaestroRepository.GetAllByMaestroPadre(NIdMaestropadre);
        }

        public async Task<IEnumerable<TblRegproMaestro>> GetMaestroByCodGropAndEstado(string CCodgrup, string  CEstado)
        {
            var allMaestro = await _unitOfWork.TblRegproMaestroRepository.GetAllMaestro();

            if (CEstado != "ALL") {
                allMaestro = allMaestro.Where(x => x.CEstado == CEstado).ToList();
            }

            allMaestro = allMaestro.Where(x=>x.CCodgrup == CCodgrup).ToList();

            return allMaestro;


        }


    }
}
