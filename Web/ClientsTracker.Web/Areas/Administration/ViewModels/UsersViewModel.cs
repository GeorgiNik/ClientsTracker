namespace ClientsTracker.Web.Areas.Administration.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using ClientsTracker.Data.Models;
    using ClientsTracker.Web.App_GlobalResources;
    using ClientsTracker.Web.Infrastructure.Mapping;

    public class UsersViewModel : IMapFrom<ApplicationUser>, IHaveCustomMappings, IMapTo<ApplicationUser>
    {
        public string Id { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Resources))]
        public string AuthorName { get; set; }

        [Display(Name = "Username", ResourceType = typeof(Resources))]
        public string UserName { get; set; }

        [Display(Name = "Email", ResourceType = typeof(Resources))]
        public string Email { get; set; }

        public bool IsAdmin { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<ApplicationUser, UsersViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id));
            configuration.CreateMap<ApplicationUser, UsersViewModel>()
                .ForMember(x => x.IsAdmin, opt => opt.MapFrom(x => x.Roles.Count > 0));
        }
    }
}