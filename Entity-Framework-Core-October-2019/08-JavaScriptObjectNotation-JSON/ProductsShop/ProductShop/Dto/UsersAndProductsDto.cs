namespace ProductShop.Dto
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class UsersAndProductsDto
    {
        [JsonProperty("usersCount")]
        public int UsersCount { get; set; }

        [JsonProperty("users")]
        public ICollection<UserWithProductsDto> Users { get; set; }
    }
}
