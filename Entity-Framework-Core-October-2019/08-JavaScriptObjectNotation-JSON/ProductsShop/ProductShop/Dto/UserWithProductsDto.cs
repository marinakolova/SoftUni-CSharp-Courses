namespace ProductShop.Dto
{
    using Newtonsoft.Json;

    public class UserWithProductsDto
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("age")]
        public int? Age { get; set; }

        [JsonProperty("soldProducts")]
        public SoldProductsToUserDto SoldProducts { get; set; }
    }
}
