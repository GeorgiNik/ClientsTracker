namespace ClientsTracker.Web.Infrastructure.Users
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using ClientsTracker.Common;
    using ClientsTracker.Data.Models;
    using ClientsTracker.Web.Infrastructure.Mapping;

    public class UsersVM : IMapFrom<ApplicationUser>, IHaveCustomMappings, IMapTo<ApplicationUser>
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
            configuration.CreateMap<ApplicationUser, UsersVM>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id));
            configuration.CreateMap<ApplicationUser, UsersVM>()
                .ForMember(x => x.IsAdmin, opt => opt.MapFrom(x => x.Roles.Count > 0));
        }
    }
}