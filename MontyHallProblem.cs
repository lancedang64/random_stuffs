using System;
using System.Collections.Generic;

// https://dotnetfiddle.net/
public class Program
{
    private static int GetRandomDoor()
    {
        return new Random().Next(0, 3);
    }

    class GameShow
    {
        public List<string> Doors { get; }

        public GameShow()
        {
            Doors = ["goat", "goat", "goat"];
            Doors[GetRandomDoor()] = "car";
        }
    }

    public static void Main()
    {
        int keepDoorWinCount = 0;
        int switchDoorWinCount = 0;
        const int numberOfGames = 10000;
        for (int i = 0; i < numberOfGames; i++)
        {
            var gameShow = new GameShow();
            int carDoor = gameShow.Doors.FindIndex(((door) => door == "car"));
            int firstChoiceDoor = GetRandomDoor();

            if (firstChoiceDoor == carDoor)
            {
                keepDoorWinCount++;
                continue;
            }

            int revealedGoatDoor = (carDoor + firstChoiceDoor) switch
            {
                1 => 2,
                2 => 1,
                _ => 0
            };
            int switchChoiceDoor = (revealedGoatDoor + firstChoiceDoor) switch
            {
                1 => 2,
                2 => 1,
                _ => 0
            };

            if (switchChoiceDoor == carDoor)
            {
                switchDoorWinCount++;
            }
            else
            {
                keepDoorWinCount++;
            }
        }
        Console.WriteLine("-----------FINAL RESULTS-----------");
        Console.WriteLine("keepDoorWinCount: " + keepDoorWinCount);
        Console.WriteLine("switchDoorWinCount: " + switchDoorWinCount);
    }
}
