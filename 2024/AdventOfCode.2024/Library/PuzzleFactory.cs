﻿namespace AdventOfCode._2024.Library
{
    internal static class PuzzleFactory
    {
        public static APuzzle GetPuzzle(short day, string dataFilename, Part part)
        {
            return day switch
            {
                1 => new _01.ListDistanceFinder(dataFilename, part),
                2 => new _02.ReactorReportAnalyser(dataFilename, part),
                3 => new _03.ComputerDecorrupter(dataFilename, part),
                4 => new _04.WordSearchSolver(dataFilename, part),
                5 => new _05.PageOrderValidator(dataFilename, part),
                6 => new _06.GuardRouteTracker(dataFilename, part),
                _ => throw new ArgumentOutOfRangeException(nameof(day), day, $"Day {day} not supported by PuzzleFactory"),
            };
        }
    }
}