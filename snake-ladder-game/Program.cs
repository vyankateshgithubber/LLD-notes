using System;
using System.ComponentModel;
using System.Reflection.Metadata;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Snake and Ladder Game!");
        // Game initialization and logic would go here
        Console.WriteLine("Give Number of Players");
        int numberOfPlayers = int.Parse(Console.ReadLine());
        Console.WriteLine($"Number of players: {numberOfPlayers}");

        List<string> playerNames = new List<string>();
        for (int i = 1; i <= numberOfPlayers; i++)
        {
            Console.WriteLine($"Enter name for Player {i}:");
            string playerName = Console.ReadLine();
            playerNames.Add(playerName);
        }
        // Define snakes and ladders
        List<Box> boxes = new List<Box>
        {
            new Ladder(3, 22),   // Ladder from 3 to 22
            new Ladder(5, 8),    // Ladder from 5 to 8
            new Ladder(11, 26),  // Ladder from 11 to 26
            new Ladder(20, 29),  // Ladder from 20 to 29
            new Snake(17, 4),   // Snake from 17 to 4
            new Snake(19, 7),   // Snake from 19 to 7
            new Snake(27, 1),   // Snake from 27 to 1
        };  
        Game game = new GameBuilder().SetBoardSize(100, boxes)
                        .AddPlayerw(playerNames).Build();
        game.Play();
    






    }
}