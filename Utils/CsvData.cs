using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_22.Utils
{
    public class CsvData
    {
        public static IEnumerable<TestCaseData> GetTestCases()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(baseDir, "Resources", "data.csv");
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split(';');
                string login = parts[0];
                string password = parts[1];
                string expected = parts[2];
                yield return new TestCaseData(login, password, expected)
                .SetName($"Введен логин_{login}_и_пароль_{password}, {expected}");                
            }
        }
    }
}
