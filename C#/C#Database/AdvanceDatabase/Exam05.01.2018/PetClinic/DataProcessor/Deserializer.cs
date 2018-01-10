using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using Newtonsoft.Json;
using PetClinic.DataProcessor.Dto.Import;
using PetClinic.Models;

namespace PetClinic.DataProcessor
{
	using System;

	using PetClinic.Data;

	public class Deserializer
	{

		public static string ImportAnimalAids(PetClinicContext context, string jsonString)
		{

			var sb = new StringBuilder();
		
			var animalAidDtos = JsonConvert.DeserializeObject<AnimalAidDto[]>(jsonString);

			var validAnimalAids = new List<AnimalAid>();

			foreach (var animalAidDto in animalAidDtos)
			{

				if (!IsValid(animalAidDto))
				{

					sb.AppendLine("Error: Invalid data.");
					continue;
				}
				var validAnimalAid = validAnimalAids.FirstOrDefault(p => p.Name == animalAidDto.Name);
				
				if (validAnimalAid == null)
				{
					validAnimalAid = new AnimalAid()
					{
						Name = animalAidDto.Name,
						Price = animalAidDto.Price
					};
					validAnimalAids.Add(validAnimalAid);
					sb.AppendLine($"Record {validAnimalAid.Name} successfully imported.");
				}
				else
				{
					sb.AppendLine("Error: Invalid data.");
				}
			}

			context.AnimalAids.AddRange(validAnimalAids);
			context.SaveChanges();

			var result = sb.ToString();
			return result;
		}

		public static string ImportAnimals(PetClinicContext context, string jsonString)
		{
			var sb = new StringBuilder();
			var animalDtos = JsonConvert.DeserializeObject<AnimalDto[]>(jsonString);

			var validAnimals = new List<Animal>();
			var validPassports = new List<Passport>();

			foreach (var animalDto in animalDtos)
			{
 
				Console.WriteLine($"{animalDto.Name} Type:{animalDto.Type},Age:{animalDto.Age},{animalDto.Passport.SerialNumber}");

				if (animalDto.Name.Length<3||animalDto.Name.Length>20)
				{
					sb.AppendLine("Error: Invalid data.");
					continue;
				}
				if (animalDto.Type.Length < 3 || animalDto.Type.Length > 20)
				{
					sb.AppendLine("Error: Invalid data.");
					continue;
				}
				if (animalDto.Age<1)
				{
					sb.AppendLine("Error: Invalid data.");
					continue;
				}
				if (animalDto.Passport.SerialNumber.Length != 10)
				{
					sb.AppendLine("Error: Invalid data.");
					continue;
				}
				String validSerial = @"^[a-zA-Z]{7}[0-9]{3}$";
				if (!Regex.IsMatch(animalDto.Passport.SerialNumber, validSerial))
				{
					sb.AppendLine("Error: Invalid data.");
					continue;
				}
				String validOwnerPhone = @"(0{1}[0-9]{9}|\+359[0-9]{9})";
				if (!Regex.IsMatch(animalDto.Passport.OwnerPhoneNumber, validOwnerPhone))
				{
					sb.AppendLine("Error: Invalid data.");
					continue;
				}
				if (animalDto.Passport.OwnerName.Length < 3 || animalDto.Passport.OwnerName.Length > 30)
				{
					sb.AppendLine("Error: Invalid data.");
					continue;
				}
				var validPassport = validPassports.FirstOrDefault(p => p.SerialNumber == animalDto.Passport.SerialNumber);
				if (validPassport == null)
				{
					validPassport = new Passport()
					{
						SerialNumber = animalDto.Passport.SerialNumber,
						OwnerPhoneNumber = animalDto.Passport.OwnerPhoneNumber,
						OwnerName = animalDto.Passport.OwnerName,
						RegistrationDate = DateTime.ParseExact(animalDto.Passport.RegistrationDate, "dd-MM-yyyy", CultureInfo.InvariantCulture)
					};
					validPassports.Add(validPassport);

					var validAnimal = new Animal()
					{
						Name = animalDto.Name,
						Type = animalDto.Type,
						Age = animalDto.Age,
						Passport = validPassport
					};
					validAnimals.Add(validAnimal);
					sb.AppendLine($"Record {validAnimal.Name} Passport №: {validPassport.SerialNumber} successfully imported.");
				}
				else
				{	
					sb.AppendLine("Error: Invalid data.");
				}
			}
			context.Passports.AddRange(validPassports);
			context.Animals.AddRange(validAnimals);
			context.SaveChanges();
			var result = sb.ToString();
			return result;
		}

