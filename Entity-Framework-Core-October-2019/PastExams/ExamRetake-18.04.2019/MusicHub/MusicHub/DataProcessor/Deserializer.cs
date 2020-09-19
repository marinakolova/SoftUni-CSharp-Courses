namespace MusicHub.DataProcessor
{
    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using ImportDtos;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter 
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone 
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong 
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            var writersDto = JsonConvert.DeserializeObject<ImportWriterDto[]>(jsonString);

            var sb = new StringBuilder();
            var validWriters = new List<Writer>();

            foreach (var writerDto in writersDto)
            {
                if (!IsValid(writerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var writer = AutoMapper.Mapper.Map<Writer>(writerDto);
                validWriters.Add(writer);

                sb.AppendLine(string.Format(SuccessfullyImportedWriter, writer.Name));
            }

            context.Writers.AddRange(validWriters);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            var producerDtos = JsonConvert.DeserializeObject<ImportProducerDto[]>(jsonString);

            var sb = new StringBuilder();
            var validProducers = new List<Producer>();

            foreach (var producerDto in producerDtos)
            {
                if (!IsValid(producerDto) || !producerDto.Albums.All(IsValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                //var producer = AutoMapper.Mapper.Map<Producer>(producerDto);
                //validProducers.Add(producer);

                var producer = new Producer
                {
                    Name = producerDto.Name,
                    PhoneNumber = producerDto.PhoneNumber,
                    Pseudonym = producerDto.Pseudonym
                };

                foreach (var albumDto in producerDto.Albums)
                {
                    producer.Albums.Add(new Album
                    {
                        Name = albumDto.Name,
                        ReleaseDate = DateTime.ParseExact(albumDto.ReleaseDate, "dd/MM/yyyy",
                            CultureInfo.InvariantCulture)
                    });
                }

                string message = producer.PhoneNumber == null
                    ? string.Format(SuccessfullyImportedProducerWithNoPhone, producer.Name, producer.Albums.Count)
                    : string.Format(SuccessfullyImportedProducerWithPhone, producer.Name, producer.PhoneNumber, producer.Albums.Count);

                sb.AppendLine(message);
                validProducers.Add(producer);
            }

            context.Producers.AddRange(validProducers);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSongDto[]), new XmlRootAttribute("Songs"));
            var songDtos = (ImportSongDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var validSongs = new List<Song>();

            foreach (var songDto in songDtos)
            {
                if (!IsValid(songDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var genre = Enum.TryParse(songDto.Genre, out Genre genreResult);
                var album = context.Albums.Find(songDto.AlbumId);
                var writer = context.Writers.Find(songDto.WriterId);
                var songTitle = validSongs.Any(s => s.Name == songDto.Name);

                if (!genre || album == null || writer == null || songTitle)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var song = AutoMapper.Mapper.Map<Song>(songDto);

                sb.AppendLine(string.Format(SuccessfullyImportedSong, song.Name, song.Genre, song.Duration));
                validSongs.Add(song);
            }

            context.Songs.AddRange(validSongs);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            var performerDtos = DeserializeObject<ImportPerformerDto>("Performers", xmlString);

            var validPerformers = new List<Performer>();
            var sb = new StringBuilder();

            foreach (var performerDto in performerDtos)
            {
                if (!IsValid(performerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var validSongsCount = context.Songs.Count(s => performerDto.PerformerSongs.Any(i => i.Id == s.Id));

                if (validSongsCount != performerDto.PerformerSongs.Length)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var performer = AutoMapper.Mapper.Map<Performer>(performerDto);

                validPerformers.Add(performer);
                sb.AppendLine(string.Format(SuccessfullyImportedPerformer, performer.FirstName,
                    performer.PerformerSongs.Count));
            }

            context.Performers.AddRange(validPerformers);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();

            return result;
        }

        private static T[] DeserializeObject<T>(string rootElement, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(T[]), new XmlRootAttribute(rootElement));
            var deserializedDtos = (T[])xmlSerializer.Deserialize(new StringReader(xmlString));
            return deserializedDtos;
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            var result = Validator.TryValidateObject(entity, validationContext, validationResult, true);

            return result;
        }
    }
}