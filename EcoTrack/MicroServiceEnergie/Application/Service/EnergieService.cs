using MicroServiceEnergie.Application.Dto;
using MicroServiceEnergie.Domain.Entity;
using MicroServiceEnergie.Domain.Ports;

namespace MicroServiceEnergie.Application.Service
{
    public class EnergieService : IService<EnergieDtoReceive, EnergieDtoSend>
    {
        private readonly IRepository<Energie> repository;

        public EnergieService(IRepository<Energie> repository)
        {
            this.repository = repository;
        }

        public EnergieDtoSend Create(EnergieDtoReceive receive)
        {
            return EntityToDto(repository.Create(DtoToEntity(receive, null)));
        }

        public bool Delete(int id)
        {
            return repository.Delete(id);
        }

        public List<EnergieDtoSend> GetAll()
        {
            List<Energie> energies = repository.GetAll();
            List<EnergieDtoSend> energieDtoSends = new List<EnergieDtoSend>();
            foreach (var energie in energies)
            {
                energieDtoSends.Add(EntityToDto(energie));
            }

            return energieDtoSends;
        }

        public EnergieDtoSend GetById(int id)
        {
            Energie energie = repository.GetById(id);
            if (energie == null)
            {
                return null;
            }

            return EntityToDto(energie);
        }

        public EnergieDtoSend Update(EnergieDtoReceive receive, int id)
        {
            return EntityToDto(repository.Update(DtoToEntity(receive, id)));
        }

        private Energie DtoToEntity(EnergieDtoReceive receive, int? id)
        {
            Energie energie = new Energie()
            {
               Source = receive.Source,
               CosomationKWh = receive.CosomationKWh,
               Date =  receive.Date,
            };

            if (id != null)
            {
                energie.Id = (int) id;
            }

            return energie;
        }

        private EnergieDtoSend EntityToDto(Energie energie)
        {
            return new EnergieDtoSend()
            {
                Id = energie.Id,
                Source = energie.Source.ToString(),
                CosomationKWh = energie.CosomationKWh,
                Date = energie.Date,
            };
        }
    }
}
