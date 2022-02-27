using Newtonsoft.Json;

namespace DwpApiDemoProject.Model
{
    public class UserDetail
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "first_name")]
        public string First_Name { get; set; }

        [JsonProperty(PropertyName = "last_name")]
        public string Last_Name { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "ip_address")]
        public string Ip_Address { get; set; }

        [JsonProperty(PropertyName = "latitude")]
        public double Latitude { get; set; }

        [JsonProperty(PropertyName = "longitude")]
        public double Longitude { get; set; }

        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }
    }
}
