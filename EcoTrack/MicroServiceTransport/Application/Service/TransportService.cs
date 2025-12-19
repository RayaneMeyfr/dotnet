using MicroServiceTransport.Application.Dto;
using MicroServiceTransport.Domain.Entity;
using MicroServiceTransport.Domain.Entity.Enum;
using MicroServiceTransport.Domain.Ports;

namespace MicroServiceTransport.Application.Service
{
    public class TransportService : IService<TransportDtoReceive, TransportDtoSend>
    {
        private readonly IRepository<Transport> repository;

        public TransportService(IRepository<Transport> repository)
        {
            this.repository = repository;
        }

        public TransportDtoSend Create(TransportDtoReceive receive)
        {
            return EntityToDto(repository.Create(DtoToEntity(receive, null)));
        }

        public bool Delete(int id)
        {
            return repository.Delete(id);
        }

        public List<TransportDtoSend> GetAll()
        {
            List<Transport> transports = repository.GetAll();
            List<TransportDtoSend> transportDtoSends = new List<TransportDtoSend>();
            foreach (var transport in transports)
            {
                transportDtoSends.Add(EntityToDto(transport));
            }

            return transportDtoSends;
        }

        public TransportDtoSend GetById(int id)
        {
            Transport transport = repository.GetById(id);
            if (transport == null)
            {
                return null;
            }

            return EntityToDto(transport);
        }

        public TransportDtoSendEmission GetByIdEmission(int id)
        {
            Transport transport = repository.GetById(id);
            if (transport == null)
            {
                return null;
            }

            return EntityToDtoEmission(transport);
        }

        public TransportDtoSend Update(TransportDtoReceive receive, int id)
        {
            return EntityToDto(repository.Update(DtoToEntity(receive, id)));
        }

        private Transport DtoToEntity(TransportDtoReceive receive, int? id)
        {
            Transport transport = new Transport()
            {
                Mode = receive.Mode,
                DistanceKm = receive.DistanceKm,
                FacteurEmission = receive.Mode switch
                {
                    ModeTransport.Voiture => 120,
                    ModeTransport.Bus => 80,
                    ModeTransport.Train => 30,
                    ModeTransport.Velo => 0,
                    _ => 0
                }
            };

            if (id != null)
            {
                transport.Id = (int)id;
            }

            return transport;
        }

        private TransportDtoSend EntityToDto(Transport transport)
        {
            return new TransportDtoSend()
            {
                Id = transport.Id,
                Mode = transport.Mode.ToString(),
                DistanceKm = transport.DistanceKm,
                FacteurEmission = transport.FacteurEmission,
            };
        }

        private TransportDtoSendEmission EntityToDtoEmission(Transport transport)
        {
            return new TransportDtoSendEmission()
            {
                Id = transport.Id,
                Mode = transport.Mode.ToString(),
                DistanceKm = transport.DistanceKm,
                FacteurEmission = transport.FacteurEmission,
                EmissionCO2 = transport.EmissionCO2
            };
        }
    }
}
