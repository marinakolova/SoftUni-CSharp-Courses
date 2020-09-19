namespace ProductShop.Dto
{
    using Newtonsoft.Json;

    public class SoldProductsDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}
