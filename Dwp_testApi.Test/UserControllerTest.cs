using DwpApiDemoProject;
using DwpApiDemoProject.Controllers;
using DwpApiDemoProject.Model;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Dwp_testApi.Test
{
    public class UserControllerTest
    {

        UserController _userController;
        readonly IUserDetailRepository _repo;
        public Mock<IUserDetailRepository> mock = new Mock<IUserDetailRepository>();
        public UserControllerTest()
        {
            _repo = new UserDetailRepository();
            _userController = new UserController(_repo);

        }
             

        [Fact]
        public void GetGetUsersByCoordinates()
        {
            //Arrange
            var userdetailsTestData = new List<UserDetail>()
            {
                new UserDetail()
                { Id = 1, First_Name = "Maurise", Last_Name= "Shieldon", Ip_Address= "192.57.232.111", Email= "mshieldon0@squidoo.com", Latitude= 34.003135, Longitude= -117.7228641, City="Kax" },
                new UserDetail()
                { Id = 135, First_Name = "Mechelle", Last_Name = "Boam", Ip_Address = "113.71.242.187", Email = "mboam3q@thetimes.co.uk", Latitude = -6.5115909, Longitude = 105.652983, City = "London" },
                new UserDetail()
                { Id = 396, First_Name = "Terry", Last_Name = "Stowgill", Ip_Address = "143.190.50.240", Email = "tstowgillaz@webeden.co.uk", Latitude = -6.7098551, Longitude = 111.3479498, City = "London" },
                new UserDetail()
                { Id = 319, First_Name = "Dulciana", Last_Name = "Shewan", Ip_Address = "15.201.192.231", Email = "dshewan8u@ifeng.com", Latitude = 49.7392784, Longitude = 19.8619324, City = "Tokarnia" },
                new UserDetail()
                { Id = 120, First_Name = "Suzanne", Last_Name = "Whooley", Ip_Address = "187.220.48.104", Email = "swhooley3b@reference.com", Latitude = -6.6721504, Longitude = 111.5910078, City = "Kragan" }

            };

            var userdetailsLondonTestData = new List<UserDetail>()
            {
                new UserDetail()
                { Id = 520, First_Name = "Andrew", Last_Name= "Seabrocke", Ip_Address= "192.57.232.111", Email= "aseabrockeef@indiegogo.com", Latitude= 27.69417, Longitude= 109.73583, City="London" },
                new UserDetail()
                { Id = 135, First_Name = "Mechelle", Last_Name = "Boam", Ip_Address = "113.71.242.187", Email = "mboam3q@thetimes.co.uk", Latitude = -6.5115909, Longitude = 105.652983, City = "London" },
                new UserDetail()
                { Id = 396, First_Name = "Terry", Last_Name = "Stowgill", Ip_Address = "143.190.50.240", Email = "tstowgillaz@webeden.co.uk", Latitude = -6.7098551, Longitude = 111.3479498, City = "London" }

            };


            var userdetailsResult = new List<UserDetail>()
            {
                new UserDetail()
                { Id = 520, First_Name = "Andrew", Last_Name= "Seabrocke", Ip_Address= "192.57.232.111", Email= "aseabrockeef@indiegogo.com", Latitude= 27.69417, Longitude= 109.73583, City="London" },
                new UserDetail()
                { Id = 135, First_Name = "Mechelle", Last_Name = "Boam", Ip_Address = "113.71.242.187", Email = "mboam3q@thetimes.co.uk", Latitude = -6.5115909, Longitude = 105.652983, City = "London" },
                new UserDetail()
                { Id = 396, First_Name = "Terry", Last_Name = "Stowgill", Ip_Address = "143.190.50.240", Email = "tstowgillaz@webeden.co.uk", Latitude = -6.7098551, Longitude = 111.3479498, City = "London" },
                 new UserDetail()
                { Id = 120, First_Name = "Suzanne", Last_Name = "Whooley", Ip_Address = "187.220.48.104", Email = "swhooley3b@reference.com", Latitude = -6.6721504, Longitude = 111.5910078, City = "Kragan" }

            };


            mock.Setup(p => p.UserDetails).Returns(userdetailsTestData);
            mock.Setup(p => p.UserDetailsForLondon).Returns(userdetailsLondonTestData);
            mock.Setup(p => p.GetUsersFromCoordinates(userdetailsLondonTestData, userdetailsTestData)).Returns(userdetailsResult);

            _userController = new UserController(mock.Object);
            //Act
            var result = _userController.GetUsersByCoordinates("");
            //Assert
            Assert.True(userdetailsResult.Equals(result));

        }


        [Fact]
        public void GetGetUsersByCity()
        {
            //Arrange
            var userdetailsResult = new List<UserDetail>()
            {
                new UserDetail()
                { Id = 135, First_Name = "Mechelle", Last_Name = "Boam", Ip_Address = "113.71.242.187", Email = "mboam3q@thetimes.co.uk", Latitude = -6.5115909, Longitude = 105.652983, City = "London" },
               new UserDetail()
                { Id = 396, First_Name = "Terry", Last_Name = "Stowgill", Ip_Address = "143.190.50.240", Email = "tstowgillaz@webeden.co.uk", Latitude = -6.7098551, Longitude = 111.3479498, City = "London" },
                new UserDetail()
                { Id = 520, First_Name = "Andrew", Last_Name= "Seabrocke", Ip_Address= "192.57.232.111", Email= "aseabrockeef@indiegogo.com", Latitude= 27.69417, Longitude= 109.73583, City="London" },
                 new UserDetail()
                { Id = 520, First_Name = "Andrew", Last_Name= "Seabrocke", Ip_Address= "192.57.232.111", Email= "aseabrockeef@indiegogo.com", Latitude= 27.69417, Longitude= 109.73583, City="London" }

            };


            mock.Setup(p => p.UserDetailsForLondon).Returns(userdetailsResult);
            mock.Setup(p => p.GetUsersForLondon("London")).Returns(userdetailsResult);

            _userController = new UserController(mock.Object);
            //Act
            var result = _userController.GetUsersByCity("London");
           //Assert
            Assert.True(userdetailsResult.Equals(result));
        }
    }
}


