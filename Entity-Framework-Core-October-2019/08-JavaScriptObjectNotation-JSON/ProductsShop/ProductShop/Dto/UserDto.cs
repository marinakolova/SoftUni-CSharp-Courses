namespace ProductShop.Dto
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class UserDto
    {
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "soldProducts")]
        public ICollection<SoldProductDto> SoldProducts { get; set; }
    }
}
