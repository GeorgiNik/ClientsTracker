namespace ClientsTracker.Web.Infrastructure.Clients
{
    using ClientsTracker.Data;
    using ClientsTracker.Data.Models;
    using ClientsTracker.Web.Infrastructure.Mapping;

    public class ClientVM : IMapFrom<Client>, IMapTo<Client>
    {
        public int Id { get; set; }

        public string Priority { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public string ContactPerson { get; set; }

        public string Title { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string WebSiteUrl { get; set; }

        public string RegionsOfActivity { get; set; }

        public string Type { get; set; }

        public string Activity { get; set; }

        public string CustomerCountries { get; set; }

        public string ConversationAbout { get; set; }

        public string Todo { get; set; }

        public string Expectations { get; set; }

        public string OrdersQuantity { get; set; }
    }
}