		public static string ImportVets(PetClinicContext context, string xmlString)
		{
			
			
			var serializer = new XmlSerializer(typeof(VetDto[]), new XmlRootAttribute("Vets"));
			var vetsDtos = (VetDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

			//Console.WriteLine(vetsDtos.Length);
			var sb = new StringBuilder();
			var validVets = new List<Vet>();

			foreach (var vetsDto in vetsDtos)
			{
				if (!IsValid(vetsDto))
				{
					sb.AppendLine($"Error: Invalid data.");
					continue;
				}
				var validVet = validVets.FirstOrDefault(p => p.PhoneNumber == vetsDto.PhoneNumber);
				if (validVet == null)
				{
					validVet = new Vet()
					{
						Name = vetsDto.Name,
						PhoneNumber = vetsDto.PhoneNumber,
						Profession = vetsDto.Profession,
						Age = vetsDto.Age
					};
					validVets.Add(validVet);
					sb.AppendLine($"Record {validVet.Name} successfully imported.");
				}
				else
				{
					sb.AppendLine("Error: Invalid data.");
				}
			}
			context.Vets.AddRange(validVets);
			context.SaveChanges();

			var result = sb.ToString();
			return result;
		}

		public static string ImportProcedures(PetClinicContext context, string xmlString)
		{
			var serializer = new XmlSerializer(typeof(ProcedureDto[]), new XmlRootAttribute("Procedures"));
			var proceduresDtos = (ProcedureDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

			//Console.WriteLine(proceduresDtos.Length);
			var sb = new StringBuilder();
			var validProcedures = new List<Procedure>();

			foreach (var proceduresDto in proceduresDtos)
			{
				//Console.WriteLine(proceduresDto.AnimalAids.Length);
				if (!IsValid(proceduresDto))
				{
					sb.AppendLine($"Error: Invalid data.");
					continue;
				}

				var vet = context.Vets.FirstOrDefault(v => v.Name == proceduresDto.Vet);
				var animal = context.Animals.FirstOrDefault(a => a.PassportSerialNumber == proceduresDto.Animal);
				var inValidAnimalAid = false;
				foreach (var proceduresDtoAnimalAid in proceduresDto.AnimalAids)
				{
					var animalAid = context.AnimalAids.FirstOrDefault(a => a.Name == proceduresDtoAnimalAid.Name);
					if (animalAid==null)
					{
						inValidAnimalAid = true;
						continue;
					}
				}

				//if (proceduresDto.AnimalAids.Length != proceduresDto.AnimalAids.Distinct().Count())
				//{
				//	sb.AppendLine($"Error: Invalid data.");
				//	continue;
				//}

				if (vet==null|| inValidAnimalAid == true||animal==null)
				{
					sb.AppendLine($"Error: Invalid data.");
					continue;
				}

				var procedure = new Procedure()
				{
					Vet = context.Vets.FirstOrDefault(v => v.Name == proceduresDto.Vet),
					Animal = context.Animals.FirstOrDefault(a => a.PassportSerialNumber == proceduresDto.Animal),
					DateTime = DateTime.ParseExact(proceduresDto.DateTime, "dd-MM-yyyy", CultureInfo.InvariantCulture)
				};
				validProcedures.Add(procedure);
				sb.AppendLine("Record successfully imported.");
			}

			context.Procedures.AddRange(validProcedures);
			context.SaveChanges();

			var result = sb.ToString();
			return result;
		}

		private static bool IsValid(object obj)
		{
			var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
			var validationResults = new List<ValidationResult>();

			var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);
			return isValid;
		}
	}
}
