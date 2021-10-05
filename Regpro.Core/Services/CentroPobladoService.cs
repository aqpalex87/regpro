using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Regpro.Core.CustomEntities;
using Regpro.Core.DTOs;
using Regpro.Core.Entities;
using Regpro.Core.Exceptions;
using Regpro.Core.Interfaces;
using Regpro.Core.QueryFilters;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Regpro.Core.Services
{
    public class CentroPobladoService : ICentroPobladoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public CentroPobladoService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        public List<CentroPobladoDto> GetAllCentrosPoblado(string ubigeo)
        {

            var rows = GetAllCentrosPoblados(ubigeo);
            var centroPoblado = new List<CentroPobladoDto>();
            foreach (var item in rows)
            {
                var centro = new CentroPobladoDto();
                centro.UBIGEO = item.CP101;
                centro.CODCP = item.CP102;
                centro.DENOMINACION = item.CP103;
                centro.LONGITUD_DEC = Convert.ToDouble(item.CP104);
                centro.LATITUD_DEC = Convert.ToDouble(item.CP105);
                centro.AREA = item.CP106;
                centro.AREA_SIG = item.CP107;
                centro.NOMB_UBIGEO = item.CP108;
                centroPoblado.Add(centro);

            }

            return centroPoblado;
        }

        public List<Rows> GetAllCentrosPoblados(string ubigeo)
        {
            try
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    DateParseHandling = DateParseHandling.None,
                };

                var result = _download_serialized_json_data("http://sigmed.minedu.gob.pe/servicios/rest/service/restsig.svc/ccpp5k?UBIGEO=" + ubigeo);
                result = result.Substring(1, result.Length - 2).Replace(@"\", "").Replace("/", "");

                var json = JsonConvert.DeserializeObject<populated_centers>(result, settings);
                var rows = json.Rows;

                return rows;
            }
            catch (Exception ex)
            { throw ex; }
        }

        private string _download_serialized_json_data(string url)
        {
            using (var w = new WebClient())
            {
                return w.DownloadString(url);
            }
        }
        public class populated_centers
        {
            public List<Rows> Rows { get; set; }

        }
        public class Rows
        {
            [JsonProperty("UBIGEO")]
            public string CP101 { get; set; }
            [JsonProperty("CODCP")]
            public string CP102 { get; set; }
            [JsonProperty("DENOMINACION")]
            public string CP103 { get; set; }
            [JsonProperty("LONGITUD_DEC")]
            public string CP104 { get; set; }
            [JsonProperty("LATITUD_DEC")]
            public string CP105 { get; set; }
            [JsonProperty("AREA")]
            public string CP106 { get; set; }
            [JsonProperty("AREA_SIG")]
            public string CP107 { get; set; }
            [JsonProperty("NOMB_UBIGEO")]
            public string CP108 { get; set; }
            public int Count { get; set; }
            public int Start { get; set; }
            public int Length { get; set; }
            public int Column { get; set; }
            public string Direction { get; set; }
        }

    }
}
