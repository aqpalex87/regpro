using Regpro.Core.Entities;
using System;
using System.Threading.Tasks;

namespace Regpro.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProvinciaRepository ProvinciaRepository { get; }
        IRegionRepository RegionRepository { get; }
        IDistritoRepository DistritoRepository { get; }
        ITblRegproProgramaRepository TblRegproProgramaRepository { get; }
        ITblRegproMaestroRepository TblRegproMaestroRepository { get; }
        ITblRegproSolicitudRepository TblRegproSolicitudRepository { get; }
        ITblRegproDocumentoRepository TblRegproDocumentoRepository { get; }
        ITblRegproArchivoRepository TblRegproArchivoRepository { get; }
        IDetRegproSolDocRepository DetRegproSolDocRepository { get; }
        IDreGeoRepository DreGeoRepository { get; }
        IUserRepository UserRepository { get; }
        IAuthenticationRepository AuthenticationRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
        Task<int> CommitAsync();
    }
}
