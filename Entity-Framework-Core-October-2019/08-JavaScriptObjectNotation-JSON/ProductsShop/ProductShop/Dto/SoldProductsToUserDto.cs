namespace ProductShop.Dto
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class SoldProductsToUserDto
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("products")]
        public ICollection<SoldProductsDto> Products { get; set; }
    }
}
