using DwpApiDemoProject.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DwpApiDemoProject
{
    public class UserDetailRepository : IUserDetailRepository
    {

        private readonly string _url = "https://bpdts-test-app.herokuapp.com";

        public List<UserDetail> UserDetails { get; set; }
        public List<UserDetail> UserDetailsForLondon { get; set; }
        public UserDetailRepository()
        {
            UserDetails = GetUsersFromUrlAsync($"{_url}/users").Result; 
            
        }
        public IEnumerable<UserDetail> GetAll()
        {
            return UserDetails;
        }

        public IEnumerable<UserDetail> GetUsersForLondon(string city)
        {
            var fullUrl = $"{_url}/city/{city}/users";
            
            return GetUsersFromUrlAsync(fullUrl).Result;
        }

        public IEnumerable<UserDetail> GetUsersFromCoordinates(List<UserDetail> source, List<UserDetail> destination)
        {
            return CheckCityUsingCoordinates(source, destination);

        }

        private async Task<List<UserDetail>> GetUsersFromUrlAsync(string url)
        {
            var client = new RestClient(url);
            var response = await client.ExecuteGetAsync<List<UserDetail>>(new RestRequest());
            return response.Data;
        }

        private async Task<UserDetail> GetCityByUserIdUrlAsync(string url)
        {
            var client = new RestClient(url);
            var response = await client.ExecuteGetAsync<UserDetail>(new RestRequest());
            return response.Data;
        }
        private string GetCityByUserId(int id)
        {
            return GetCityByUserIdUrlAsync($"{_url}/user/{id}").Result.City;
        }

        private List<UserDetail> CheckCityUsingCoordinates(List<UserDetail> source, List<UserDetail> destination)
        {
            List<UserDetail> result = new List<UserDetail>();

            foreach (var sourceUserDetail in source)
            {
                var sourceLat = sourceUserDetail.Latitude;
                var sourceLong = sourceUserDetail.Longitude;

                foreach (var destUserDetail in destination)
                {
                    var destLat = destUserDetail.Latitude;
                    var destLong = destUserDetail.Longitude;

                    var miles = CalculateDistance(sourceLat, sourceLong, destLat, destLong);
                    if (miles <= 50.0)
                    {
                        destUserDetail.City = GetCityByUserId(destUserDetail.Id);
                        result.Add(destUserDetail);
                    }
                }

            }

            return result.OrderBy(x => x.Id).ToList();
        }

        private static double CalculateDistance(double sourcelat, double sourcelongt, double destlat, double destlongt)
        {
            double rlat1 = Math.PI * sourcelat / 180;
            double rlat2 = Math.PI * destlat / 180;
            double theta = sourcelongt - destlongt;
            double rtheta = Math.PI * theta / 180;
            double dist =
                Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;
            return dist;
        }
    }
}
