
namespace Exam.Contracts
{
    public interface IRaceFactory
    {
        void CreateRace(int id, string type, int length, string route, int prizePool,int optional);
    }
}
