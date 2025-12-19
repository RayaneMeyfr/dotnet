using Dashboard.Application.Dto;
using Dashboard.Application.Rest;
using System.Net.Http;
using System.Text.Json;

namespace Dashboard.Application.Service
{
    public class DashboardService
    {
        private RestClient<EnergieDtoSend> _restClientEnergie;
        private RestClient<DechetDtoSend> _restClientDechet;
        private RestClient<TransportDtoSend> _restClientTransport;


        public DashboardService()
        {
            _restClientEnergie = new RestClient<EnergieDtoSend>("http://localhost:5038");
            _restClientDechet = new RestClient<DechetDtoSend>("http://localhost:5252");
            _restClientTransport = new RestClient<TransportDtoSend>("http://localhost:5143");
        }

        public async Task<DashboardDtoReceive> GetDashboardAsync()
        {
            List<EnergieDtoSend> energies = await _restClientEnergie.GetListRequest("/api/Energie");

            List<DechetDtoSend> dechets = await _restClientDechet.GetListRequest("/api/Dechet");

            List<TransportDtoSend> transports = await _restClientTransport.GetListRequest("/api/Transport/emissions");

            int consommationEnergetiqueTotale = energies.Sum(e => e.CosomationKWh);

            int quantiteDechetsTotale = dechets.Sum(d => d.QuantiteKg);

            float emissionsCO2Globales = transports.Sum(t => t.EmissionCO2);


            return new DashboardDtoReceive
            {
                ConsommationEnergetiqueTotale = consommationEnergetiqueTotale,
                QuantiteDechetsTotale = quantiteDechetsTotale,
                EmissionsCO2Globales = emissionsCO2Globales
            };
        }

    }
}
