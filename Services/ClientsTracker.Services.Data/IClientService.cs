namespace ClientsTracker.Services.Data
{
    using System.Linq;
    using ClientsTracker.Web.Infrastructure.Clients;

    public interface IClientService
    {
        IQueryable<ClientVM> GetAll();

        ClientVM Get(int id);

        ClientVM Create(ClientVM vm);

        void Update(ClientVM vm);

        void Delete(int id);
    }
}