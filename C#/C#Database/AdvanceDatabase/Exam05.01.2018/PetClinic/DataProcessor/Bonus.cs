using System.Linq;

namespace PetClinic.DataProcessor
{
    using System;

    using PetClinic.Data;

    public class Bonus
    {
        public static string UpdateVetProfession(PetClinicContext context, string phoneNumber, string newProfession)
        {
			var vetId = context.Vets.SingleOrDefault(i => i.PhoneNumber == phoneNumber)?.Id;

	        if (vetId == null)
	        {
		        return $"Vet with phone number {phoneNumber} not found!";
	        }
	        else
	        {
		        //decimal currentPrice = 0;
		        var vet = context.Vets.Where(i => i.PhoneNumber == phoneNumber).ToArray()[0];
				var oldProfession = vet.Profession;
		        vet.Profession = newProfession;
		        context.SaveChanges();
		        return $"{vet.Name}'s profession updated from {oldProfession} to {newProfession}.";
	        }
		}
    }
}
