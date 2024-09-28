using Newtonsoft.Json;

namespace Security.Application.DTOs
{
    public class UserDto
    {
        public UserDto() { }

        public UserDto(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
