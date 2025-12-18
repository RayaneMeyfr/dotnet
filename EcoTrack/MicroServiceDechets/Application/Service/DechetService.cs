using MicroServiceDechets.Application.Dto;
using MicroServiceDechets.Domain.Entity;
using MicroServiceDechets.Domain.Ports;

namespace MicroServiceDechets.Application.Service
{
    public class DechetService : IService<DechetDtoReceive, DechetDtoSend>
    {
        private readonly IRepository<Dechet> repository;

        public DechetService(IRepository<Dechet> repository)
        {
            this.repository = repository;
        }

        public DechetDtoSend Create(DechetDtoReceive receive)
        {
            return EntityToDto(repository.Create(DtoToEntity(receive, null)));
        }

        public bool Delete(int id)
        {
            return repository.Delete(id);
        }

        public List<DechetDtoSend> GetAll()
        {
            List<Dechet> dechets = repository.GetAll();
            List<DechetDtoSend> dechetDtoSends = new List<DechetDtoSend>();
            foreach (var dechet in dechets)
            {
                dechetDtoSends.Add(EntityToDto(dechet));
            }

            return dechetDtoSends;
        }

        public DechetDtoSend GetById(int id)
        {
            Dechet dechet = repository.GetById(id);
            if (dechet == null)
            {
                return null;
            }

            return EntityToDto(dechet);
        }

        public DechetDtoSend Update(DechetDtoReceive receive, int id)
        {
            return EntityToDto(repository.Update(DtoToEntity(receive, id)));
        }

        private Dechet DtoToEntity(DechetDtoReceive receive, int? id)
        {
            Dechet dechet = new Dechet()
            {
                Type = receive.Type,
                QuantiteKg = receive.QuantiteKg,
                TauxRecyclageKg = receive.TauxRecyclageKg
            };

            if (id != null)
            {
                dechet.Id = (int)id;
            }

            return dechet;
        }

        private DechetDtoSend EntityToDto(Dechet dechet)
        {
            return new DechetDtoSend()
            {
                Id = dechet.Id,
                Type = dechet.Type.ToString(),
                QuantiteKg = dechet.QuantiteKg,
                TauxRecyclageKg = dechet.TauxRecyclageKg,
            };
        }
    }
}
