using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Txet_based
{

    class GameWorld
    {
        public string currentLocation;
        public List<string> inventory = new List<string>();

        public GameWorld(string startingLocation)
        {
            currentLocation = startingLocation;
        }

        public void GoNorth()
        {
            if (currentLocation == "Starting Room")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You walk through the door to the north and enter a dark hallway.");
                currentLocation = "Hallway";
            }
            else if (currentLocation == "Hallway")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You walk to the end of the hallway and find a locked door.");
            }
        }

        public void GoEast()
        {
            if (currentLocation == "Starting Room")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("You walk through the door to the east and enter a small kitchen.");
                currentLocation = "Kitchen";
            }
            else if (currentLocation == "Kitchen")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("You search the kitchen and find a key.");
                inventory.Add("Key");
            }
        }

        public void PickUpItem()
        {
            if (currentLocation == "Kitchen")
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("You pick up the key from the kitchen counter.");
                inventory.Add("Key");
            }
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            GameWorld game = new GameWorld("Starting Room");

            Console.WriteLine("Welcome to the adventure game!");

            while (true)
            {
                Console.WriteLine("\nYou are currently in " + game.currentLocation + ".");
                Console.WriteLine("What would you like to do? (Enter a command)");

                string input = Console.ReadLine();
                input = input.ToLower();

                if (input == "go north")
                {
                    game.GoNorth();
                }
                else if (input == "go east")
                {
                    game.GoEast();
                }
                else if (input == "pick up item")
                {
                    game.PickUpItem();
                }
                else if (input == "inventory")
                {
                    Console.WriteLine("You have:");

                    foreach (string item in game.inventory)
                    {
                        Console.WriteLine("- " + item);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid command.");
                }
            }
        }

    }
}

