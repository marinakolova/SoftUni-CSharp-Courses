namespace CarDealer
{
    using System.IO;
    using System.Linq;
    using Data;
    using DTO;
    using Models;
    using Newtonsoft.Json;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var db = new CarDealerContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                //Query 9. Import Suppliers
                var suppliersJson = File.ReadAllText("./../../../Datasets/suppliers.json");
                ImportSuppliers(db, suppliersJson);

                //Query 10. Import Parts
                var partsJson = File.ReadAllText("./../../../Datasets/parts.json");
                ImportParts(db, partsJson);

                //Query 11. Import Cars
                var carsJson = File.ReadAllText("./../../../Datasets/cars.json");
                ImportCars(db, carsJson);

                //Query 12. Import Customers
                var customersJson = File.ReadAllText("./../../../Datasets/customers.json");
                ImportCustomers(db, customersJson);

                //Query 13. Import Sales
                var salesJson = File.ReadAllText("./../../../Datasets/sales.json");
                ImportSales(db, salesJson);

                //Query 14. Export Ordered Customers
                File.WriteAllText("./../../../Results/ordered-customers.json", GetOrderedCustomers(db));

                //Query 15. Export Cars from make Toyota
                File.WriteAllText("./../../../Results/cars-from-make-toyota.json", GetCarsFromMakeToyota(db));

                //Query 16. Export Local Suppliers
                File.WriteAllText("./../../../Results/local-suppliers.json", GetLocalSuppliers(db));

                //Query 17. Export Cars with Their List of Parts
                File.WriteAllText("./../../../Results/cars-with-their-list-of-parts.json", GetCarsWithTheirListOfParts(db));

                //Query 18. Export Total Sales by Customer
                File.WriteAllText("./../../../Results/total-sales-by-customer.json", GetTotalSalesByCustomer(db));

                //Query 19. Export Sales with Applied Discount
                File.WriteAllText("./../../../Results/sales-with-applied-discount.json", GetSalesWithAppliedDiscount(db));
            }
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<Part[]>(inputJson)
                .Where(p => p.SupplierId > 0 && p.SupplierId <= context.Suppliers.Count());

            context.Parts.AddRange(parts);
            var count = context.SaveChanges();

            return $"Successfully imported {count}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var cars = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson);

            foreach (var carDto in cars)
            {
                Car car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                context.Cars.Add(car);

                foreach (var partId in carDto.PartsId)
                {
                    PartCar partCar = new PartCar
                    {
                        CarId = car.Id,
                        PartId = partId
                    };

                    if (car.PartCars.FirstOrDefault(p => p.PartId == partId) == null)
                    {
                        context.PartCars.Add(partCar);
                    }
                }
            }

            context.SaveChanges();

            return $"Successfully imported {cars.Length}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new ExportCustomerDto
                {
                    Name = $"{c.Name}",
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var toyotaCrs = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new ExportCarToyotaDto
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToList();

            return JsonConvert.SerializeObject(toyotaCrs, Formatting.Indented);
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new ExportLocalSupplierDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count()
                })
                .ToList();

            return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new ExportCarDto
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    },
                    parts = c.PartCars.Select(p => new ExportPartDto
                        {
                            Name = p.Part.Name,
                            Price = $"{p.Part.Price:F2}"
                        })
                        .ToList()
                })
                .ToList();

            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new ExportCustomerWithCarDto
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count(),
                    SpentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(p => p.Part.Price))
                })
                .OrderByDescending(m => m.SpentMoney)
                .ThenByDescending(c => c.BoughtCars)
                .ToList();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new
                {
                    car = new ExportCarDto
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = $"{s.Discount:F2}",
                    price = $"{s.Car.PartCars.Sum(p => p.Part.Price):F2}",
                    priceWithDiscount = $@"{(s.Car.PartCars.Sum(p => p.Part.Price) -
                                             s.Car.PartCars.Sum(p => p.Part.Price) * s.Discount / 100):F2}"
                })
                .Take(10)
                .ToList();

            return JsonConvert.SerializeObject(sales, Formatting.Indented);
        }
    }
}