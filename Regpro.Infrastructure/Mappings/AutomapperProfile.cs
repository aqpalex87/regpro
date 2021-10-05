using AutoMapper;
using Regpro.Core.DTOs;
using Regpro.Core.DTOs.Identidad;
using Regpro.Core.Entities;

namespace Regpro.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Provincia, ProvinciaDto>();
            CreateMap<ProvinciaDto, Provincia>();

            CreateMap<Regione,RegionDto>();
            CreateMap<RegionDto, Regione>();

            CreateMap<Distrito, DistritoDto>();
            CreateMap<DistritoDto, Distrito>();

            CreateMap<TblRegproPrograma, TblRegproProgramaDto>();
            CreateMap<TblRegproProgramaDto, TblRegproPrograma>();

            CreateMap<TblRegproMaestro, TblRegproMaestroDto>();
            CreateMap<TblRegproMaestroDto, TblRegproMaestro>();

            CreateMap<TblRegproDocumento, TblRegproDocumentoDto>();
            CreateMap<TblRegproDocumentoDto, TblRegproDocumento>();

            CreateMap<TblRegproArchivo,TblRegproArchivoDto>();
            CreateMap<TblRegproArchivoDto, TblRegproArchivo>();

            CreateMap<User, UserForCreateDto>();
            CreateMap<UserForCreateDto, User>();

            CreateMap<User, UserForLoginDto>();
            CreateMap<UserForLoginDto, User>();

            CreateMap<User, UserForReturnDto>();
            CreateMap<UserForReturnDto, User>();

            CreateMap<User, UserForUpdateDto>();
            CreateMap<UserForUpdateDto, User>();

            CreateMap<TblRegproDocumento, TblRegproDocumentoDto>();
            CreateMap<TblRegproDocumentoDto, TblRegproDocumento>();

            CreateMap<TblRegproSolicitud, TblRegproSolicitudCreateDto>();
            CreateMap<TblRegproSolicitudCreateDto, TblRegproSolicitud>();
            CreateMap<TblRegproSolicitud, TblRegproSolicitudSelectDto>();
            CreateMap<TblRegproSolicitudSelectDto, TblRegproSolicitud>();

            


        }
    }
}
