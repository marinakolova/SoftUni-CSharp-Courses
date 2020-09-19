namespace VaporStore.DataProcessor
{
    using Data;
    using Data.Models;
    using Dto.Import;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
            var deserializedGames = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);
            
            var developers = new List<Developer>();
            var genres = new List<Genre>();
            var tags = new List<Tag>();
            var games = new List<Game>();

            var sb = new StringBuilder();

            foreach (var gameDto in deserializedGames)
            {
                if (!IsValid(gameDto) || !gameDto.Tags.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var developer = developers.SingleOrDefault(d => d.Name == gameDto.Developer);
                if (developer == null)
                {
                    developer = new Developer
                    {
                        Name = gameDto.Developer
                    };

                    developers.Add(developer);
                }


                var genre = genres.SingleOrDefault(g => g.Name == gameDto.Genre);
                if (genre == null)
                {
                    genre = new Genre
                    {
                        Name = gameDto.Genre
                    };

                    genres.Add(genre);
                }

                var gameTags = new List<Tag>();
                foreach (var tagName in gameDto.Tags)
                {
                    var tag = tags.SingleOrDefault(t => t.Name == tagName);
                    if (tag == null)
                    {
                        tag = new Tag
                        {
                            Name = tagName
                        };

                        tags.Add(tag);
                    }

                    gameTags.Add(tag);
                }

                var game = new Game
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = gameDto.ReleaseDate,
                    Developer = developer,
                    Genre = genre,
                    GameTags = gameTags.Select(t => new GameTag { Tag = t }).ToArray()
                };

                games.Add(game);

                sb.AppendLine($"Added {gameDto.Name} ({gameDto.Genre}) with {gameDto.Tags.Length} tags");
            }

            context.Games.AddRange(games);

            context.SaveChanges();

            var result = sb.ToString();

            return result;
        }

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
            var sb = new StringBuilder();

            var deserializedUsers = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);

            var users = new List<User>();

            foreach (var userDto in deserializedUsers)
            {
                if (!IsValid(userDto) || !userDto.Cards.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var cards = userDto.Cards
                    .Select(impCardDto => new Card
                    {
                        Number = impCardDto.Number,
                        Cvc = impCardDto.Cvc,
                        Type = impCardDto.Type
                    })
                    .ToArray();

                var user = new User
                {
                    Username = userDto.Username,
                    FullName = userDto.FullName,
                    Email = userDto.Email,
                    Age = userDto.Age,
                    Cards = cards
                };

                users.Add(user);
                sb.AppendLine($"Imported {userDto.Username} with {userDto.Cards.Length} cards");
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            var result = sb.ToString();
            return result;
        }

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(ImportPurchaseDto[]), new XmlRootAttribute("Purchases"));

            var deserialized = (ImportPurchaseDto[])serializer.Deserialize(new StringReader(xmlString));

            var validPurchases = new List<Purchase>();

            foreach (var purchaseDto in deserialized)
            {
                if (!IsValid(purchaseDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var game = context.Games.Single(g => g.Name == purchaseDto.Title);
                var card = context.Cards.Include(c => c.User).Single(c => c.Number == purchaseDto.Card);
                var date = DateTime.ParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                var purchase = new Purchase
                {
                    Game = game,
                    Type = purchaseDto.Type,
                    Card = card,
                    ProductKey = purchaseDto.Key,
                    Date = date
                };

                validPurchases.Add(purchase);
                sb.AppendLine($"Imported {purchase.Game.Name} for {purchase.Card.User.Username}");
            }

            context.Purchases.AddRange(validPurchases);
            context.SaveChanges();

            var result = sb.ToString();
            return result;
        }

        private static bool IsValid(this object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);

            return isValid;
        }
    }
}