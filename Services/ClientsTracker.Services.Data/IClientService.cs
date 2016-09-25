namespace ClientsTracker.Services.Data
{
    using System.Linq;

    public interface IClientService
    {
        IQueryable<ClientVM> GetAll();

        ClientVM Get();

        ClientVM Create();

        void Update();

        void Delete();
    }
}