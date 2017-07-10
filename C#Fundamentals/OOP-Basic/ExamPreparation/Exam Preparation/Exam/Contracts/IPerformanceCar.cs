namespace Exam.Contracts
{
    public interface IPerformanceCar
    {
        void AddOn(string addon);
        int Horsepower { get; set; }
        int Suspension { get; set; }
    }
}
