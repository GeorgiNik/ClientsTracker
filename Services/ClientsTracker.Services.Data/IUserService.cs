namespace ClientsTracker.Services.Data
{
    using System.Linq;

    using ClientsTracker.Data.Models;

    public interface IUserService
    {
        int GetUsersCount();

        void MakeAdmin(string id);

        void RemoveAdmin(string id);

        void Update(ApplicationUser user);

        void Remove(ApplicationUser user);

        IQueryable<ApplicationUser> All();
    }
}