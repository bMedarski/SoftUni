namespace Exam.Contracts
{
    public interface IRace
    {
        void AddParticipiant(ICar car);

        string StartRace();

        bool CheckForParticipiant(int id);
    }
}
