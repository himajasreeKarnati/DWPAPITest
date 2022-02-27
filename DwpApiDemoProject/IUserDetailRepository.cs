using DwpApiDemoProject.Model;
using System.Collections.Generic;

namespace DwpApiDemoProject
{
    public interface IUserDetailRepository
    {

        List<UserDetail> UserDetails { get; set; }
        List<UserDetail> UserDetailsForLondon { get; set; }

        IEnumerable<UserDetail> GetAll();

        IEnumerable<UserDetail> GetUsersForLondon(string city);

        IEnumerable<UserDetail> GetUsersFromCoordinates(List<UserDetail> source, List<UserDetail> destination);


    }
}
