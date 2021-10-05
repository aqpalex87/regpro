using Microsoft.AspNetCore.Identity;
using Regpro.Core.Entities;
using Regpro.Core.Interfaces;
using Regpro.Infrastructure.Data;
using System.Threading.Tasks;

namespace Regpro.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly regproContext _context;
        private readonly IdentidadContext _identityContext;
        private readonly IProvinciaRepository _provinciaRepository;
        private readonly IRegionRepository _regionRepository;
        private readonly IDistritoRepository _distritoRepository;
        private readonly ITblRegproProgramaRepository _tblRegproProgramaRepository;
        private readonly ITblRegproMaestroRepository _tblRegproMaestroRepository;
        private readonly ITblRegproSolicitudRepository _tblRegproSolicitudRepository;
        private readonly ITblRegproDocumentoRepository _tblRegproDocumentoRepository;
        private readonly ITblRegproArchivoRepository _tblRegproArchivoRepository;
        private readonly IDetRegproSolDocRepository _detRegproSolDocRepository;
        private readonly IDreGeoRepository _dreGeoRepository;
        //private readonly IRepository<User> _userRepository;
        //private readonly ISecurityRepository _securityRepository;
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        private UserRepository _userRepository;
        private AuthenticationRepository _authenticationRepository;

        public UnitOfWork(regproContext context, IdentidadContext identityContext, RoleManager<Role> roleManager, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _identityContext = identityContext;
            this._roleManager = roleManager;
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        public IProvinciaRepository ProvinciaRepository => _provinciaRepository ?? new ProvinciaRepository(_context);
        public IRegionRepository RegionRepository => _regionRepository ?? new RegionRepository(_context);

        public IDistritoRepository DistritoRepository => _distritoRepository ?? new DistritoRepository(_context);

        public ITblRegproProgramaRepository TblRegproProgramaRepository => _tblRegproProgramaRepository ?? new TblRegproProgramaRepository(_context);

        public ITblRegproMaestroRepository TblRegproMaestroRepository => _tblRegproMaestroRepository ?? new TblRegproMaestroRepository(_context);
        public ITblRegproSolicitudRepository TblRegproSolicitudRepository => _tblRegproSolicitudRepository ?? new TblRegproSolicitudRepository(_context);

        public ITblRegproDocumentoRepository TblRegproDocumentoRepository => _tblRegproDocumentoRepository ?? new TblRegproDocumentoRepository (_context);
        public ITblRegproArchivoRepository TblRegproArchivoRepository => _tblRegproArchivoRepository ?? new TblRegproArchivoRepository(_context);
        public IUserRepository UserRepository => _userRepository = _userRepository ?? new UserRepository(_userManager, _identityContext);
        public IAuthenticationRepository AuthenticationRepository => _authenticationRepository = _authenticationRepository ?? new AuthenticationRepository(_signInManager, _identityContext);
        public IDetRegproSolDocRepository DetRegproSolDocRepository => _detRegproSolDocRepository ?? new DetRegproSolDocRepository(_context);
        public IDreGeoRepository DreGeoRepository => _dreGeoRepository ?? new DreGeoRepository(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
