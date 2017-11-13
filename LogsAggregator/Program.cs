using System;
using System.Collections.Generic;
using System.Linq;

namespace LogsAggregator
{
    class Program
    {
        static void Main(string[] args)
        {
            var numOfLogs = int.Parse(Console.ReadLine());
            var dictOfUsers = new SortedDictionary<string, SortedDictionary<string, int>>();
            for (int i = 0; i < numOfLogs; i++)
            {
                var userInfo = Console.ReadLine().Split().ToArray();
                var IP = userInfo[0];
                var username = userInfo[1];
                var duration = int.Parse(userInfo[2]);
                if (!dictOfUsers.ContainsKey(username))
                {
                    dictOfUsers.Add(username, new SortedDictionary<string, int>());
                }
                if (!dictOfUsers[username].ContainsKey(IP))
                {
                    dictOfUsers[username].Add(IP, duration);
                }
                else
                {
                    dictOfUsers[username][IP] += duration;
                }

            }

            foreach (var user in dictOfUsers)
            {
                var totalDurationOfUser = dictOfUsers[user.Key].Values.Sum();
                var listOfIps = user.Value.Keys.ToList();
                Console.WriteLine($"{user.Key}: {totalDurationOfUser} [{string.Join(", ", listOfIps)}]");
            }
        }
    }
}