using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_22.Utils
{
    public class CsvDataOfItems
    {
        public static IEnumerable<TestCaseData> GetTestCases()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(baseDir, "Resources", "TestDateProducts.csv");
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split(';');
                string itemName = parts[0];
                string itemPrice = parts[1];                
                yield return new TestCaseData(itemName, itemPrice)
                .SetName($"Добавлен_продукт_{itemName}_по_ цене_{itemPrice}.");
            }
        }
    }
}
