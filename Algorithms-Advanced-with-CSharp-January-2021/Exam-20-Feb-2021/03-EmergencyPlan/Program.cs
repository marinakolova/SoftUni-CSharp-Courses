using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _03_EmergencyPlan // Judge Score: 87 / 100
{
    public class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int TimeInSeconds { get; set; }
    }
    
    public class Program
    {
        private static List<Edge>[] graph;
        private static double[] bestExitTime; // in seconds
        private static Dictionary<int, HashSet<int>> roomsByExit;

        public static void Main(string[] args)
        {
            var roomsCount = int.Parse(Console.ReadLine());
            
            var exitRooms = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            bestExitTime = new double[roomsCount];
            roomsByExit = new Dictionary<int, HashSet<int>>();

            for (int room = 0; room < roomsCount; room++)
            {
                if (exitRooms.Contains(room))
                {
                    bestExitTime[room] = 0;
                    roomsByExit[room] = new HashSet<int>();
                }
                else
                {
                    bestExitTime[room] = double.PositiveInfinity;
                }       
            }

            var edgesCount = int.Parse(Console.ReadLine());

            graph = ReadGraph(roomsCount, edgesCount);

            var maxTime = GetTimeInSeconds(Console.ReadLine());

            var queue = new OrderedBag<int>(
                    Comparer<int>.Create((f, s) => bestExitTime[f].CompareTo(bestExitTime[s])));

            // Go from each exit into each room
            for (int exitRoomIndex = 0; exitRoomIndex < exitRooms.Count; exitRoomIndex++)
            {
                queue.Add(exitRooms[exitRoomIndex]);

                for (int room = 0; room < roomsCount; room++)
                {
                    while (queue.Count > 0)
                    {
                        var node = queue.RemoveFirst();
                        roomsByExit[exitRooms[exitRoomIndex]].Add(node);

                        if (node == room)
                        {
                            break;
                        }

                        foreach (var edge in graph[node])
                        {
                            var child = edge.First == node
                                ? edge.Second
                                : edge.First;

                            if (double.IsPositiveInfinity(bestExitTime[child]) ||
                                !roomsByExit[exitRooms[exitRoomIndex]].Contains(child))
                            {
                                queue.Add(child);
                            }

                            var newDistance = bestExitTime[node] + edge.TimeInSeconds;

                            if (newDistance < bestExitTime[child])
                            {
                                bestExitTime[child] = newDistance;

                                queue = new OrderedBag<int>(
                                    queue,
                                    Comparer<int>.Create((f, s) => bestExitTime[f].CompareTo(bestExitTime[s])));
                            }
                        }
                    }
                }
            }

            // Print Result
            for (int room = 0; room < bestExitTime.Length; room++)
            {
                if (bestExitTime[room] != 0) // -> if room is not an exit room
                {
                    if (double.IsPositiveInfinity(bestExitTime[room]))
                    {
                        Console.WriteLine($"Unreachable {room} (N/A)");
                    }
                    else if (bestExitTime[room] > maxTime)
                    {
                        Console.WriteLine($"Unsafe {room} ({GetTimeStringFromSeconds((int)bestExitTime[room])})");
                    }
                    else
                    {
                        Console.WriteLine($"Safe {room} ({GetTimeStringFromSeconds((int)bestExitTime[room])})");
                    }
                }
            }
        }

        private static string GetTimeStringFromSeconds(int seconds)
        {
            TimeSpan time = TimeSpan.FromSeconds(seconds);

            string str = time.ToString(@"hh\:mm\:ss");

            return str;
        }

        private static List<Edge>[] ReadGraph(int nodes, int edges)
        {
            var result = new List<Edge>[nodes];

            for (int node = 0; node < result.Length; node++)
            {
                result[node] = new List<Edge>();
            }

            for (int i = 0; i < edges; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split()
                    .ToArray();

                var first = int.Parse(edgeData[0]);
                var second = int.Parse(edgeData[1]);
                var timeInSeconds = GetTimeInSeconds(edgeData[2]);

                var edge = new Edge
                {
                    First = first,
                    Second = second,
                    TimeInSeconds = timeInSeconds
                };

                result[first].Add(edge);
                result[second].Add(edge);
            }

            return result;
        }

        private static int GetTimeInSeconds(string timeString)
        {
            var timeData = timeString
                .Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            var minutes = timeData[0];
            var seconds = timeData[1];

            var timeInSeconds = minutes * 60 + seconds;

            return timeInSeconds;
        }
    }
}
