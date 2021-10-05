using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Regpro.Core.Entities;

#nullable disable

namespace Regpro.Infrastructure.Data
{
    public partial class regproContext : DbContext
    {
        public regproContext()
        {
        }

        public regproContext(DbContextOptions<regproContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AudRegproAccsol> AudRegproAccsols { get; set; }
        public virtual DbSet<AudRegproArchivo> AudRegproArchivos { get; set; }
        public virtual DbSet<AudRegproCampo> AudRegproCampos { get; set; }
        public virtual DbSet<AudRegproDocumento> AudRegproDocumentos { get; set; }
        public virtual DbSet<AudRegproPrograma> AudRegproProgramas { get; set; }
        public virtual DbSet<AudRegproSolDoc> AudRegproSolDocs { get; set; }
        public virtual DbSet<AudRegproSolcam> AudRegproSolcams { get; set; }
        public virtual DbSet<AudRegproSolicitud> AudRegproSolicituds { get; set; }
        public virtual DbSet<CodmodAsig> CodmodAsigs { get; set; }
        public virtual DbSet<DetRegproProvedepa> DetRegproProvedepas { get; set; }
        public virtual DbSet<DetRegproSolDoc> DetRegproSolDocs { get; set; }
        public virtual DbSet<DetRegproSolcam> DetRegproSolcams { get; set; }
        public virtual DbSet<Distrito> Distritos { get; set; }
        public virtual DbSet<DreGeo> DreGeos { get; set; }
        public virtual DbSet<DreUgel> DreUgels { get; set; }
        public virtual DbSet<Provincia> Provincias { get; set; }
        public virtual DbSet<Regione> Regiones { get; set; }
        public virtual DbSet<TblRegproAccsoli> TblRegproAccsolis { get; set; }
        public virtual DbSet<TblRegproArchivo> TblRegproArchivos { get; set; }
        public virtual DbSet<TblRegproCampo> TblRegproCampos { get; set; }
        public virtual DbSet<TblRegproCoord> TblRegproCoords { get; set; }
        public virtual DbSet<TblRegproDocumento> TblRegproDocumentos { get; set; }
        public virtual DbSet<TblRegproMaestro> TblRegproMaestros { get; set; }
        public virtual DbSet<TblRegproParametro> TblRegproParametros { get; set; }
        public virtual DbSet<TblRegproPeriodo> TblRegproPeriodos { get; set; }
        public virtual DbSet<TblRegproPlantilla> TblRegproPlantillas { get; set; }
        public virtual DbSet<TblRegproPrograma> TblRegproProgramas { get; set; }
        public virtual DbSet<TblRegproSolicitud> TblRegproSolicituds { get; set; }
        public virtual DbSet<Temppronoei> Temppronoeis { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AudRegproAccsol>(entity =>
            {
                entity.HasKey(e => e.NIdAccionsoliaud)
                    .HasName("PRIMARY");

                entity.ToTable("aud_regpro_accsol");

                entity.HasComment("Tabla auditoria que almacena informacion de las acciones rea");

                entity.HasIndex(e => e.NIdSolicitudaud, "FK_RELATIONSHIP_20");

                entity.Property(e => e.NIdAccionsoliaud)
                    .HasColumnName("N_ID_ACCIONSOLIAUD")
                    .HasComment("Corresponde al idenfiticador de la accion de solicitud.");

                entity.Property(e => e.CEstado)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("C_ESTADO")
                    .HasComment("Corresponde al código de estado del dato maestro: ACTIV - Activo, INACT - Inactivo.\n            ");

                entity.Property(e => e.CUsucre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("C_USUCRE")
                    .HasComment("Corresponde al usuario que realizó la creación del registro.");

                entity.Property(e => e.CUsuumo)
                    .HasMaxLength(20)
                    .HasColumnName("C_USUUMO")
                    .HasComment("Corresponde al usuario que realizó la última modificación del registro.");

                entity.Property(e => e.DFeccre)
                    .HasColumnName("D_FECCRE")
                    .HasComment("Corresponde al año, mes, día, hora, minuto y segundo en que se creó el registro");

                entity.Property(e => e.DFecumo)
                    .HasColumnName("D_FECUMO")
                    .HasComment("Corresponde al día, mes, año, hora, minuto y segundo en que se realizó la última modificación del registro.");

                entity.Property(e => e.NIdSolicitudaud)
                    .HasColumnName("N_ID_SOLICITUDAUD")
                    .HasComment("Corresponde al identificador de la Solicitud.");

                entity.Property(e => e.NIdTipaccs)
                    .HasColumnName("N_ID_TIPACCS")
                    .HasComment("Corresponde al código del tipo de accion a la solciitud ubicado en el Maestro.");

                entity.HasOne(d => d.NIdSolicitudaudNavigation)
                    .WithMany(p => p.AudRegproAccsols)
                    .HasForeignKey(d => d.NIdSolicitudaud)
                    .HasConstraintName("FK_RELATIONSHIP_20");
            });

            modelBuilder.Entity<AudRegproArchivo>(entity =>
            {
                entity.HasKey(e => e.NIdArchivo2)
                    .HasName("PRIMARY");

                entity.ToTable("aud_regpro_archivo");

                entity.HasComment("Tabla auditoria que almacena informacion de archivos.");

                entity.HasIndex(e => e.NIdDocumentoaud, "FK_RELATIONSHIP_3");

                entity.Property(e => e.NIdArchivo2)
                    .HasColumnName("N_ID_ARCHIVO2")
                    .HasComment("Corresponde al identificador del archivo.");

                entity.Property(e => e.CCodarch)
                    .HasMaxLength(40)
                    .HasColumnName("C_CODARCH")
                    .HasComment("Corresponde al codigo unico por archivo.");

                entity.Property(e => e.CEstado)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("C_ESTADO")
                    .HasComment("Corresponde al código de estado del dato maestro: ACTIV - Activo, INACT - Inactivo.\n            ");

                entity.Property(e => e.CNomarch)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("C_NOMARCH")
                    .HasComment("Corresponde al nombre del archivo.");

                entity.Property(e => e.CUsucre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("C_USUCRE")
                    .HasComment("Corresponde al usuario que realizó la creación del registro.");

                entity.Property(e => e.CUsuumo)
                    .HasMaxLength(20)
                    .HasColumnName("C_USUUMO")
                    .HasComment("Corresponde al usuario que realizó la última modificación del registro.");

                entity.Property(e => e.DFeccre)
                    .HasColumnName("D_FECCRE")
                    .HasComment("Corresponde al año, mes, día, hora, minuto y segundo en que se creó el registro");

                entity.Property(e => e.DFecumo)
                    .HasColumnName("D_FECUMO")
                    .HasComment("Corresponde al día, mes, año, hora, minuto y segundo en que se realizó la última modificación del registro.");

                entity.Property(e => e.NIdDocumentoaud)
                    .HasColumnName("N_ID_DOCUMENTOAUD")
                    .HasComment("Corresponde al identificador del documento.");

                entity.Property(e => e.NIdTiparch)
                    .HasColumnName("N_ID_TIPARCH")
                    .HasComment("Corresponde al código del tipo de archivo ubicado en el Maestro.");

                entity.HasOne(d => d.NIdDocumentoaudNavigation)
                    .WithMany(p => p.AudRegproArchivos)
                    .HasForeignKey(d => d.NIdDocumentoaud)
                    .HasConstraintName("FK_RELATIONSHIP_3");
            });

            modelBuilder.Entity<AudRegproCampo>(entity =>
            {
                entity.HasKey(e => e.NIdCamposaud)
                    .HasName("PRIMARY");

                entity.ToTable("aud_regpro_campos");

                entity.HasComment("Tabla auditoria que almacena la informacion de los campos de");

                entity.Property(e => e.NIdCamposaud)
                    .HasColumnName("N_ID_CAMPOSAUD")
                    .HasComment("Corresponde al identificador de los campos.");

                entity.Property(e => e.BObligatorio)
                    .HasColumnName("B_OBLIGATORIO")
                    .HasComment("Corresponde a la obligatoriedad de un campo.");

                entity.Property(e => e.CEstado)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("C_ESTADO")
                    .HasComment("Corresponde al código de estado del dato maestro: ACTIV - Activo, INACT - Inactivo.\n            ");

                entity.Property(e => e.CNomcamp)
                    .HasMaxLength(50)
                    .HasColumnName("C_NOMCAMP")
                    .HasComment("Corresponde al nombre del campo.");

                entity.Property(e => e.CUsucre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("C_USUCRE")
                    .HasComment("Corresponde al usuario que realizó la creación del registro.");

                entity.Property(e => e.CUsuumo)
                    .HasMaxLength(20)
                    .HasColumnName("C_USUUMO")
                    .HasComment("Corresponde al usuario que realizó la última modificación del registro.");

                entity.Property(e => e.DFeccre)
                    .HasColumnName("D_FECCRE")
                    .HasComment("Corresponde al año, mes, día, hora, minuto y segundo en que se creó el registro");

                entity.Property(e => e.DFecumo)
                    .HasColumnName("D_FECUMO")
                    .HasComment("Corresponde al día, mes, año, hora, minuto y segundo en que se realizó la última modificación del registro.");
            });

            modelBuilder.Entity<AudRegproDocumento>(entity =>
            {
                entity.HasKey(e => e.NIdDocumentoaud)
                    .HasName("PRIMARY");

                entity.ToTable("aud_regpro_documento");

                entity.HasComment("Tabla que almacena la informacion de un documento.");

                entity.Property(e => e.NIdDocumentoaud)
                    .HasColumnName("N_ID_DOCUMENTOAUD")
                    .HasComment("Corresponde al identificador del documento.");

                entity.Property(e => e.CCoddocu)
                    .HasMaxLength(15)
                    .HasColumnName("C_CODDOCU")
                    .HasComment("Corresponde al codigo del documento.");

                entity.Property(e => e.CEstado)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("C_ESTADO")
                    .HasComment("Corresponde al código de estado del dato maestro: ACTIV - Activo, INACT - Inactivo.\n            ");

                entity.Property(e => e.CNrodoc)
                    .HasMaxLength(15)
                    .HasColumnName("C_NRODOC")
                    .HasComment("Corresponde al numero de documento.");

                entity.Property(e => e.CUsucre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("C_USUCRE")
                    .HasComment("Corresponde al usuario que realizó la creación del registro.");

                entity.Property(e => e.CUsuumo)
                    .HasMaxLength(20)
                    .HasColumnName("C_USUUMO")
                    .HasComment("Corresponde al usuario que realizó la última modificación del registro.");

                entity.Property(e => e.DFeccre)
                    .HasColumnName("D_FECCRE")
                    .HasComment("Corresponde al año, mes, día, hora, minuto y segundo en que se creó el registro");

                entity.Property(e => e.DFecdocu)
                    .HasColumnName("D_FECDOCU")
                    .HasComment("Corresponde al año, mes, día, hora, minuto y segundo del documento.");

                entity.Property(e => e.DFecumo)
                    .HasColumnName("D_FECUMO")
                    .HasComment("Corresponde al día, mes, año, hora, minuto y segundo en que se realizó la última modificación del registro.");

                entity.Property(e => e.NIdTipdocu)
                    .HasColumnName("N_ID_TIPDOCU")
                    .HasComment("Corresponde al código del tipo de documento ubicado en el Maestro.");
            });

            modelBuilder.Entity<AudRegproPrograma>(entity =>
            {
                entity.HasKey(e => e.NIdProgramaaud)
                    .HasName("PRIMARY");

                entity.ToTable("aud_regpro_programa");

                entity.HasComment("Tabla auditoria que almacena la informacion de un programa.");

                entity.Property(e => e.NIdProgramaaud)
                    .HasColumnName("N_ID_PROGRAMAAUD")
                    .HasComment("Corresponde al identificador del programa auditado.");

                entity.Property(e => e.CCodAreasig)
                    .HasMaxLength(1)
                    .HasColumnName("C_COD_AREASIG")
                    .IsFixedLength(true);

                entity.Property(e => e.CCodccpp)
                    .HasMaxLength(6)
                    .HasColumnName("C_CODCCPP")
                    .HasComment("Corresponde al codigo de centro poblado.");

                entity.Property(e => e.CCoddocu)
                    .HasMaxLength(100)
                    .HasColumnName("C_CODDOCU");

                entity.Property(e => e.CCodmod)
                    .IsRequired()
                    .HasMaxLength(7)
                    .HasColumnName("C_CODMOD")
                    .HasComment("Corresponde al cÃ³digo de modular.");

                entity.Property(e => e.CCsemc)
                    .HasMaxLength(7)
                    .HasColumnName("C_CSEMC")
                    .IsFixedLength(true)
                    .HasComment("Corresponde al codigo de servicio educativo mas cercano.");

                entity.Property(e => e.CDiretap)
                    .HasMaxLength(15)
                    .HasColumnName("C_DIRETAP")
                    .HasComment("Corresponde a la etapa de la direccion.");

                entity.Property(e => e.CDirlocd)
                    .HasMaxLength(70)
                    .HasColumnName("C_DIRLOCD")
                    .HasComment("Corresponde a la localidad de la direccion.");

                entity.Property(e => e.CDirlote)
                    .HasMaxLength(15)
                    .HasColumnName("C_DIRLOTE")
                    .HasComment("Corresponde al lote de la direccion.");

                entity.Property(e => e.CDirmz)
                    .HasMaxLength(10)
                    .HasColumnName("C_DIRMZ")
                    .HasComment("Corresponde al numero de manzana de la direccion.");

                entity.Property(e => e.CDirnomvia)
                    .HasMaxLength(70)
                    .HasColumnName("C_DIRNOMVIA")
                    .HasComment("Corresponde al nombre de via de la direccion.");

                entity.Property(e => e.CDirnumvia)
                    .HasMaxLength(20)
                    .HasColumnName("C_DIRNUMVIA")
                    .HasComment("Corresponde al numero de via de la direccion.");

                entity.Property(e => e.CDirotro)
                    .HasMaxLength(30)
                    .HasColumnName("C_DIROTRO")
                    .HasComment("Corresponde a otra informacion de la direccion.");

                entity.Property(e => e.CDirrefe)
                    .HasMaxLength(200)
                    .HasColumnName("C_DIRREFE")
                    .HasComment("Corresponde a la referencia de la direccion.");

                entity.Property(e => e.CDirsect)
                    .HasMaxLength(30)
                    .HasColumnName("C_DIRSECT")
                    .HasComment("Corresponde al sector de la direccion.");

                entity.Property(e => e.CDirzona)
                    .HasMaxLength(15)
                    .HasColumnName("C_DIRZONA")
                    .HasComment("Corresponde a la zona de la direccion.");

                entity.Property(e => e.CEstado)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("C_ESTADO")
                    .HasComment("Corresponde al cÃ³digo de estado del dato maestro: ACTIV - Activo, INACT - Inactivo.\n            ");

                entity.Property(e => e.CGeohash)
                    .HasMaxLength(10)
                    .HasColumnName("C_GEOHASH")
                    .IsFixedLength(true);

                entity.Property(e => e.CNomccpp)
                    .HasMaxLength(60)
                    .HasColumnName("C_NOMCCPP")
                    .HasComment("Corresponde al nombre del centro poblado.");

                entity.Property(e => e.CNomprog)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("C_NOMPROG")
                    .HasComment("Corresponde al nombre del programa.");

                entity.Property(e => e.CNomsemc)
                    .HasMaxLength(90)
                    .HasColumnName("C_NOMSEMC")
                    .HasComment("Corresponde al nombre del servicio educativo mas cercano.");

                entity.Property(e => e.CNrodoc)
                    .HasMaxLength(100)
                    .HasColumnName("C_NRODOC");

                entity.Property(e => e.COtrpragua)
                    .HasMaxLength(50)
                    .HasColumnName("C_OTRPRAGUA")
                    .HasComment("Corresponde a la descripcion de otro proveedor de agua.");

                entity.Property(e => e.COtrprener)
                    .HasMaxLength(50)
                    .HasColumnName("C_OTRPRENER")
                    .HasComment("Corresponde a la descripcion de otro proveedor de energia.");

                entity.Property(e => e.CSumagua)
                    .HasMaxLength(15)
                    .HasColumnName("C_SUMAGUA")
                    .HasComment("Corresponde al suministro de agua.");

                entity.Property(e => e.CSumener)
                    .HasMaxLength(15)
                    .HasColumnName("C_SUMENER")
                    .HasComment("Corresponde al suministro de energia.");

                entity.Property(e => e.CUsucre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("C_USUCRE")
                    .HasComment("Corresponde al usuario que realizÃ³ la creaciÃ³n del registro.");

                entity.Property(e => e.CUsuumo)
                    .HasMaxLength(20)
                    .HasColumnName("C_USUUMO")
                    .HasComment("Corresponde al usuario que realizÃ³ la Ãºltima modificaciÃ³n del registro.");

                entity.Property(e => e.CodArea)
                    .HasMaxLength(3)
                    .HasColumnName("COD_AREA")
                    .IsFixedLength(true)
                    .HasComment("Corresponde a identificar de 1: Rural, 2: Urbana.");

                entity.Property(e => e.Codgeo)
                    .HasMaxLength(6)
                    .HasColumnName("CODGEO")
                    .IsFixedLength(true)
                    .HasComment("Corresponde al identificador de la tabla DISTRITOS ");

                entity.Property(e => e.Codooii)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("CODOOII")
                    .IsFixedLength(true)
                    .HasComment("Corresponde al identificador de la tabla DRE_UGEL.");

                entity.Property(e => e.DFeccre)
                    .HasColumnName("D_FECCRE")
                    .HasComment("Corresponde al aÃ±o, mes, dÃ­a, hora, minuto y segundo en que se creÃ³ el registro");

                entity.Property(e => e.DFecdocu).HasColumnName("D_FECDOCU");

                entity.Property(e => e.DFecieprog).HasColumnName("D_FECIEPROG");

                entity.Property(e => e.DFecreprog).HasColumnName("D_FECREPROG");

                entity.Property(e => e.DFecumo)
                    .HasColumnName("D_FECUMO")
                    .HasComment("Corresponde al dÃ­a, mes, aÃ±o, hora, minuto y segundo en que se realizÃ³ la Ãºltima modificaciÃ³n del registro.");

                entity.Property(e => e.DFerenprog).HasColumnName("D_FERENPROG");

                entity.Property(e => e.Marcocd)
                    .HasMaxLength(3)
                    .HasColumnName("MARCOCD")
                    .IsFixedLength(true)
                    .HasComment("Corresponde a dato de padron.");

                entity.Property(e => e.Mcenso)
                    .HasMaxLength(3)
                    .HasColumnName("MCENSO")
                    .IsFixedLength(true)
                    .HasComment("Corresponde a dato de  marco censal de padron.");

                entity.Property(e => e.NCcpplat)
                    .HasColumnType("decimal(20,18)")
                    .HasColumnName("N_CCPPLAT");

                entity.Property(e => e.NCcpplon)
                    .HasColumnType("decimal(20,18)")
                    .HasColumnName("N_CCPPLON");

                entity.Property(e => e.NIdTipcjes)
                    .HasColumnName("N_ID_TIPCJES")
                    .HasComment("Corresponde al cÃ³digo del tipo de continuidad de la jornada escolar ubicado en el Maestro.");

                entity.Property(e => e.NIdTipdepe)
                    .HasColumnName("N_ID_TIPDEPE")
                    .HasComment("Corresponde al cÃ³digo del tipo de dependencia ubicado en el Maestro.");

                entity.Property(e => e.NIdTipeges)
                    .HasColumnName("N_ID_TIPEGES")
                    .HasComment("Corresponde al cÃ³digo del tipo de entidad gestora ubicado en el Maestro.");

                entity.Property(e => e.NIdTipestado).HasColumnName("N_ID_TIPESTADO");

                entity.Property(e => e.NIdTipgest)
                    .HasColumnName("N_ID_TIPGEST")
                    .HasComment("Corresponde al cÃ³digo del tipo de gestion ubicado en el Maestro.");

                entity.Property(e => e.NIdTiplocd)
                    .HasColumnName("N_ID_TIPLOCD")
                    .HasComment("Corresponde al cÃ³digo del tipo de localidad ubicado en el Maestro.");

                entity.Property(e => e.NIdTipprag)
                    .HasColumnName("N_ID_TIPPRAG")
                    .HasComment("Corresponde al cÃ³digo del tipo de proveedor de agua ubicado en el Maestro.");

                entity.Property(e => e.NIdTippren)
                    .HasColumnName("N_ID_TIPPREN")
                    .HasComment("Corresponde al cÃ³digo del tipo de proveedor de energia ubicado en el Maestro.");

                entity.Property(e => e.NIdTipprog)
                    .HasColumnName("N_ID_TIPPROG")
                    .HasComment("Corresponde al cÃ³digo del tipo de programa ubicado en el Maestro.");

                entity.Property(e => e.NIdTipreso).HasColumnName("N_ID_TIPRESO");

                entity.Property(e => e.NIdTipsitu)
                    .HasColumnName("N_ID_TIPSITU")
                    .HasComment("Corresponde al cÃ³digo del tipo de situacion del programa ubicado en el Maestro.");

                entity.Property(e => e.NIdTipturn)
                    .HasColumnName("N_ID_TIPTURN")
                    .HasComment("Corresponde al cÃ³digo del tipo de turno ubicado en el Maestro.");

                entity.Property(e => e.NIdTipvia)
                    .HasColumnName("N_ID_TIPVIA")
                    .HasComment("Corresponde al cÃ³digo del tipo de via ubicado en el Maestro.");

                entity.Property(e => e.NProlat)
                    .HasColumnType("decimal(20,18)")
                    .HasColumnName("N_PROLAT")
                    .HasComment("Corresponde a la latitud del programa.");

                entity.Property(e => e.NProlon)
                    .HasColumnType("decimal(20,18)")
                    .HasColumnName("N_PROLON")
                    .HasComment("Corresponde a la longitud del programa.");

                entity.Property(e => e.NSemclat)
                    .HasColumnType("decimal(20,18)")
                    .HasColumnName("N_SEMCLAT");

                entity.Property(e => e.NSemclon)
                    .HasColumnType("decimal(20,18)")
                    .HasColumnName("N_SEMCLON");

                entity.Property(e => e.Nzoom)
                    .HasColumnType("decimal(11,0)")
                    .HasColumnName("NZOOM")
                    .HasComment("Corresponde a dato de padron");
            });

            modelBuilder.Entity<AudRegproSolDoc>(entity =>
            {
                entity.HasKey(e => new { e.NIdDocumentoaud, e.NIdSolicitudaud })
                    .HasName("PRIMARY");

                entity.ToTable("aud_regpro_sol_doc");

                entity.HasComment("Tabla auditoria detalle que almacena informacion de las rela");

                entity.HasIndex(e => e.NIdSolicitudaud, "FK_RELATIONSHIP_9");

                entity.Property(e => e.NIdDocumentoaud)
                    .HasColumnName("N_ID_DOCUMENTOAUD")
                    .HasComment("Corresponde al identificador del documento.");

                entity.Property(e => e.NIdSolicitudaud)
                    .HasColumnName("N_ID_SOLICITUDAUD")
                    .HasComment("Corresponde al identificador de la Solicitud.");

                entity.Property(e => e.CEstado)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("C_ESTADO")
                    .HasComment("Corresponde al código de estado del dato maestro: ACTIV - Activo, INACT - Inactivo.\n            ");

                entity.Property(e => e.CUsucre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("C_USUCRE")
                    .HasComment("Corresponde al usuario que realizó la creación del registro.");

                entity.Property(e => e.CUsuumo)
                    .HasMaxLength(20)
                    .HasColumnName("C_USUUMO")
                    .HasComment("Corresponde al usuario que realizó la última modificación del registro.");

                entity.Property(e => e.DFeccre)
                    .HasColumnName("D_FECCRE")
                    .HasComment("Corresponde al año, mes, día, hora, minuto y segundo en que se creó el registro");

                entity.Property(e => e.DFecumo)
                    .HasColumnName("D_FECUMO")
                    .HasComment("Corresponde al día, mes, año, hora, minuto y segundo en que se realizó la última modificación del registro.");

                entity.HasOne(d => d.NIdDocumentoaudNavigation)
                    .WithMany(p => p.AudRegproSolDocs)
                    .HasForeignKey(d => d.NIdDocumentoaud)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELATIONSHIP_16");

                entity.HasOne(d => d.NIdSolicitudaudNavigation)
                    .WithMany(p => p.AudRegproSolDocs)
                    .HasForeignKey(d => d.NIdSolicitudaud)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELATIONSHIP_9");
            });

            modelBuilder.Entity<AudRegproSolcam>(entity =>
            {
                entity.HasKey(e => e.NIdSolcamaud)
                    .HasName("PRIMARY");

                entity.ToTable("aud_regpro_solcam");

                entity.HasComment("Tabla detalle auditoria que almacena la evaluacion de una so");

                entity.HasIndex(e => e.NIdSolicitudaud, "FK_RELATIONSHIP_21");

                entity.HasIndex(e => e.NIdCamposaud, "FK_RELATIONSHIP_22");

                entity.Property(e => e.NIdSolcamaud)
                    .HasColumnName("N_ID_SOLCAMAUD")
                    .HasComment("Corresponde al identificador de la evaluacion por campo.");

                entity.Property(e => e.CEstado)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("C_ESTADO")
                    .HasComment("Corresponde al código de estado del dato maestro: ACTIV - Activo, INACT - Inactivo.\n            ");

                entity.Property(e => e.CEsteval)
                    .HasMaxLength(10)
                    .HasColumnName("C_ESTEVAL")
                    .HasComment("Corresponde al estado de evaluacion.");

                entity.Property(e => e.CUsucre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("C_USUCRE")
                    .HasComment("Corresponde al usuario que realizó la creación del registro.");

                entity.Property(e => e.CUsuumo)
                    .HasMaxLength(20)
                    .HasColumnName("C_USUUMO")
                    .HasComment("Corresponde al usuario que realizó la última modificación del registro.");

                entity.Property(e => e.DFeccre)
                    .HasColumnName("D_FECCRE")
                    .HasComment("Corresponde al año, mes, día, hora, minuto y segundo en que se creó el registro");

                entity.Property(e => e.DFecumo)
                    .HasColumnName("D_FECUMO")
                    .HasComment("Corresponde al día, mes, año, hora, minuto y segundo en que se realizó la última modificación del registro.");

                entity.Property(e => e.NIdCamposaud)
                    .HasColumnName("N_ID_CAMPOSAUD")
                    .HasComment("Corresponde al identificador de los campos.");

                entity.Property(e => e.NIdSolicitudaud)
                    .HasColumnName("N_ID_SOLICITUDAUD")
                    .HasComment("Corresponde al identificador de la Solicitud.");

                entity.HasOne(d => d.NIdCamposaudNavigation)
                    .WithMany(p => p.AudRegproSolcams)
                    .HasForeignKey(d => d.NIdCamposaud)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELATIONSHIP_22");

                entity.HasOne(d => d.NIdSolicitudaudNavigation)
                    .WithMany(p => p.AudRegproSolcams)
                    .HasForeignKey(d => d.NIdSolicitudaud)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELATIONSHIP_21");
            });

            modelBuilder.Entity<AudRegproSolicitud>(entity =>
            {
                entity.HasKey(e => e.NIdSolicitudaud)
                    .HasName("PRIMARY");

                entity.ToTable("aud_regpro_solicitud");

                entity.HasComment("Tabla auditoria que almacena la informacion de una solicitud");

                entity.Property(e => e.NIdSolicitudaud)
                    .HasColumnName("N_ID_SOLICITUDAUD")
                    .HasComment("Corresponde al identificador de la Solicitud.");

                entity.Property(e => e.CCodccpp)
                    .HasMaxLength(6)
                    .HasColumnName("C_CODCCPP")
                    .HasComment("Corresponde al codigo de centro poblado.");

                entity.Property(e => e.CCodmod)
                    .IsRequired()
                    .HasMaxLength(7)
                    .HasColumnName("C_CODMOD")
                    .HasComment("Corresponde al código de modular.");

                entity.Property(e => e.CCodsoli)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("C_CODSOLI")
                    .HasComment("Corresponde al codigo de la solicitud.");

                entity.Property(e => e.CCsemc)
                    .HasMaxLength(7)
                    .HasColumnName("C_CSEMC")
                    .IsFixedLength(true)
                    .HasComment("Corresponde al codigo de servicio educativo mas cercano.");

                entity.Property(e => e.CDiretap)
                    .HasMaxLength(15)
                    .HasColumnName("C_DIRETAP")
                    .HasComment("Corresponde a la etapa de la direccion.");

                entity.Property(e => e.CDirlocd)
                    .HasMaxLength(70)
                    .HasColumnName("C_DIRLOCD")
                    .HasComment("Corresponde a la localidad de la direccion.");

                entity.Property(e => e.CDirlote)
                    .HasMaxLength(15)
                    .HasColumnName("C_DIRLOTE")
                    .HasComment("Corresponde al lote de la direccion.");

                entity.Property(e => e.CDirmz)
                    .HasMaxLength(10)
                    .HasColumnName("C_DIRMZ")
                    .HasComment("Corresponde al numero de manzana de la direccion.");

                entity.Property(e => e.CDirnomvia)
                    .HasMaxLength(70)
                    .HasColumnName("C_DIRNOMVIA")
                    .HasComment("Corresponde al nombre de via de la direccion.");

                entity.Property(e => e.CDirnumvia)
                    .HasMaxLength(20)
                    .HasColumnName("C_DIRNUMVIA")
                    .HasComment("Corresponde al numero de via de la direccion.");

                entity.Property(e => e.CDirotro)
                    .HasMaxLength(30)
                    .HasColumnName("C_DIROTRO")
                    .HasComment("Corresponde a otra informacion de la direccion.");

                entity.Property(e => e.CDirrefe)
                    .HasMaxLength(200)
                    .HasColumnName("C_DIRREFE")
                    .HasComment("Corresponde a la referencia de la direccion.");

                entity.Property(e => e.CDirsect)
                    .HasMaxLength(30)
                    .HasColumnName("C_DIRSECT")
                    .HasComment("Corresponde al sector de la direccion.");

                entity.Property(e => e.CDirzona)
                    .HasMaxLength(15)
                    .HasColumnName("C_DIRZONA")
                    .HasComment("Corresponde a la zona de la direccion.");

                entity.Property(e => e.CEstado)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("C_ESTADO")
                    .HasComment("Corresponde al código de estado del dato maestro: ACTIV - Activo, INACT - Inactivo.\n            ");

                entity.Property(e => e.CNomccpp)
                    .HasMaxLength(60)
                    .HasColumnName("C_NOMCCPP")
                    .HasComment("Corresponde al nombre del centro poblado.");

                entity.Property(e => e.CNomprog)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("C_NOMPROG")
                    .HasComment("Corresponde al nombre del programa.");

                entity.Property(e => e.CNomsemc)
                    .HasMaxLength(90)
                    .HasColumnName("C_NOMSEMC")
                    .HasComment("Corresponde al nombre del servicio educativo mas cercano.");

                entity.Property(e => e.CNomusuenv)
                    .HasMaxLength(50)
                    .HasColumnName("C_NOMUSUENV")
                    .HasComment("Corresponde al nombre completo del usuario que realizo el envio de la solicitud.");

                entity.Property(e => e.CNomusumodi)
                    .HasMaxLength(50)
                    .HasColumnName("C_NOMUSUMODI")
                    .HasComment("Corresponde al nombre completo del usuario que realizo la modificacion de la solicitud.");

                entity.Property(e => e.CNomusurevi)
                    .HasMaxLength(50)
                    .HasColumnName("C_NOMUSUREVI")
                    .HasComment("Corresponde al nombre completo del usuario que realizo la revision de la solicitud.");

                entity.Property(e => e.CNomusurevs)
                    .HasMaxLength(50)
                    .HasColumnName("C_NOMUSUREVS")
                    .HasComment("Corresponde al nombre completo del usuario que realizo la revision sig de la solicitud.");

                entity.Property(e => e.COtrpragua)
                    .HasMaxLength(50)
                    .HasColumnName("C_OTRPRAGUA")
                    .HasComment("Corresponde a la descripcion de otro proveedor de agua.");

                entity.Property(e => e.COtrprener)
                    .HasMaxLength(50)
                    .HasColumnName("C_OTRPRENER")
                    .HasComment("Corresponde a la descripcion de otro proveedor de energia.");

                entity.Property(e => e.CSumagua)
                    .HasMaxLength(15)
                    .HasColumnName("C_SUMAGUA")
                    .HasComment("Corresponde al suministro de agua.");

                entity.Property(e => e.CSumener)
                    .HasMaxLength(15)
                    .HasColumnName("C_SUMENER")
                    .HasComment("Corresponde al suministro de energia.");

                entity.Property(e => e.CUsucre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("C_USUCRE")
                    .HasComment("Corresponde al usuario que realizó la creación del registro.");

                entity.Property(e => e.CUsuenv)
                    .HasMaxLength(20)
                    .HasColumnName("C_USUENV")
                    .HasComment("Corresponde al usuario que realizó el envio de la solicitud.");

                entity.Property(e => e.CUsumodi)
                    .HasMaxLength(20)
                    .HasColumnName("C_USUMODI")
                    .HasComment("Corresponde al usuario que realizó la modificacion de la solicitud.");

                entity.Property(e => e.CUsurevi)
                    .HasMaxLength(20)
                    .HasColumnName("C_USUREVI")
                    .HasComment("Corresponde al usuario que realizó la revision de la solicitud.");

                entity.Property(e => e.CUsurevs)
                    .HasMaxLength(20)
                    .HasColumnName("C_USUREVS")
                    .HasComment("Corresponde al usuario que realizó la revision sig de la solicitud.");

                entity.Property(e => e.CUsuumo)
                    .HasMaxLength(20)
                    .HasColumnName("C_USUUMO")
                    .HasComment("Corresponde al usuario que realizó la última modificación del registro.");

                entity.Property(e => e.DFecaten)
                    .HasColumnName("D_FECATEN")
                    .HasComment("Corresponde al año, mes, día, hora, minuto y segundo en que se realizo la atencion la solicitud.");

                entity.Property(e => e.DFeccre)
                    .HasColumnName("D_FECCRE")
                    .HasComment("Corresponde al año, mes, día, hora, minuto y segundo en que se creó el registro");

                entity.Property(e => e.DFecenv)
                    .HasColumnName("D_FECENV")
                    .HasComment("Corresponde al año, mes, día, hora, minuto y segundo en que se envio la solicitud.");

                entity.Property(e => e.DFecmodi)
                    .HasColumnName("D_FECMODI")
                    .HasComment("Corresponde al año, mes, día, hora, minuto y segundo en que se modifico la solicitud.");

                entity.Property(e => e.DFecrevi)
                    .HasColumnName("D_FECREVI")
                    .HasComment("Corresponde al año, mes, día, hora, minuto y segundo en que se reviso la solicitud.");

                entity.Property(e => e.DFecrevs)
                    .HasColumnName("D_FECREVS")
                    .HasComment("Corresponde al año, mes, día, hora, minuto y segundo en que se realizo la revision sig la solicitud.");

                entity.Property(e => e.DFecumo)
                    .HasColumnName("D_FECUMO")
                    .HasComment("Corresponde al día, mes, año, hora, minuto y segundo en que se realizó la última modificación del registro.");

                entity.Property(e => e.NCcpplat)
                    .HasColumnType("decimal(8,6)")
                    .HasColumnName("N_CCPPLAT")
                    .HasComment("Corresponde a la latitud del centro poblado.");

                entity.Property(e => e.NCcpplon)
                    .HasColumnType("decimal(8,6)")
                    .HasColumnName("N_CCPPLON")
                    .HasComment("Corresponde a la longitud del centro poblado.");

                entity.Property(e => e.NIdTipcjes)
                    .HasColumnName("N_ID_TIPCJES")
                    .HasComment("Corresponde al código del tipo de continuidad de la jornada escolar ubicado en el Maestro.");

                entity.Property(e => e.NIdTipdepe)
                    .HasColumnName("N_ID_TIPDEPE")
                    .HasComment("Corresponde al código del tipo de dependencia ubicado en el Maestro.");

                entity.Property(e => e.NIdTipeges)
                    .HasColumnName("N_ID_TIPEGES")
                    .HasComment("Corresponde al código del tipo de entidad gestora ubicado en el Maestro.");

                entity.Property(e => e.NIdTipest)
                    .HasColumnName("N_ID_TIPEST")
                    .HasComment("Corresponde al código del tipo de estado de la solicitud ubicado en el Maestro.");

                entity.Property(e => e.NIdTipgest)
                    .HasColumnName("N_ID_TIPGEST")
                    .HasComment("Corresponde al código del tipo de gestion ubicado en el Maestro.");

                entity.Property(e => e.NIdTiplocd)
                    .HasColumnName("N_ID_TIPLOCD")
                    .HasComment("Corresponde al código del tipo de localidad ubicado en el Maestro.");

                entity.Property(e => e.NIdTipprag)
                    .HasColumnName("N_ID_TIPPRAG")
                    .HasComment("Corresponde al código del tipo de proveedor de agua ubicado en el Maestro.");

                entity.Property(e => e.NIdTippren)
                    .HasColumnName("N_ID_TIPPREN")
                    .HasComment("Corresponde al código del tipo de proveedor de energia ubicado en el Maestro.");

                entity.Property(e => e.NIdTipprog)
                    .HasColumnName("N_ID_TIPPROG")
                    .HasComment("Corresponde al código del tipo de programa ubicado en el Maestro.");

                entity.Property(e => e.NIdTipsoli)
                    .HasColumnName("N_ID_TIPSOLI")
                    .HasComment("Corresponde al código del tipo de solicitud ubicado en el Maestro.");

                entity.Property(e => e.NIdTipturn)
                    .HasColumnName("N_ID_TIPTURN")
                    .HasComment("Corresponde al código del tipo de turno ubicado en el Maestro.");

                entity.Property(e => e.NIdTipvia)
                    .HasColumnName("N_ID_TIPVIA")
                    .HasComment("Corresponde al código del tipo de via ubicado en el Maestro.");

                entity.Property(e => e.NProlat)
                    .HasColumnType("decimal(8,6)")
                    .HasColumnName("N_PROLAT")
                    .HasComment("Corresponde a la latitud del programa.");

                entity.Property(e => e.NProlon)
                    .HasColumnType("decimal(8,6)")
                    .HasColumnName("N_PROLON")
                    .HasComment("Corresponde a la longitud del programa.");

                entity.Property(e => e.NSemclat)
                    .HasColumnType("decimal(8,6)")
                    .HasColumnName("N_SEMCLAT")
                    .HasComment("Corresponde a la latitud del servicio educativo mas cercano.");

                entity.Property(e => e.NSemclon)
                    .HasColumnType("decimal(8,6)")
                    .HasColumnName("N_SEMCLON")
                    .HasComment("Corresponde a la longitud del servicio educativo mas cercano.");
            });

            modelBuilder.Entity<CodmodAsig>(entity =>
            {
                entity.ToTable("codmod_asig");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Asignado)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("asignado");

                entity.Property(e => e.Codmod)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("codmod");

                entity.Property(e => e.CodooiiAsig)
                    .HasMaxLength(6)
                    .HasColumnName("codooii_asig");

                entity.Property(e => e.FechaAsig).HasColumnName("fecha_asig");

                entity.Property(e => e.UsuarioAsig)
                    .HasMaxLength(15)
                    .HasColumnName("usuario_asig");
            });

            modelBuilder.Entity<DetRegproProvedepa>(entity =>
            {
                entity.HasKey(e => new { e.NIdMaestro, e.IdRegion })
                    .HasName("PRIMARY");

                entity.ToTable("det_regpro_provedepa");

                entity.HasComment("Tabla detalle que almacena informacion de proveedor por depa");

                entity.HasIndex(e => e.IdRegion, "FK_RELATIONSHIP_14");

                entity.Property(e => e.NIdMaestro)
                    .HasColumnName("N_ID_MAESTRO")
                    .HasComment("Corresponde al identificador del Maestro.");

                entity.Property(e => e.IdRegion)
                    .HasMaxLength(2)
                    .HasColumnName("ID_REGION")
                    .IsFixedLength(true);

                entity.Property(e => e.CEstado)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("C_ESTADO")
                    .HasComment("Corresponde al código de estado del dato maestro: ACTIV - Activo, INACT - Inactivo.\n            ");

                entity.Property(e => e.CUsucre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("C_USUCRE")
                    .HasComment("Corresponde al usuario que realizó la creación del registro.");

                entity.Property(e => e.CUsuumo)
                    .HasMaxLength(20)
                    .HasColumnName("C_USUUMO")
                    .HasComment("Corresponde al usuario que realizó la última modificación del registro.");

                entity.Property(e => e.DFeccre)
                    .HasColumnName("D_FECCRE")
                    .HasComment("Corresponde al año, mes, día, hora, minuto y segundo en que se creó el registro");

                entity.Property(e => e.DFecumo)
                    .HasColumnName("D_FECUMO")
                    .HasComment("Corresponde al día, mes, año, hora, minuto y segundo en que se realizó la última modificación del registro.");

                entity.HasOne(d => d.IdRegionNavigation)
                    .WithMany(p => p.DetRegproProvedepas)
                    .HasForeignKey(d => d.IdRegion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELATIONSHIP_14");

                entity.HasOne(d => d.NIdMaestroNavigation)
                    .WithMany(p => p.DetRegproProvedepas)
                    .HasForeignKey(d => d.NIdMaestro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELATIONSHIP_15");
            });

            modelBuilder.Entity<DetRegproSolDoc>(entity =>
            {
                entity.HasKey(e => new { e.NIdDocumento, e.NIdSolicitud })
                    .HasName("PRIMARY");

                entity.ToTable("det_regpro_sol_doc");

                entity.HasComment("Tabla detalle que almacena informacion de las relaciones de ");

                entity.HasIndex(e => e.NIdSolicitud, "FK_RELATIONSHIP_4");

                entity.Property(e => e.NIdDocumento)
                    .HasColumnName("N_ID_DOCUMENTO")
                    .HasComment("Corresponde al identificador del documento.");

                entity.Property(e => e.NIdSolicitud)
                    .HasColumnName("N_ID_SOLICITUD")
                    .HasComment("Corresponde al identificador de la Solicitud.");

                entity.Property(e => e.CEstado)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("C_ESTADO")
                    .HasComment("Corresponde al código de estado del dato maestro: ACTIV - Activo, INACT - Inactivo.\n            ");

                entity.Property(e => e.CUsucre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("C_USUCRE")
                    .HasComment("Corresponde al usuario que realizó la creación del registro.");

                entity.Property(e => e.CUsuumo)
                    .HasMaxLength(20)
                    .HasColumnName("C_USUUMO")
                    .HasComment("Corresponde al usuario que realizó la última modificación del registro.");

                entity.Property(e => e.DFeccre)
                    .HasColumnName("D_FECCRE")
                    .HasComment("Corresponde al año, mes, día, hora, minuto y segundo en que se creó el registro");

                entity.Property(e => e.DFecumo)
                    .HasColumnName("D_FECUMO")
                    .HasComment("Corresponde al día, mes, año, hora, minuto y segundo en que se realizó la última modificación del registro.");

                entity.HasOne(d => d.NIdDocumentoNavigation)
                    .WithMany(p => p.DetRegproSolDocs)
                    .HasForeignKey(d => d.NIdDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELATIONSHIP_5");

                entity.HasOne(d => d.NIdSolicitudNavigation)
                    .WithMany(p => p.DetRegproSolDocs)
                    .HasForeignKey(d => d.NIdSolicitud)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELATIONSHIP_4");
            });

            modelBuilder.Entity<DetRegproSolcam>(entity =>
            {
                entity.HasKey(e => e.NIdSolcam)
                    .HasName("PRIMARY");

                entity.ToTable("det_regpro_solcam");

                entity.HasComment("Tabla detalle que almacena la evaluacion de una solicitud po");

                entity.HasIndex(e => e.NIdSolicitud, "FK_RELATIONSHIP_17");

                entity.HasIndex(e => e.NIdCampos, "FK_RELATIONSHIP_19");

                entity.Property(e => e.NIdSolcam)
                    .HasColumnName("N_ID_SOLCAM")
                    .HasComment("Corresponde al identificador de la evaluacion por campo.");

                entity.Property(e => e.CEstado)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("C_ESTADO")
                    .HasComment("Corresponde al código de estado del dato maestro: ACTIV - Activo, INACT - Inactivo.\n            ");

                entity.Property(e => e.CEsteval)
                    .HasMaxLength(10)
                    .HasColumnName("C_ESTEVAL")
                    .HasComment("Corresponde al estado de evaluacion.");

                entity.Property(e => e.CPerfrev)
                    .HasMaxLength(5)
                    .HasColumnName("C_PERFREV");

                entity.Property(e => e.CUsucre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("C_USUCRE")
                    .HasComment("Corresponde al usuario que realizó la creación del registro.");

                entity.Property(e => e.CUsuumo)
                    .HasMaxLength(20)
                    .HasColumnName("C_USUUMO")
                    .HasComment("Corresponde al usuario que realizó la última modificación del registro.");

                entity.Property(e => e.DFeccre)
                    .HasColumnName("D_FECCRE")
                    .HasComment("Corresponde al año, mes, día, hora, minuto y segundo en que se creó el registro");

                entity.Property(e => e.DFecumo)
                    .HasColumnName("D_FECUMO")
                    .HasComment("Corresponde al día, mes, año, hora, minuto y segundo en que se realizó la última modificación del registro.");

                entity.Property(e => e.NIdCampos)
                    .HasColumnName("N_ID_CAMPOS")
                    .HasComment("Corresponde al identificador de los campos.");

                entity.Property(e => e.NIdSolicitud)
                    .HasColumnName("N_ID_SOLICITUD")
                    .HasComment("Corresponde al identificador de la Solicitud.");

                entity.HasOne(d => d.NIdCamposNavigation)
                    .WithMany(p => p.DetRegproSolcams)
                    .HasForeignKey(d => d.NIdCampos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELATIONSHIP_19");

                entity.HasOne(d => d.NIdSolicitudNavigation)
                    .WithMany(p => p.DetRegproSolcams)
                    .HasForeignKey(d => d.NIdSolicitud)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELATIONSHIP_17");
            });

            modelBuilder.Entity<Distrito>(entity =>
            {
                entity.HasKey(e => e.IdDistrito)
                    .HasName("PRIMARY");

                entity.ToTable("distritos");

                entity.HasComment("Tabla identica a Distritos del esquema PADRON.");

                entity.HasIndex(e => e.IdProvincia, "FK_RELATIONSHIP_8");

                entity.Property(e => e.IdDistrito)
                    .HasMaxLength(6)
                    .HasColumnName("ID_DISTRITO")
                    .IsFixedLength(true);

                entity.Property(e => e.Distrito1)
                    .HasMaxLength(50)
                    .HasColumnName("DISTRITO");

                entity.Property(e => e.IdProvincia)
                    .HasMaxLength(4)
                    .HasColumnName("ID_PROVINCIA")
                    .IsFixedLength(true);

                entity.Property(e => e.IndVerna)
                    .HasColumnType("decimal(1,0)")
                    .HasColumnName("IND_VERNA");

                entity.Property(e => e.Municip)
                    .HasColumnType("decimal(1,0)")
                    .HasColumnName("MUNICIP");

                entity.Property(e => e.PointX)
                    .HasColumnType("decimal(20,10)")
                    .HasColumnName("POINT_X");

                entity.Property(e => e.PointY)
                    .HasColumnType("decimal(20,10)")
                    .HasColumnName("POINT_Y");

                entity.Property(e => e.Zoom)
                    .HasColumnType("decimal(2,0)")
                    .HasColumnName("ZOOM");

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.Distritos)
                    .HasForeignKey(d => d.IdProvincia)
                    .HasConstraintName("FK_RELATIONSHIP_8");
            });

            modelBuilder.Entity<DreGeo>(entity =>
            {
                entity.HasKey(e => new { e.Codigo, e.IdDistrito })
                    .HasName("PRIMARY");

                entity.ToTable("dre_geo");

                entity.HasIndex(e => e.IdDistrito, "FK_RELATIONSHIP_10");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(6)
                    .HasColumnName("CODIGO")
                    .IsFixedLength(true);

                entity.Property(e => e.IdDistrito)
                    .HasMaxLength(6)
                    .HasColumnName("ID_DISTRITO")
                    .IsFixedLength(true);

                entity.Property(e => e.CEstado)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("C_ESTADO")
                    .HasComment("Corresponde al código de estado del dato maestro: ACTIV - Activo, INACT - Inactivo.\n            ");

                entity.Property(e => e.CUsucre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("C_USUCRE")
                    .HasComment("Corresponde al usuario que realizó la creación del registro.");

                entity.Property(e => e.CUsuumo)
                    .HasMaxLength(20)
                    .HasColumnName("C_USUUMO")
                    .HasComment("Corresponde al usuario que realizó la última modificación del registro.");

                entity.Property(e => e.DFeccre)
                    .HasColumnName("D_FECCRE")
                    .HasComment("Corresponde al año, mes, día, hora, minuto y segundo en que se creó el registro");

                entity.Property(e => e.DFecumo)
                    .HasColumnName("D_FECUMO")
                    .HasComment("Corresponde al día, mes, año, hora, minuto y segundo en que se realizó la última modificación del registro.");

                entity.HasOne(d => d.CodigoNavigation)
                    .WithMany(p => p.DreGeos)
                    .HasForeignKey(d => d.Codigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELATIONSHIP_11");

                entity.HasOne(d => d.IdDistritoNavigation)
                    .WithMany(p => p.DreGeos)
                    .HasForeignKey(d => d.IdDistrito)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELATIONSHIP_10");
            });

            modelBuilder.Entity<DreUgel>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PRIMARY");

                entity.ToTable("dre_ugel");

                entity.HasComment("Tabla identica a DRE_UGEL del esquema PADRON.");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(6)
                    .HasColumnName("CODIGO")
                    .IsFixedLength(true);

                entity.Property(e => e.InVerna)
                    .HasColumnType("decimal(1,0)")
                    .HasColumnName("IN_VERNA");

                entity.Property(e => e.Nombreoi)
                    .HasMaxLength(100)
                    .HasColumnName("NOMBREOI");

                entity.Property(e => e.PointX)
                    .HasColumnType("decimal(20,10)")
                    .HasColumnName("POINT_X");

                entity.Property(e => e.PointY)
                    .HasColumnType("decimal(20,10)")
                    .HasColumnName("POINT_Y");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(4)
                    .HasColumnName("TIPO");

                entity.Property(e => e.Zoom)
                    .HasColumnType("decimal(2,0)")
                    .HasColumnName("ZOOM");
            });

            modelBuilder.Entity<Provincia>(entity =>
            {
                entity.HasKey(e => e.IdProvincia)
                    .HasName("PRIMARY");

                entity.ToTable("provincias");

                entity.HasComment("Tabla identica a Provincias del esquema PADRON.");

                entity.HasIndex(e => e.IdRegion, "FK_RELATIONSHIP_7");

                entity.Property(e => e.IdProvincia)
                    .HasMaxLength(4)
                    .HasColumnName("ID_PROVINCIA")
                    .IsFixedLength(true);

                entity.Property(e => e.IdRegion)
                    .HasMaxLength(2)
                    .HasColumnName("ID_REGION")
                    .IsFixedLength(true);

                entity.Property(e => e.IndVerna)
                    .HasColumnType("decimal(1,0)")
                    .HasColumnName("IND_VERNA");

                entity.Property(e => e.PointX)
                    .HasColumnType("decimal(20,10)")
                    .HasColumnName("POINT_X");

                entity.Property(e => e.PointY)
                    .HasColumnType("decimal(20,10)")
                    .HasColumnName("POINT_Y");

                entity.Property(e => e.Provincia1)
                    .HasMaxLength(401)
                    .HasColumnName("PROVINCIA");

                entity.Property(e => e.Zoom)
                    .HasColumnType("decimal(2,0)")
                    .HasColumnName("ZOOM");

                entity.HasOne(d => d.IdRegionNavigation)
                    .WithMany(p => p.Provincia)
                    .HasForeignKey(d => d.IdRegion)
                    .HasConstraintName("FK_RELATIONSHIP_7");
            });

            modelBuilder.Entity<Regione>(entity =>
            {
                entity.HasKey(e => e.IdRegion)
                    .HasName("PRIMARY");

                entity.ToTable("regiones");

                entity.HasComment("Tabla identica a Regiones del esquema PADRON.");

                entity.Property(e => e.IdRegion)
                    .HasMaxLength(2)
                    .HasColumnName("ID_REGION")
                    .IsFixedLength(true);

                entity.Property(e => e.IndVerna)
                    .HasColumnType("decimal(1,0)")
                    .HasColumnName("IND_VERNA");

                entity.Property(e => e.PointX)
                    .HasColumnType("decimal(20,10)")
                    .HasColumnName("POINT_X");

                entity.Property(e => e.PointY)
                    .HasColumnType("decimal(20,10)")
                    .HasColumnName("POINT_Y");

                entity.Property(e => e.Region)
                    .HasMaxLength(30)
                    .HasColumnName("REGION");

                entity.Property(e => e.Zoom)
                    .HasColumnType("decimal(2,0)")
                    .HasColumnName("ZOOM");
            });

            modelBuilder.Entity<TblRegproAccsoli>(entity =>
            {
                entity.HasKey(e => e.NIdAccionsoli)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_regpro_accsoli");

                entity.HasComment("Tabla que almacena informacion de las acciones realizadas a ");

                entity.HasIndex(e => e.NIdSolicitud, "FK_RELATIONSHIP_6");

                entity.Property(e => e.NIdAccionsoli)
                    .HasColumnName("N_ID_ACCIONSOLI")
                    .HasComment("Corresponde al idenfiticador de la accion de solicitud.");

                entity.Property(e => e.CEstado)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("C_ESTADO")
                    .HasComment("Corresponde al código de estado del dato maestro: ACTIV - Activo, INACT - Inactivo.\n            ");

                entity.Property(e => e.CObs)
                    .HasMaxLength(500)
                    .HasColumnName("C_OBS");

                entity.Property(e => e.CPerfrev)
                    .HasMaxLength(5)
                    .HasColumnName("C_PERFREV");

                entity.Property(e => e.CUsucre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("C_USUCRE")
                    .HasComment("Corresponde al usuario que realizó la creación del registro.");

                entity.Property(e => e.CUsuumo)
                    .HasMaxLength(20)
                    .HasColumnName("C_USUUMO")
                    .HasComment("Corresponde al usuario que realizó la última modificación del registro.");

                entity.Property(e => e.DFeccre)
                    .HasColumnName("D_FECCRE")
                    .HasComment("Corresponde al año, mes, día, hora, minuto y segundo en que se creó el registro");

                entity.Property(e => e.DFecumo)
                    .HasColumnName("D_FECUMO")
                    .HasComment("Corresponde al día, mes, año, hora, minuto y segundo en que se realizó la última modificación del registro.");

                entity.Property(e => e.NIdSolicitud)
                    .HasColumnName("N_ID_SOLICITUD")
                    .HasComment("Corresponde al identificador de la Solicitud.");

                entity.Property(e => e.NIdTipsitu)
                    .HasColumnName("N_ID_TIPSITU")
                    .HasComment("Corresponde al c");

                entity.HasOne(d => d.NIdSolicitudNavigation)
                    .WithMany(p => p.TblRegproAccsolis)
                    .HasForeignKey(d => d.NIdSolicitud)
                    .HasConstraintName("FK_RELATIONSHIP_6");
            });

            modelBuilder.Entity<TblRegproArchivo>(entity =>
            {
                entity.HasKey(e => e.NIdArchivo)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_regpro_archivo");

                entity.HasComment("Tabla que almacena informacion de archivos.");

                entity.HasIndex(e => e.NIdDocumento, "FK_RELATIONSHIP_2");

                entity.Property(e => e.NIdArchivo)
                    .HasColumnName("N_ID_ARCHIVO")
                    .HasComment("Corresponde al identificador del archivo.");

                entity.Property(e => e.CCodarch)
                    .HasMaxLength(100)
                    .HasColumnName("C_CODARCH")
                    .HasComment("Corresponde al codigo unico por archivo.");

                entity.Property(e => e.CEstado)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("C_ESTADO")
                    .HasComment("Corresponde al código de estado del dato maestro: ACTIV - Activo, INACT - Inactivo.\n            ");

                entity.Property(e => e.CNomarch)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("C_NOMARCH")
                    .HasComment("Corresponde al nombre del archivo.");

                entity.Property(e => e.CUsucre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("C_USUCRE")
                    .HasComment("Corresponde al usuario que realizó la creación del registro.");

                entity.Property(e => e.CUsuumo)
                    .HasMaxLength(20)
                    .HasColumnName("C_USUUMO")
                    .HasComment("Corresponde al usuario que realizó la última modificación del registro.");

                entity.Property(e => e.DFeccre)
                    .HasColumnName("D_FECCRE")
                    .HasComment("Corresponde al año, mes, día, hora, minuto y segundo en que se creó el registro");

                entity.Property(e => e.DFecumo)
                    .HasColumnName("D_FECUMO")
                    .HasComment("Corresponde al día, mes, año, hora, minuto y segundo en que se realizó la última modificación del registro.");

                entity.Property(e => e.NIdDocumento)
                    .HasColumnName("N_ID_DOCUMENTO")
                    .HasComment("Corresponde al identificador del documento.");

                entity.Property(e => e.NIdTiparch)
                    .HasColumnName("N_ID_TIPARCH")
                    .HasComment("Corresponde al código del tipo de archivo ubicado en el Maestro.");

                entity.HasOne(d => d.NIdDocumentoNavigation)
                    .WithMany(p => p.TblRegproArchivos)
                    .HasForeignKey(d => d.NIdDocumento)
                    .HasConstraintName("FK_RELATIONSHIP_2");
            });

            modelBuilder.Entity<TblRegproCampo>(entity =>
            {
                entity.HasKey(e => e.NIdCampos)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_regpro_campos");

                entity.HasComment("Tabla que almacena la informacion de los campos de un solici");

                entity.Property(e => e.NIdCampos)
                    .HasColumnName("N_ID_CAMPOS")
                    .HasComment("Corresponde al identificador de los campos.");

                entity.Property(e => e.BObligatorio)
                    .HasColumnName("B_OBLIGATORIO")
                    .HasComment("Corresponde a la obligatoriedad de un campo.");

                entity.Property(e => e.CCodcamp)
                    .HasMaxLength(10)
                    .HasColumnName("C_CODCAMP");

                entity.Property(e => e.CEstado)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("C_ESTADO")
                    .HasComment("Corresponde al código de estado del dato maestro: ACTIV - Activo, INACT - Inactivo.\n            ");

                entity.Property(e => e.CNomcamp)
                    .HasMaxLength(50)
                    .HasColumnName("C_NOMCAMP")
                    .HasComment("Corresponde al nombre del campo.");

                entity.Property(e => e.CUsucre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("C_USUCRE")
                    .HasComment("Corresponde al usuario que realizó la creación del registro.");

                entity.Property(e => e.CUsuumo)
                    .HasMaxLength(20)
                    .HasColumnName("C_USUUMO")
                    .HasComment("Corresponde al usuario que realizó la última modificación del registro.");

                entity.Property(e => e.DFeccre)
                    .HasColumnName("D_FECCRE")
                    .HasComment("Corresponde al año, mes, día, hora, minuto y segundo en que se creó el registro");

                entity.Property(e => e.DFecumo)
                    .HasColumnName("D_FECUMO")
                    .HasComment("Corresponde al día, mes, año, hora, minuto y segundo en que se realizó la última modificación del registro.");
            });

            modelBuilder.Entity<TblRegproCoord>(entity =>
            {
                entity.HasKey(e => e.NIdCoord)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_regpro_coord");

                entity.HasComment("Tabla que almacena informacion de coordinadores por DRE");

                entity.HasIndex(e => e.Codigo, "FK_RELATIONSHIP_12");

                entity.Property(e => e.NIdCoord)
                    .HasColumnName("N_ID_COORD")
                    .HasComment("Corresponde al identificador de la tabla.");

                entity.Property(e => e.CEstado)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("C_ESTADO")
                    .HasComment("Corresponde al código de estado del dato maestro: ACTIV - Activo, INACT - Inactivo.\n            ");

                entity.Property(e => e.CUsucoord)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("C_USUCOORD")
                    .HasComment("Corresponde al usuario coordinador de una dre.");

                entity.Property(e => e.CUsucre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("C_USUCRE")
                    .HasComment("Corresponde al usuario que realizó la creación del registro.");

                entity.Property(e => e.CUsuumo)
                    .HasMaxLength(20)
                    .HasColumnName("C_USUUMO")
                    .HasComment("Corresponde al usuario que realizó la última modificación del registro.");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(6)
                    .HasColumnName("CODIGO")
                    .IsFixedLength(true);

                entity.Property(e => e.DFeccre)
                    .HasColumnName("D_FECCRE")
                    .HasComment("Corresponde al año, mes, día, hora, minuto y segundo en que se creó el registro");

                entity.Property(e => e.DFecumo)
                    .HasColumnName("D_FECUMO")
                    .HasComment("Corresponde al día, mes, año, hora, minuto y segundo en que se realizó la última modificación del registro.");

                entity.HasOne(d => d.CodigoNavigation)
                    .WithMany(p => p.TblRegproCoords)
                    .HasForeignKey(d => d.Codigo)
                    .HasConstraintName("FK_RELATIONSHIP_12");
            });

            modelBuilder.Entity<TblRegproDocumento>(entity =>
            {
                entity.HasKey(e => e.NIdDocumento)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_regpro_documento");

                entity.HasComment("Tabla que almacena la informacion de un documento.");

                entity.Property(e => e.NIdDocumento)
                    .HasColumnName("N_ID_DOCUMENTO")
                    .HasComment("Corresponde al identificador del documento.");

                entity.Property(e => e.CCoddocu)
                    .HasMaxLength(100)
                    .HasColumnName("C_CODDOCU")
                    .HasComment("Corresponde al codigo del documento.");

                entity.Property(e => e.CEstado)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("C_ESTADO")
                    .HasComment("Corresponde al código de estado del dato maestro: ACTIV - Activo, INACT - Inactivo.\n            ");

                entity.Property(e => e.CNrodoc)
                    .HasMaxLength(100)
                    .HasColumnName("C_NRODOC")
                    .HasComment("Corresponde al numero de documento.");

                entity.Property(e => e.CUsucre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("C_USUCRE")
                    .HasComment("Corresponde al usuario que realizó la creación del registro.");

                entity.Property(e => e.CUsuumo)
                    .HasMaxLength(20)
                    .HasColumnName("C_USUUMO")
                    .HasComment("Corresponde al usuario que realizó la última modificación del registro.");

                entity.Property(e => e.Codooii)
                    .HasMaxLength(6)
                    .HasColumnName("CODOOII")
                    .IsFixedLength(true);

                entity.Property(e => e.DFeccre)
                    .HasColumnName("D_FECCRE")
                    .HasComment("Corresponde al año, mes, día, hora, minuto y segundo en que se creó el registro");

                entity.Property(e => e.DFecdocu)
                    .HasColumnName("D_FECDOCU")
                    .HasComment("Corresponde al año, mes, día, hora, minuto y segundo del documento.");

                entity.Property(e => e.DFecumo)
                    .HasColumnName("D_FECUMO")
                    .HasComment("Corresponde al día, mes, año, hora, minuto y segundo en que se realizó la última modificación del registro.");

                entity.Property(e => e.NIdTipdocu)
                    .HasColumnName("N_ID_TIPDOCU")
                    .HasComment("Corresponde al código del tipo de documento ubicado en el Maestro.");

                entity.Property(e => e.NIdTipreso).HasColumnName("N_ID_TIPRESO");
            });

            modelBuilder.Entity<TblRegproMaestro>(entity =>
            {
                entity.HasKey(e => e.NIdMaestro)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_regpro_maestro");

                entity.HasComment("Tabla que almacena datos maestros del sistema");

                entity.HasIndex(e => e.NIdMaestropadre, "FK_CFK_MAESTRO_MAESTRO");

                entity.Property(e => e.NIdMaestro)
                    .HasColumnName("N_ID_MAESTRO")
                    .HasComment("Corresponde al identificador del Maestro.");

                entity.Property(e => e.CCodgrup)
                    .HasMaxLength(5)
                    .HasColumnName("C_CODGRUP")
                    .HasComment("Corresponde al codigo de agrupacion de los datos maestros.");

                entity.Property(e => e.CCoditem)
                    .HasMaxLength(6)
                    .HasColumnName("C_CODITEM")
                    .HasComment("Corresponde al codigo del item.");

                entity.Property(e => e.CDesc)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("C_DESC")
                    .HasComment("Corresponde al descripcion del dato maestro.");

                entity.Property(e => e.CEstado)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("C_ESTADO")
                    .HasComment("Corresponde al código de estado del dato maestro: ACTIV - Activo, INACT - Inactivo.\n            ");

                entity.Property(e => e.CNom)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("C_NOM")
                    .HasComment("Corresponde al nombre del dato maestro.");

                entity.Property(e => e.CUsucre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("C_USUCRE")
                    .HasComment("Corresponde al usuario que realizó la creación del registro.");

                entity.Property(e => e.CUsuumo)
                    .HasMaxLength(20)
                    .HasColumnName("C_USUUMO")
                    .HasComment("Corresponde al usuario que realizó la última modificación del registro.");

                entity.Property(e => e.DFeccre)
                    .HasColumnName("D_FECCRE")
                    .HasComment("Corresponde al año, mes, día, hora, minuto y segundo en que se creó el registro");

                entity.Property(e => e.DFecumo)
                    .HasColumnName("D_FECUMO")
                    .HasComment("Corresponde al día, mes, año, hora, minuto y segundo en que se realizó la última modificación del registro.");

                entity.Property(e => e.NIdMaestropadre)
                    .HasColumnName("N_ID_MAESTROPADRE")
                    .HasComment("Corresponde al identificador del Maestro.");

                entity.HasOne(d => d.NIdMaestropadreNavigation)
                    .WithMany(p => p.InverseNIdMaestropadreNavigation)
                    .HasForeignKey(d => d.NIdMaestropadre)
                    .HasConstraintName("FK_CFK_MAESTRO_MAESTRO");
            });

            modelBuilder.Entity<TblRegproParametro>(entity =>
            {
                entity.HasKey(e => e.NIdParametro)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_regpro_parametro");

                entity.HasComment("Tabla que gurada informacion de los parametros del sistema.");

                entity.Property(e => e.NIdParametro)
                    .HasColumnName("N_ID_PARAMETRO")
                    .HasComment("Indetificaro unico de la tabla.");

                entity.Property(e => e.CCodparame)
                    .HasMaxLength(50)
                    .HasColumnName("C_CODPARAME")
                    .HasComment("Corresponde al codigo del parametro.");

                entity.Property(e => e.CDesparam)
                    .HasMaxLength(100)
                    .HasColumnName("C_DESPARAM")
                    .HasComment("Corresponde a la descripcion del parametro.");

                entity.Property(e => e.CEstado)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("C_ESTADO")
                    .HasComment("Corresponde al cÃ³digo de estado del dato maestro: ACTIV - Activo, INACT - Inactivo.\n            ");

                entity.Property(e => e.CUsucre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("C_USUCRE")
                    .HasComment("Corresponde al usuario que realizÃ³ la creaciÃ³n del registro.");

                entity.Property(e => e.CUsuumo)
                    .HasMaxLength(20)
                    .HasColumnName("C_USUUMO")
                    .HasComment("Corresponde al usuario que realizÃ³ la Ãºltima modificaciÃ³n del registro.");

                entity.Property(e => e.CValorparam)
                    .HasMaxLength(150)
                    .HasColumnName("C_VALORPARAM")
                    .HasComment("Corresponde al valor tipo letra del parametro.");

                entity.Property(e => e.DFeccre)
                    .HasColumnName("D_FECCRE")
                    .HasComment("Corresponde al aÃ±o, mes, dÃ­a, hora, minuto y segundo en que se creÃ³ el registro");

                entity.Property(e => e.DFecumo)
                    .HasColumnName("D_FECUMO")
                    .HasComment("Corresponde al dÃ­a, mes, aÃ±o, hora, minuto y segundo en que se realizÃ³ la Ãºltima modificaciÃ³n del registro.");

                entity.Property(e => e.DValorparam)
                    .HasColumnName("D_VALORPARAM")
                    .HasComment("Corresponde al valor tipo fecha del parametro.");

                entity.Property(e => e.NValorparam)
                    .HasColumnType("decimal(4,2)")
                    .HasColumnName("N_VALORPARAM")
                    .HasComment("Corresponde al valor tipo numerico del parametro.");
            });

            modelBuilder.Entity<TblRegproPeriodo>(entity =>
            {
                entity.HasKey(e => e.NIdPeriodo)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_regpro_periodo");

                entity.HasComment("Tabla que almacena el dia del corte del programa");

                entity.Property(e => e.NIdPeriodo)
                    .HasColumnName("N_ID_PERIODO")
                    .HasComment("Corresponde al codigo del periodo de corte");

                entity.Property(e => e.CCodgrup)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("C_CODGRUP")
                    .HasComment("Corresponde al grupo asignado, en el maestro para la gestion de periodos");

                entity.Property(e => e.CCoditem)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("C_CODITEM")
                    .HasComment("Corresponde al item asignado, en el maestro para la gestion de periodos");

                entity.Property(e => e.CEstado)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("C_ESTADO")
                    .HasComment("Corresponde al estado 1=ACTIVO 0=INACTIVO");

                entity.Property(e => e.CNomperiodo)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("C_NOMPERIODO")
                    .HasComment("Corresponde al nombre asignado, al periodo de corte");

                entity.Property(e => e.CUsucrea)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("C_USUCREA")
                    .HasComment("Usuario de creaciÃ³n");

                entity.Property(e => e.DFecFinanio)
                    .HasColumnType("date")
                    .HasColumnName("D_FEC_FINANIO")
                    .HasComment("vALIDA QUE LA FECHA FIN DEL ");

                entity.Property(e => e.DFecFinperiodo)
                    .HasColumnType("date")
                    .HasColumnName("D_FEC_FINPERIODO")
                    .HasComment("Corresponde a la fecha de fin del periodo de corte");

                entity.Property(e => e.DFecIniperiodo)
                    .HasColumnType("date")
                    .HasColumnName("D_FEC_INIPERIODO")
                    .HasComment("Corresponde a la fecha de inicio del periodo de corte");

                entity.Property(e => e.DFeccrea)
                    .HasColumnType("date")
                    .HasColumnName("D_FECCREA")
                    .HasComment("Corresponde a la fecha de creaciÃ³n");
            });

            modelBuilder.Entity<TblRegproPlantilla>(entity =>
            {
                entity.HasKey(e => e.NIdPlantilla)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_regpro_plantilla");

                entity.HasComment("Tabla que almacena informacion de plantillas del sistema..");

                entity.Property(e => e.NIdPlantilla)
                    .HasColumnName("N_ID_PLANTILLA")
                    .HasComment("Corresponde al identificador de la plantilla.");

                entity.Property(e => e.CCodarch)
                    .HasMaxLength(40)
                    .HasColumnName("C_CODARCH")
                    .HasComment("Corresponde al codigo unico por archivo.");

                entity.Property(e => e.CDescplantilla)
                    .HasColumnName("C_DESCPLANTILLA")
                    .HasComment("Corresponde a la descripcion de la plantilla.");

                entity.Property(e => e.CEstado)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("C_ESTADO")
                    .HasComment("Corresponde al código de estado del dato maestro: ACTIV - Activo, INACT - Inactivo.\n            ");

                entity.Property(e => e.CNomplantilla)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("C_NOMPLANTILLA")
                    .HasComment("Corresponde al nombre de la plantilla.");

                entity.Property(e => e.CUsucre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("C_USUCRE")
                    .HasComment("Corresponde al usuario que realizó la creación del registro.");

                entity.Property(e => e.CUsuumo)
                    .HasMaxLength(20)
                    .HasColumnName("C_USUUMO")
                    .HasComment("Corresponde al usuario que realizó la última modificación del registro.");

                entity.Property(e => e.DFeccre)
                    .HasColumnName("D_FECCRE")
                    .HasComment("Corresponde al año, mes, día, hora, minuto y segundo en que se creó el registro");

                entity.Property(e => e.DFecumo)
                    .HasColumnName("D_FECUMO")
                    .HasComment("Corresponde al día, mes, año, hora, minuto y segundo en que se realizó la última modificación del registro.");

                entity.Property(e => e.NIdTipplantilla)
                    .HasColumnName("N_ID_TIPPLANTILLA")
                    .HasComment("Corresponde al código del tipo de plantilla ubicado en el Maestro.");
            });

            modelBuilder.Entity<TblRegproPrograma>(entity =>
            {
                entity.HasKey(e => e.NIdPrograma)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_regpro_programa");

                entity.HasComment("Tabla que almacena la informacion de un programa.");

                entity.Property(e => e.NIdPrograma)
                    .HasColumnName("N_ID_PROGRAMA")
                    .HasComment("Corresponde al identificador de la Solicitud.");

                entity.Property(e => e.CCodAreasig)
                    .HasMaxLength(1)
                    .HasColumnName("C_COD_AREASIG")
                    .IsFixedLength(true);

                entity.Property(e => e.CCodccpp)
                    .HasMaxLength(6)
                    .HasColumnName("C_CODCCPP")
                    .HasComment("Corresponde al codigo de centro poblado.");

                entity.Property(e => e.CCoddocu)
                    .HasMaxLength(100)
                    .HasColumnName("C_CODDOCU");

                entity.Property(e => e.CCodmod)
                    .IsRequired()
                    .HasMaxLength(7)
                    .HasColumnName("C_CODMOD")
                    .HasComment("Corresponde al código de modular.");

                entity.Property(e => e.CCsemc)
                    .HasMaxLength(7)
                    .HasColumnName("C_CSEMC")
                    .IsFixedLength(true)
                    .HasComment("Corresponde al codigo de servicio educativo mas cercano.");

                entity.Property(e => e.CDiretap)
                    .HasMaxLength(15)
                    .HasColumnName("C_DIRETAP")
                    .HasComment("Corresponde a la etapa de la direccion.");

                entity.Property(e => e.CDirlocd)
                    .HasMaxLength(70)
                    .HasColumnName("C_DIRLOCD")
                    .HasComment("Corresponde a la localidad de la direccion.");

                entity.Property(e => e.CDirlote)
                    .HasMaxLength(15)
                    .HasColumnName("C_DIRLOTE")
                    .HasComment("Corresponde al lote de la direccion.");

                entity.Property(e => e.CDirmz)
                    .HasMaxLength(10)
                    .HasColumnName("C_DIRMZ")
                    .HasComment("Corresponde al numero de manzana de la direccion.");

                entity.Property(e => e.CDirnomvia)
                    .HasMaxLength(70)
                    .HasColumnName("C_DIRNOMVIA")
                    .HasComment("Corresponde al nombre de via de la direccion.");

                entity.Property(e => e.CDirnumvia)
                    .HasMaxLength(20)
                    .HasColumnName("C_DIRNUMVIA")
                    .HasComment("Corresponde al numero de via de la direccion.");

                entity.Property(e => e.CDirotro)
                    .HasMaxLength(30)
                    .HasColumnName("C_DIROTRO")
                    .HasComment("Corresponde a otra informacion de la direccion.");

                entity.Property(e => e.CDirrefe)
                    .HasMaxLength(200)
                    .HasColumnName("C_DIRREFE")
                    .HasComment("Corresponde a la referencia de la direccion.");

                entity.Property(e => e.CDirsect)
                    .HasMaxLength(30)
                    .HasColumnName("C_DIRSECT")
                    .HasComment("Corresponde al sector de la direccion.");

                entity.Property(e => e.CDirzona)
                    .HasMaxLength(15)
                    .HasColumnName("C_DIRZONA")
                    .HasComment("Corresponde a la zona de la direccion.");

                entity.Property(e => e.CEstado)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("C_ESTADO")
                    .HasComment("Corresponde al código de estado del dato maestro: ACTIV - Activo, INACT - Inactivo.\n            ");

                entity.Property(e => e.CGeohash)
                    .HasMaxLength(10)
                    .HasColumnName("C_GEOHASH")
                    .IsFixedLength(true);

                entity.Property(e => e.CNomccpp)
                    .HasMaxLength(60)
                    .HasColumnName("C_NOMCCPP")
                    .HasComment("Corresponde al nombre del centro poblado.");

                entity.Property(e => e.CNomprog)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("C_NOMPROG")
                    .HasComment("Corresponde al nombre del programa.");

                entity.Property(e => e.CNomsemc)
                    .HasMaxLength(90)
                    .HasColumnName("C_NOMSEMC")
                    .HasComment("Corresponde al nombre del servicio educativo mas cercano.");

                entity.Property(e => e.CNrodoc)
                    .HasMaxLength(100)
                    .HasColumnName("C_NRODOC");

                entity.Property(e => e.COtrpragua)
                    .HasMaxLength(50)
                    .HasColumnName("C_OTRPRAGUA")
                    .HasComment("Corresponde a la descripcion de otro proveedor de agua.");

                entity.Property(e => e.COtrprener)
                    .HasMaxLength(50)
                    .HasColumnName("C_OTRPRENER")
                    .HasComment("Corresponde a la descripcion de otro proveedor de energia.");

                entity.Property(e => e.CSumagua)
                    .HasMaxLength(15)
                    .HasColumnName("C_SUMAGUA")
                    .HasComment("Corresponde al suministro de agua.");

                entity.Property(e => e.CSumener)
                    .HasMaxLength(15)
                    .HasColumnName("C_SUMENER")
                    .HasComment("Corresponde al suministro de energia.");

                entity.Property(e => e.CUsucre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("C_USUCRE")
                    .HasComment("Corresponde al usuario que realizó la creación del registro.");

                entity.Property(e => e.CUsuumo)
                    .HasMaxLength(20)
                    .HasColumnName("C_USUUMO")
                    .HasComment("Corresponde al usuario que realizó la última modificación del registro.");

                entity.Property(e => e.CodArea)
                    .HasMaxLength(3)
                    .HasColumnName("COD_AREA")
                    .IsFixedLength(true)
                    .HasComment("Corresponde a identificar de 1: Rural, 2: Urbana.");

                entity.Property(e => e.Codgeo)
                    .HasMaxLength(6)
                    .HasColumnName("CODGEO")
                    .IsFixedLength(true)
                    .HasComment("Corresponde al identificador de la tabla DISTRITOS ");

                entity.Property(e => e.Codooii)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("CODOOII")
                    .IsFixedLength(true)
                    .HasComment("Corresponde al identificador de la tabla DRE_UGEL.");

                entity.Property(e => e.DFeccre)
                    .HasColumnName("D_FECCRE")
                    .HasComment("Corresponde al año, mes, día, hora, minuto y segundo en que se creó el registro");

                entity.Property(e => e.DFecdocu).HasColumnName("D_FECDOCU");

                entity.Property(e => e.DFecieprog).HasColumnName("D_FECIEPROG");

                entity.Property(e => e.DFecreprog).HasColumnName("D_FECREPROG");

                entity.Property(e => e.DFecumo)
                    .HasColumnName("D_FECUMO")
                    .HasComment("Corresponde al día, mes, año, hora, minuto y segundo en que se realizó la última modificación del registro.");

                entity.Property(e => e.DFerenprog).HasColumnName("D_FERENPROG");

                entity.Property(e => e.Marcocd)
                    .HasMaxLength(3)
                    .HasColumnName("MARCOCD")
                    .IsFixedLength(true)
                    .HasComment("Corresponde a dato de padron.");

                entity.Property(e => e.Mcenso)
                    .HasMaxLength(3)
                    .HasColumnName("MCENSO")
                    .IsFixedLength(true)
                    .HasComment("Corresponde a dato de  marco censal de padron.");

                entity.Property(e => e.NCcpplat)
                    .HasColumnType("decimal(20,18)")
                    .HasColumnName("N_CCPPLAT");

                entity.Property(e => e.NCcpplon)
                    .HasColumnType("decimal(20,18)")
                    .HasColumnName("N_CCPPLON");

                entity.Property(e => e.NIdTipcjes)
                    .HasColumnName("N_ID_TIPCJES")
                    .HasComment("Corresponde al código del tipo de continuidad de la jornada escolar ubicado en el Maestro.");

                entity.Property(e => e.NIdTipdepe)
                    .HasColumnName("N_ID_TIPDEPE")
                    .HasComment("Corresponde al código del tipo de dependencia ubicado en el Maestro.");

                entity.Property(e => e.NIdTipeges)
                    .HasColumnName("N_ID_TIPEGES")
                    .HasComment("Corresponde al código del tipo de entidad gestora ubicado en el Maestro.");

                entity.Property(e => e.NIdTipestado).HasColumnName("N_ID_TIPESTADO");

                entity.Property(e => e.NIdTipgest)
                    .HasColumnName("N_ID_TIPGEST")
                    .HasComment("Corresponde al código del tipo de gestion ubicado en el Maestro.");

                entity.Property(e => e.NIdTiplocd)
                    .HasColumnName("N_ID_TIPLOCD")
                    .HasComment("Corresponde al código del tipo de localidad ubicado en el Maestro.");

                entity.Property(e => e.NIdTipprag)
                    .HasColumnName("N_ID_TIPPRAG")
                    .HasComment("Corresponde al código del tipo de proveedor de agua ubicado en el Maestro.");

                entity.Property(e => e.NIdTippren)
                    .HasColumnName("N_ID_TIPPREN")
                    .HasComment("Corresponde al código del tipo de proveedor de energia ubicado en el Maestro.");

                entity.Property(e => e.NIdTipprog)
                    .HasColumnName("N_ID_TIPPROG")
                    .HasComment("Corresponde al código del tipo de programa ubicado en el Maestro.");

                entity.Property(e => e.NIdTipreso).HasColumnName("N_ID_TIPRESO");

                entity.Property(e => e.NIdTipsitu)
                    .HasColumnName("N_ID_TIPSITU")
                    .HasComment("Corresponde al código del tipo de situacion del programa ubicado en el Maestro.");

                entity.Property(e => e.NIdTipturn)
                    .HasColumnName("N_ID_TIPTURN")
                    .HasComment("Corresponde al código del tipo de turno ubicado en el Maestro.");

                entity.Property(e => e.NIdTipvia)
                    .HasColumnName("N_ID_TIPVIA")
                    .HasComment("Corresponde al código del tipo de via ubicado en el Maestro.");

                entity.Property(e => e.NProlat)
                    .HasColumnType("decimal(20,18)")
                    .HasColumnName("N_PROLAT")
                    .HasComment("Corresponde a la latitud del programa.");

                entity.Property(e => e.NProlon)
                    .HasColumnType("decimal(20,18)")
                    .HasColumnName("N_PROLON")
                    .HasComment("Corresponde a la longitud del programa.");

                entity.Property(e => e.NSemclat)
                    .HasColumnType("decimal(20,18)")
                    .HasColumnName("N_SEMCLAT");

                entity.Property(e => e.NSemclon)
                    .HasColumnType("decimal(20,18)")
                    .HasColumnName("N_SEMCLON");

                entity.Property(e => e.Nzoom)
                    .HasColumnType("decimal(11,0)")
                    .HasColumnName("NZOOM")
                    .HasComment("Corresponde a dato de padron");

                entity.Property(e => e.CCodlocal)
                    .HasMaxLength(7)
                    .HasColumnName("C_CODLOCAL")
                    .HasComment("Corresponde a local del programa");
            });

            modelBuilder.Entity<TblRegproSolicitud>(entity =>
            {
                entity.HasKey(e => e.NIdSolicitud)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_regpro_solicitud");

                entity.HasComment("Tabla que almacena la informacion de una solicitud.");

                entity.HasIndex(e => e.Codigo, "FK_RELATIONSHIP_13");

                entity.HasIndex(e => e.IdDistrito, "FK_RELATIONSHIP_18");

                entity.Property(e => e.NIdSolicitud)
                    .HasColumnName("N_ID_SOLICITUD")
                    .HasComment("Corresponde al identificador de la Solicitud.");

                entity.Property(e => e.CCodArea)
                    .HasMaxLength(1)
                    .HasColumnName("C_COD_AREA")
                    .IsFixedLength(true);

                entity.Property(e => e.CCodAreasig)
                    .HasMaxLength(1)
                    .HasColumnName("C_COD_AREASIG")
                    .IsFixedLength(true);

                entity.Property(e => e.CCodccpp)
                    .HasMaxLength(6)
                    .HasColumnName("C_CODCCPP")
                    .HasComment("Corresponde al codigo de centro poblado.");

                entity.Property(e => e.CCodmod)
                    .HasMaxLength(7)
                    .HasColumnName("C_CODMOD")
                    .HasComment("Corresponde al c");

                entity.Property(e => e.CCodsoli)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("C_CODSOLI")
                    .HasComment("Corresponde al codigo de la solicitud.");

                entity.Property(e => e.CCsemc)
                    .HasMaxLength(7)
                    .HasColumnName("C_CSEMC")
                    .IsFixedLength(true)
                    .HasComment("Corresponde al codigo de servicio educativo mas cercano.");

                entity.Property(e => e.CDiretap)
                    .HasMaxLength(15)
                    .HasColumnName("C_DIRETAP")
                    .HasComment("Corresponde a la etapa de la direccion.");

                entity.Property(e => e.CDirlocd)
                    .HasMaxLength(70)
                    .HasColumnName("C_DIRLOCD")
                    .HasComment("Corresponde a la localidad de la direccion.");

                entity.Property(e => e.CDirlote)
                    .HasMaxLength(15)
                    .HasColumnName("C_DIRLOTE")
                    .HasComment("Corresponde al lote de la direccion.");

                entity.Property(e => e.CDirmz)
                    .HasMaxLength(10)
                    .HasColumnName("C_DIRMZ")
                    .HasComment("Corresponde al numero de manzana de la direccion.");

                entity.Property(e => e.CDirnomvia)
                    .HasMaxLength(70)
                    .HasColumnName("C_DIRNOMVIA")
                    .HasComment("Corresponde al nombre de via de la direccion.");

                entity.Property(e => e.CDirnumvia)
                    .HasMaxLength(20)
                    .HasColumnName("C_DIRNUMVIA")
                    .HasComment("Corresponde al numero de via de la direccion.");

                entity.Property(e => e.CDirotro)
                    .HasMaxLength(30)
                    .HasColumnName("C_DIROTRO")
                    .HasComment("Corresponde a otra informacion de la direccion.");

                entity.Property(e => e.CDirrefe)
                    .HasMaxLength(200)
                    .HasColumnName("C_DIRREFE")
                    .HasComment("Corresponde a la referencia de la direccion.");

                entity.Property(e => e.CDirsect)
                    .HasMaxLength(30)
                    .HasColumnName("C_DIRSECT")
                    .HasComment("Corresponde al sector de la direccion.");

                entity.Property(e => e.CDirzona)
                    .HasMaxLength(15)
                    .HasColumnName("C_DIRZONA")
                    .HasComment("Corresponde a la zona de la direccion.");

                entity.Property(e => e.CEstado)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("C_ESTADO")
                    .HasComment("Corresponde al código de estado del dato maestro: ACTIV - Activo, INACT - Inactivo.\n            ");

                entity.Property(e => e.CGeohash)
                    .HasMaxLength(10)
                    .HasColumnName("C_GEOHASH")
                    .IsFixedLength(true);

                entity.Property(e => e.CIndult)
                    .HasMaxLength(1)
                    .HasColumnName("C_INDULT")
                    .IsFixedLength(true);

                entity.Property(e => e.CNomccpp)
                    .HasMaxLength(60)
                    .HasColumnName("C_NOMCCPP")
                    .HasComment("Corresponde al nombre del centro poblado.");

                entity.Property(e => e.CNomprog)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("C_NOMPROG")
                    .HasComment("Corresponde al nombre del programa.");

                entity.Property(e => e.CNomsemc)
                    .HasMaxLength(90)
                    .HasColumnName("C_NOMSEMC")
                    .HasComment("Corresponde al nombre del servicio educativo mas cercano.");

                entity.Property(e => e.CNomusuenv)
                    .HasMaxLength(50)
                    .HasColumnName("C_NOMUSUENV")
                    .HasComment("Corresponde al nombre completo del usuario que realizo el envio de la solicitud.");

                entity.Property(e => e.CNomusumodi)
                    .HasMaxLength(50)
                    .HasColumnName("C_NOMUSUMODI")
                    .HasComment("Corresponde al nombre completo del usuario que realizo la modificacion de la solicitud.");

                entity.Property(e => e.CNomusurevi)
                    .HasMaxLength(50)
                    .HasColumnName("C_NOMUSUREVI")
                    .HasComment("Corresponde al nombre completo del usuario que realizo la revision de la solicitud.");

                entity.Property(e => e.CNomusurevs)
                    .HasMaxLength(50)
                    .HasColumnName("C_NOMUSUREVS")
                    .HasComment("Corresponde al nombre completo del usuario que realizo la revision sig de la solicitud.");

                entity.Property(e => e.COtrpragua)
                    .HasMaxLength(50)
                    .HasColumnName("C_OTRPRAGUA")
                    .HasComment("Corresponde a la descripcion de otro proveedor de agua.");

                entity.Property(e => e.COtrprener)
                    .HasMaxLength(50)
                    .HasColumnName("C_OTRPRENER")
                    .HasComment("Corresponde a la descripcion de otro proveedor de energia.");

                entity.Property(e => e.CSumagua)
                    .HasMaxLength(15)
                    .HasColumnName("C_SUMAGUA")
                    .HasComment("Corresponde al suministro de agua.");

                entity.Property(e => e.CSumener)
                    .HasMaxLength(15)
                    .HasColumnName("C_SUMENER")
                    .HasComment("Corresponde al suministro de energia.");

                entity.Property(e => e.CUsucre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("C_USUCRE")
                    .HasComment("Corresponde al usuario que realizó la creación del registro.");

                entity.Property(e => e.CUsuenv)
                    .HasMaxLength(20)
                    .HasColumnName("C_USUENV")
                    .HasComment("Corresponde al usuario que realizó el envio de la solicitud.");

                entity.Property(e => e.CUsumodi)
                    .HasMaxLength(20)
                    .HasColumnName("C_USUMODI")
                    .HasComment("Corresponde al usuario que realizó la modificacion de la solicitud.");

                entity.Property(e => e.CUsurevi)
                    .HasMaxLength(20)
                    .HasColumnName("C_USUREVI")
                    .HasComment("Corresponde al usuario que realizó la revision de la solicitud.");

                entity.Property(e => e.CUsurevs)
                    .HasMaxLength(20)
                    .HasColumnName("C_USUREVS")
                    .HasComment("Corresponde al usuario que realizó la revision sig de la solicitud.");

                entity.Property(e => e.CUsuumo)
                    .HasMaxLength(20)
                    .HasColumnName("C_USUUMO")
                    .HasComment("Corresponde al usuario que realizó la última modificación del registro.");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(6)
                    .HasColumnName("CODIGO")
                    .IsFixedLength(true);

                entity.Property(e => e.DFecaten)
                    .HasColumnName("D_FECATEN")
                    .HasComment("Corresponde al año, mes, día, hora, minuto y segundo en que se realizo la atencion la solicitud.");

                entity.Property(e => e.DFeccre)
                    .HasColumnName("D_FECCRE")
                    .HasComment("Corresponde al año, mes, día, hora, minuto y segundo en que se creó el registro");

                entity.Property(e => e.DFecenv)
                    .HasColumnName("D_FECENV")
                    .HasComment("Corresponde al año, mes, día, hora, minuto y segundo en que se envio la solicitud.");

                entity.Property(e => e.DFecmodi)
                    .HasColumnName("D_FECMODI")
                    .HasComment("Corresponde al año, mes, día, hora, minuto y segundo en que se modifico la solicitud.");

                entity.Property(e => e.DFecrevi)
                    .HasColumnName("D_FECREVI")
                    .HasComment("Corresponde al año, mes, día, hora, minuto y segundo en que se reviso la solicitud.");

                entity.Property(e => e.DFecrevs)
                    .HasColumnName("D_FECREVS")
                    .HasComment("Corresponde al año, mes, día, hora, minuto y segundo en que se realizo la revision sig la solicitud.");

                entity.Property(e => e.DFecumo)
                    .HasColumnName("D_FECUMO")
                    .HasComment("Corresponde al día, mes, año, hora, minuto y segundo en que se realizó la última modificación del registro.");

                entity.Property(e => e.IdDistrito)
                    .HasMaxLength(6)
                    .HasColumnName("ID_DISTRITO")
                    .IsFixedLength(true);

                entity.Property(e => e.NCcpplat)
                    .HasColumnType("decimal(20,18)")
                    .HasColumnName("N_CCPPLAT")
                    .HasComment("Corresponde a la latitud del centro poblado.");

                entity.Property(e => e.NCcpplon)
                    .HasColumnType("decimal(20,18)")
                    .HasColumnName("N_CCPPLON")
                    .HasComment("Corresponde a la longitud del centro poblado.");

                entity.Property(e => e.NIdTipcjes)
                    .HasColumnName("N_ID_TIPCJES")
                    .HasComment("Corresponde al código del tipo de continuidad de la jornada escolar ubicado en el Maestro.");

                entity.Property(e => e.NIdTipdepe)
                    .HasColumnName("N_ID_TIPDEPE")
                    .HasComment("Corresponde al código del tipo de dependencia ubicado en el Maestro.");

                entity.Property(e => e.NIdTipeges)
                    .HasColumnName("N_ID_TIPEGES")
                    .HasComment("Corresponde al código del tipo de entidad gestora ubicado en el Maestro.");

                entity.Property(e => e.NIdTipgest)
                    .HasColumnName("N_ID_TIPGEST")
                    .HasComment("Corresponde al código del tipo de gestion ubicado en el Maestro.");

                entity.Property(e => e.NIdTiplocd)
                    .HasColumnName("N_ID_TIPLOCD")
                    .HasComment("Corresponde al código del tipo de localidad ubicado en el Maestro.");

                entity.Property(e => e.NIdTipoperiodo).HasColumnName("N_ID_TIPOPERIODO");

                entity.Property(e => e.NIdTipprag)
                    .HasColumnName("N_ID_TIPPRAG")
                    .HasComment("Corresponde al código del tipo de proveedor de agua ubicado en el Maestro.");

                entity.Property(e => e.NIdTippren)
                    .HasColumnName("N_ID_TIPPREN")
                    .HasComment("Corresponde al código del tipo de proveedor de energia ubicado en el Maestro.");

                entity.Property(e => e.NIdTipprog)
                    .HasColumnName("N_ID_TIPPROG")
                    .HasComment("Corresponde al código del tipo de programa ubicado en el Maestro.");

                entity.Property(e => e.NIdTipsitu)
                    .HasColumnName("N_ID_TIPSITU")
                    .HasComment("Corresponde al c");

                entity.Property(e => e.NIdTipsituprog).HasColumnName("N_ID_TIPSITUPROG");

                entity.Property(e => e.NIdTipsiturev).HasColumnName("N_ID_TIPSITUREV");

                entity.Property(e => e.NIdTipsiturevsig).HasColumnName("N_ID_TIPSITUREVSIG");

                entity.Property(e => e.NIdTipsoli)
                    .HasColumnName("N_ID_TIPSOLI")
                    .HasComment("Corresponde al código del tipo de solicitud ubicado en el Maestro.");

                entity.Property(e => e.NIdTipturn)
                    .HasColumnName("N_ID_TIPTURN")
                    .HasComment("Corresponde al código del tipo de turno ubicado en el Maestro.");

                entity.Property(e => e.NIdTipvia)
                    .HasColumnName("N_ID_TIPVIA")
                    .HasComment("Corresponde al código del tipo de via ubicado en el Maestro.");

                entity.Property(e => e.NProlat)
                    .HasColumnType("decimal(20,18)")
                    .HasColumnName("N_PROLAT")
                    .HasComment("Corresponde a la latitud del programa.");

                entity.Property(e => e.NProlon)
                    .HasColumnType("decimal(20,18)")
                    .HasColumnName("N_PROLON")
                    .HasComment("Corresponde a la longitud del programa.");

                entity.Property(e => e.NSemclat)
                    .HasColumnType("decimal(20,18)")
                    .HasColumnName("N_SEMCLAT")
                    .HasComment("Corresponde a la latitud del servicio educativo mas cercano.");

                entity.Property(e => e.NSemclon)
                    .HasColumnType("decimal(20,18)")
                    .HasColumnName("N_SEMCLON")
                    .HasComment("Corresponde a la longitud del servicio educativo mas cercano.");

                entity.HasOne(d => d.CodigoNavigation)
                    .WithMany(p => p.TblRegproSolicituds)
                    .HasForeignKey(d => d.Codigo)
                    .HasConstraintName("FK_RELATIONSHIP_13");

                entity.HasOne(d => d.IdDistritoNavigation)
                    .WithMany(p => p.TblRegproSolicituds)
                    .HasForeignKey(d => d.IdDistrito)
                    .HasConstraintName("FK_RELATIONSHIP_18");
            });

            modelBuilder.Entity<Temppronoei>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("temppronoei");

                entity.Property(e => e.Tmpcodmod)
                    .HasMaxLength(21)
                    .HasColumnName("tmpcodmod");

                entity.Property(e => e.Tmpestrategia)
                    .HasMaxLength(6)
                    .HasColumnName("tmpestrategia");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
