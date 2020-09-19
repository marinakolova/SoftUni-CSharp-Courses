namespace ProductShop
{
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;
    using Data;
    using Dto;
    using Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var db = new ProductShopContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                //Query 1. Import Users
                var usersJson = File.ReadAllText("./../../../Datasets/users.json");
                ImportUsers(db, usersJson);

                //Query 2. Import Products
                var productsJson = File.ReadAllText("./../../../Datasets/products.json");
                ImportProducts(db, productsJson);

                //Query 3. Import Categories
                var categoriesJson = File.ReadAllText("./../../../Datasets/categories.json");
                ImportCategories(db, categoriesJson);

                //Query 4. Import Categories and Products
                var categoriesProductsJson = File.ReadAllText("./../../../Datasets/categories-products.json");
                ImportCategoryProducts(db, categoriesProductsJson);

                //Query 5. Export Products In Range
                File.WriteAllText("./../../../Results/products-in-range.json", GetProductsInRange(db));

                //Query 6. Export Successfully Sold Products
                File.WriteAllText("./../../../Results/successfully-sold-products.json", GetSoldProducts(db));

                //Query 7. Export Categories By Products Count
                File.WriteAllText("./../../../Results/categories-by-products-count.json", GetCategoriesByProductsCount(db));

                //Query 8. Export Users and Products
                File.WriteAllText("./../../../Results/users-and-products.json", GetUsersWithProducts(db));
            }
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<Product[]>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<Category[]>(inputJson)
                .Where(c => c.Name != null);

            context.Categories.AddRange(categories);
            var count = context.SaveChanges();

            return $"Successfully imported {count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Length}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var exportedProducts = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ProductInRangeDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    Seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                })
                .OrderBy(p => p.Price)
                .ToList();

            return JsonConvert.SerializeObject(exportedProducts, Formatting.Indented);
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var filteredUsers = context.Users
                .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new UserDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                        .Where(p => p.Buyer != null)
                        .Select(p => new SoldProductDto
                        {
                            Name = p.Name,
                            Price = p.Price,
                            BuyerFirstName = p.Buyer.FirstName,
                            BuyerLastName = p.Buyer.LastName
                        })
                        .ToList()
                })
                .ToList();

            return JsonConvert.SerializeObject(filteredUsers, Formatting.Indented);
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var exportedCategories = context.Categories
                .OrderByDescending(c => c.CategoryProducts.Count())
                .Select(c => new CategoriesDto
                {
                    Category = c.Name,
                    ProductsCount = c.CategoryProducts.Count(),
                    AveragePrice = $@"{c.CategoryProducts
                                           .Sum(p => p.Product.Price) / c.CategoryProducts.Count():F2}",
                    TotalRevenue = $"{c.CategoryProducts.Sum(p => p.Product.Price):F2}"
                })
                .ToList();

            return JsonConvert.SerializeObject(exportedCategories, Formatting.Indented);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderByDescending(p => p.ProductsSold.Count(ps => ps.Buyer != null))
                .Select(u => new UserWithProductsDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new SoldProductsToUserDto
                    {
                        Count = u.ProductsSold.Count(p => p.Buyer != null),
                        Products = u.ProductsSold
                            .Where(p => p.Buyer != null)
                            .Select(p => new SoldProductsDto
                            {
                                Name = p.Name,
                                Price = p.Price
                            })
                            .ToList()
                    }
                })
                .ToList();

            var result = new UsersAndProductsDto
            {
                UsersCount = users.Count(),
                Users = users
            };

            return JsonConvert.SerializeObject(result,
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
        }
    }
}