using DwpApiDemoProject.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DwpApiDemoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserDetailRepository _userDetailRepository;

        public UserController(IUserDetailRepository repository)
        {
            _userDetailRepository = repository;
        }
        

        [HttpGet]
        [Route("city")]
        public IEnumerable<UserDetail> GetUsersByCity(string city = "London")
        {
            _userDetailRepository.UserDetailsForLondon = _userDetailRepository.GetUsersForLondon(city).ToList();
            return _userDetailRepository.UserDetailsForLondon;
        }

        [HttpGet]
        [Route("coordinates")]
        public IEnumerable<UserDetail> GetUsersByCoordinates(string city = "London")
        {
            var getUsers = _userDetailRepository.UserDetails;
            _userDetailRepository.UserDetailsForLondon = _userDetailRepository.GetUsersForLondon(city).ToList();
            var getLondonUsers = _userDetailRepository.UserDetailsForLondon;
            
            return _userDetailRepository.GetUsersFromCoordinates(getLondonUsers, getUsers);
        }
    }
}
