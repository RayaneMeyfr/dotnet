using MicroServiceTransport.Application.Dto;

namespace MicroServiceTransport.Application.Service
{
    public interface IService<Treceive, TSend, TsendEmission>
    {
        TSend Create(Treceive receive);
        TSend Update(Treceive receive, int id);
        bool Delete(int id);
        TSend GetById(int id);
        List<TSend> GetAll();
        TsendEmission GetByIdEmission(int id);
        List<TsendEmission> GetAllEmission();
    }
}
