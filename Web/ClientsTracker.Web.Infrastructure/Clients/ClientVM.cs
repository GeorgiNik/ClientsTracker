namespace ClientsTracker.Web.Infrastructure.Clients
{
    using System.ComponentModel.DataAnnotations;
    using ClientsTracker.Common;
    using ClientsTracker.Data;
    using ClientsTracker.Data.Models;
    using ClientsTracker.Web.Infrastructure.Mapping;

    public class ClientVM : IMapFrom<Client>, IMapTo<Client>
    {
        public int Id { get; set; }

        [Display(Name = "Priority", ResourceType = typeof(Resources))]
        public string Priority { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Resources))]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Country", ResourceType = typeof(Resources))]
        public string Country { get; set; }

        [Display(Name = "ContactPerson", ResourceType = typeof(Resources))]
        public string ContactPerson { get; set; }

        [Display(Name = "Title", ResourceType = typeof(Resources))]
        public string Title { get; set; }

        [Display(Name = "Email", ResourceType = typeof(Resources))]
        public string Email { get; set; }

        [Display(Name = "PhoneNumber", ResourceType = typeof(Resources))]
        public string PhoneNumber { get; set; }

        [Display(Name = "WebSiteUrl", ResourceType = typeof(Resources))]
        public string WebSiteUrl { get; set; }

        [Display(Name = "RegionsOfActivity", ResourceType = typeof(Resources))]
        public string RegionsOfActivity { get; set; }

        [Display(Name = "Type", ResourceType = typeof(Resources))]
        public string Type { get; set; }

        [Display(Name = "Activity", ResourceType = typeof(Resources))]
        public string Activity { get; set; }

        [Display(Name = "CustomerCountries", ResourceType = typeof(Resources))]
        public string CustomerCountries { get; set; }

        [Display(Name = "ConversationAbout", ResourceType = typeof(Resources))]
        public string ConversationAbout { get; set; }

        [Display(Name = "Todo", ResourceType = typeof(Resources))]
        public string Todo { get; set; }

        [Display(Name = "Expectations", ResourceType = typeof(Resources))]
        public string Expectations { get; set; }

        [Display(Name = "OrdersQuantity", ResourceType = typeof(Resources))]
        public string OrdersQuantity { get; set; }
    }
}