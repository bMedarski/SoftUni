using Exam.Core;
namespace Exam
{
    class Startup
    {
        static void Main()
        {
            var engine = Engine.Instance;
            engine.Start();
        }
    }
}
