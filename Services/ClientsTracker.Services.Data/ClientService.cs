namespace ClientsTracker.Services.Data
{
    using System.Linq;
    using AutoMapper;
    using ClientsTracker.Data;
    using ClientsTracker.Data.Common;
    using ClientsTracker.Data.Models;
    using ClientsTracker.Web.Infrastructure.Clients;
    using ClientsTracker.Web.Infrastructure.Mapping;

    public class ClientService : IClientService
    {
        private IDeletableRepository<Client> clients;

        public ClientService(IDeletableRepository<Client> clients)
        {
            this.clients = clients;
        }

        public IQueryable<ClientVM> GetAll()
        {
            return this.clients.GetAll().To<ClientVM>();
        }

        public ClientVM Get(int id)
        {
            return Mapper.Map<ClientVM>(this.clients.Get(id));
        }

        public ClientVM Create(ClientVM vm)
        {
            var client = Mapper.Map<Client>(vm);

            this.clients.Add(client);
            this.clients.SaveChanges();

            vm.Id = client.Id;
            return vm;
        }

        public void Update(ClientVM vm)
        {
            var client = this.clients.Get(vm.Id);
            var updated = Mapper.Map(vm, client);

            this.clients.Update(updated);
            this.clients.SaveChanges();
        }

        public void Delete(int id)
        {
            this.clients.Delete(id);
            this.clients.SaveChanges();
        }
    }
}