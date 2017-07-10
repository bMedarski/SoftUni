namespace Exam.Contracts
{
    public interface ICar
    {
        int Horsepower { get; set; }
        int Suspension { get; set; }
        int Acceleration { get; }
        int Durability { get; }
        string Model { get; }
        string Brand { get; }
    }
}
