using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;

namespace OTS2026_PT1_GrupaA.Test
{
    internal class IncomeParser
    {
        public static IEnumerable<TestCaseData> GetTestCaseDatas(string fileName) 
        {
            string path = $@"{AppDomain.CurrentDomain.BaseDirectory}{fileName}";
            string[] lines = File.ReadAllLines(path);
            List<TestCaseData> testCases = new List<TestCaseData>();
            bool firstLine = true;
            foreach (string line in lines) 
            {
                if (firstLine) 
                {
                    firstLine = false;
                    continue;
                }
                string[] tabs = line.Split('\t');
                int amountOfFish = Convert.ToInt32(tabs[0]);
                int amountOfBait = Convert.ToInt32(tabs[1]);
                bool hasBoat = bool.Parse(tabs[2]);
                string score = Convert.ToString(tabs[3]);
                testCases.Add(new TestCaseData(amountOfFish, amountOfBait, hasBoat, score));
            }
            return testCases;
        }
    }
}
