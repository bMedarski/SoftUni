namespace PhotoShare.Client.Core.Commands
{
    using Models;
    using Data;

    public class AddTownCommand
    {
        // AddTown <townName> <countryName>
        public string Execute(string[] data)
        {
            string townName = data[1];
            string country = data[0];

            using (PhotoShareContext context = new PhotoShareContext())
            {
                Town town = new Town
                {
                    Name = townName,
                    Country = country
                };

                context.Towns.Add(town);
                context.SaveChanges();

                return townName + " was added to database!";
            }
        }
    }
}
