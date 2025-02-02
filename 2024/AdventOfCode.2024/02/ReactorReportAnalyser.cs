﻿using AdventOfCode._2024.Library;

namespace AdventOfCode._2024._02
{
    internal class ReactorReportAnalyser(string dataFilename, Part part) : APuzzle(dataFilename, part)
    {
        public override string GetAnswer()
        {
            List<List<int>> reports = GetReports();

            return Part switch
            {
                Part.One => reports.Count(IsSafe).ToString(),
                Part.Two => reports.Count(IsSafeWithDampener).ToString(),
                _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unsupported Part"),
            };
        }

        private List<List<int>> GetReports()
        {
            return File.ReadLines(DataFilename)
                .Select(x => x.Split().Select(int.Parse).ToList()).ToList();
        }

        private bool IsSafe(List<int> report)
        {
            bool increasing = report[1] > report[0];

            for (int i = 1; i < report.Count; i++)
            {
                int diff = Math.Abs(report[i] - report[i - 1]);
                if (diff < 1 || diff > 3)
                {
                    return false;
                }

                if (increasing && report[i] < report[i - 1] || !increasing && report[i] > report[i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsSafeWithDampener(List<int> report)
        {
            if (IsSafe(report))
            {
                return true;
            }

            for (int i = 0; i < report.Count; i++)
            {
                var dampedReport = new List<int>(report);
                dampedReport.RemoveAt(i);
                if (IsSafe(dampedReport))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
