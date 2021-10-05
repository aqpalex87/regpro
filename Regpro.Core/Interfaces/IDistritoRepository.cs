using Regpro.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Regpro.Core.Interfaces
{
    public interface IDistritoRepository : IRepository<Distrito>
    {
        Task<IEnumerable<Distrito>> GetAllDistrito(); 
        Task<IEnumerable<Distrito>> GetDistritoByIdProvincia(string IdProvincia);
        Task<Distrito> GetDistritoById(string IdDistrito);
    }
}
