using Microsoft.AspNetCore.Http;
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
using System.Transactions;

namespace Regpro.Core.Services
{
    public class TblRegproSolicitudService : ITblRegproSolicitudService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITblRegproDocumentoService _tblRegproDocumentoService;
        private readonly ITblRegproArchivoService _tblRegproArchivoService;
        private readonly IFileService _fileService;
        private readonly IDetRegproSolDocService _detRegproSolDoc;

        public TblRegproSolicitudService(IUnitOfWork unitOfWork,
                                         ITblRegproDocumentoService tblRegproDocumentoService,
                                         ITblRegproArchivoService tblRegproArchivoService,
                                         IFileService fileService,
                                         IDetRegproSolDocService detRegproSolDoc)
        {
            _unitOfWork = unitOfWork;
            _tblRegproDocumentoService = tblRegproDocumentoService;
            _tblRegproArchivoService = tblRegproArchivoService;
            _fileService = fileService;
            _detRegproSolDoc = detRegproSolDoc;
        }
        public async Task<TblRegproSolicitud> GetFindRequest(long NIdSolicitud)
        {
            return await _unitOfWork.TblRegproSolicitudRepository.GetFindRequest(NIdSolicitud);
        }

        public async Task InsertSolicitud(TblRegproSolicitud solicitud, List<IFormFile> files, IFormFile croquis)
        {

            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                solicitud.CCodsoli = DateTime.Now.ToString("yyyyMMddHHmmssFFF");
                solicitud.NIdTipsitu = 273;
                solicitud.DFecenv = DateTime.Now;
                solicitud.NIdTipsituprog = 294;
                solicitud.NIdTipsiturev = 311;
                solicitud.NIdTipsiturevsig = 311;
                solicitud.NIdTipoperiodo = 335;//consultar segun el año en maestro
                await _unitOfWork.TblRegproSolicitudRepository.Add(solicitud);
                await _unitOfWork.SaveChangesAsync();
                var CCoddocu = solicitud.Codigo + "-" + solicitud.Documento.NIdTipdocu + "-" + solicitud.Documento.CNrodoc + "-" + Convert.ToDateTime(solicitud.Documento.DFecdocu).ToString("ddMMyyyy");

                var docConIgualCodDoc = await _unitOfWork.TblRegproDocumentoRepository.GetAllDocumentoByCCoddocu(CCoddocu);

                //Inserta archivos
                var documentoSustentacion = new TblRegproDocumento();//solicitud.Documento;
                documentoSustentacion.CNrodoc = solicitud.Documento.CNrodoc;
                documentoSustentacion.DFecdocu = solicitud.Documento.DFecdocu;
                documentoSustentacion.DFeccre = solicitud.Documento.DFeccre;
                documentoSustentacion.CUsucre = solicitud.CUsucre;
                documentoSustentacion.DFecumo = solicitud.Documento.DFecumo;
                documentoSustentacion.CUsuumo = solicitud.Documento.CUsuumo;
                documentoSustentacion.Codooii = solicitud.Documento.Codooii;
                documentoSustentacion.NIdTipreso = solicitud.Documento.NIdTipreso;
                documentoSustentacion.CEstado = "1";
                documentoSustentacion.NIdTipdocu = 280;
                documentoSustentacion.CCoddocu = CCoddocu;
                await _tblRegproDocumentoService.InsertDocumento(documentoSustentacion);
                await _unitOfWork.SaveChangesAsync();
                await _detRegproSolDoc.InsertDetRegproSolDoc(new DetRegproSolDoc() { NIdSolicitud = solicitud.NIdSolicitud, NIdDocumento = documentoSustentacion.NIdDocumento, DFeccre = DateTime.Now, CUsucre = solicitud.CUsucre, CEstado = "1" });
                await _unitOfWork.SaveChangesAsync();
                int loop = 0;
                foreach (var file in files ?? Enumerable.Empty<IFormFile>())
                {
                    if (file != null)
                    {
                        loop++;
                        TblRegproArchivo archivo = new TblRegproArchivo();
                        archivo.NIdDocumento = documentoSustentacion.NIdDocumento;
                        archivo.CUsucre = solicitud.CUsucre;
                        archivo.CEstado = "1";
                        string nombreArchivo = "";
                        nombreArchivo = CCoddocu + "-" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "-" + loop;
                        archivo.CNomarch = nombreArchivo + ".pdf";
                        archivo.CCodarch = nombreArchivo;
                        if (docConIgualCodDoc == null)
                            await _fileService.UploadFile(file, archivo.CNomarch);
                        await _tblRegproArchivoService.InsertArchivo(archivo);
                        await _unitOfWork.SaveChangesAsync();
                    }

                }
                //inserta arhivo croquis
                var documentoCroquis = solicitud.Documento;
                documentoCroquis.CNrodoc = solicitud.Documento.CNrodoc;
                documentoCroquis.DFecdocu = solicitud.Documento.DFecdocu;
                documentoCroquis.DFeccre = solicitud.Documento.DFeccre;
                documentoCroquis.CUsucre = solicitud.CUsucre;
                documentoCroquis.DFecumo = solicitud.Documento.DFecumo;
                documentoCroquis.CUsuumo = solicitud.Documento.CUsuumo;
                documentoCroquis.Codooii = solicitud.Documento.Codooii;
                documentoCroquis.NIdTipreso = solicitud.Documento.NIdTipreso;
                documentoCroquis.CEstado = "1";
                documentoCroquis.CCoddocu = "CROQUIS";
                documentoCroquis.NIdTipdocu = 281;
                await _tblRegproDocumentoService.InsertDocumento(documentoCroquis);
                await _unitOfWork.SaveChangesAsync();
                await _detRegproSolDoc.InsertDetRegproSolDoc(new DetRegproSolDoc() { NIdSolicitud = solicitud.NIdSolicitud, NIdDocumento = documentoCroquis.NIdDocumento, DFeccre = DateTime.Now, CUsucre = solicitud.CUsucre, CEstado = "1" });
                await _unitOfWork.SaveChangesAsync();
                if (croquis != null)
                {
                    TblRegproArchivo archivo = new TblRegproArchivo();
                    archivo.NIdDocumento = documentoCroquis.NIdDocumento;
                    archivo.CUsucre = solicitud.CUsucre;
                    archivo.CEstado = "1";
                    string nombreArchivo = "";
                    nombreArchivo = CCoddocu + "-" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "-" + "croquis";
                    archivo.CNomarch = nombreArchivo + ".pdf";
                    archivo.CCodarch = nombreArchivo;
                    await _fileService.UploadFile(croquis, archivo.CNomarch);
                    await _tblRegproArchivoService.InsertArchivo(archivo);
                    await _unitOfWork.SaveChangesAsync();
                }

                scope.Complete();
            }
        }
    }
}
