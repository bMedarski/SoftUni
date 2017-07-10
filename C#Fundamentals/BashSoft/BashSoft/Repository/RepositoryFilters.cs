using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft
{
    public static class RepositoryFilters
    {
        public static void FilterAndTake(Dictionary<string, List<int>> wantedData, string wantedFilters, int studentsToTake)
        {
            if (wantedFilters == "excellent")
            {
               FilterAndTake(wantedData, x => x >= 5, studentsToTake); 
            }
            else if (wantedFilters == "average")
            {
                FilterAndTake(wantedData, x => x >= 3.5 && x < 5, studentsToTake);
            }
            else if (wantedFilters == "poor")
            {
                FilterAndTake(wantedData, x => x < 3.5, studentsToTake);
            }
            else
            {
                OutputWriter.WriteMessageOnNewLine(ExceptionMessages.InvalidStudentFilter);
            }
        }

        private static void FilterAndTake(Dictionary<string, List<int>> wantedData, Predicate<double> givenFilter, int studentsToTake)
        {
            int counter = 0;
            foreach (var username_score in wantedData)
            {
                if (counter == studentsToTake)
                    break;

                var avrScore = username_score.Value.Average();
                var percentageOfFullfillments = avrScore / 100;
                var mark = percentageOfFullfillments * 4 + 2;

                if (givenFilter(mark))
                {
                    OutputWriter.PrintStudent(username_score);
                    counter++;
                }
            }
        }

        //private static double Average(List<int> scoresOnTasks)
        //{
        //    int totalScore = 0;
        //    foreach (var score in scoresOnTasks)
        //    {
        //        totalScore += score;
        //    }

        //    var percentageOfAll = totalScore / (scoresOnTasks.Count * 100);
        //    var mark = percentageOfAll * 4 + 2;

        //    return mark;
        //}
    }
}
