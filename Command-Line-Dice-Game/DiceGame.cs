using System;
using System.Collections.Generic;

namespace ShivDiceGame
{
	//main class
	class MainClass
	{
		//main method
		public static void Main(string[] args)
		{
			Console.WriteLine("Welcome to Shiv's 3 or more dice game");
			Console.WriteLine("--------------------------------------");
			//call method to get the winning point to set
			player.getWinningPoint();
			Console.WriteLine("--------------------------------------");
			//call method to get player names
			player.getPlayerNames();
			//call the game play method
			Game.gamePlay();

		}
	}
	//player class to get player details
	public class player
	{
		public static int num_of_players = 2;//var to hold a fix number of 2 players
		public static int goal;//var to get the winning poin the player wants to play to 
		public static List<string> playerNames = new List<string>();//list to hold the player names
		public static void getWinningPoint()
		{
			bool exception = true;
			//while loop to iterate until the input format is right
			while (exception)
			{
				exception = false;
				try
				{
					//get the player to set the goal
					Console.WriteLine("Enter a number to which you'd like to play to.");
					goal = int.Parse(Console.ReadLine());
				}
				catch (FormatException e)
				{
					Console.WriteLine(e.Message);
					exception = true;
				}
			}
		}
		//method to get the both player names
		public static void getPlayerNames()
		{
			string name;
			//for loop to keep asking the name for the number of players
			for (int i = 0; i <= num_of_players - 1; i++)
			{
				Console.WriteLine("Enter player {0} name", i + 1);
				name = Console.ReadLine();
				playerNames.Add(name);//add the player name to the list
			}
		}

	}
	//dice class
	public class dice
	{
		public static int[] no_of_die = new int[5];//int array to hold the 5 dices
		public static int no_of_matches;//int var to hold no of matches
		public static int score;//var to hold the score
		//dice roll method
		public static void dieRoll()
		{
			int dieNum = 0;
			//random method to create the dices
			Random die = new Random();
			//for loop to get dice values for all the values in the array
			for (int i = 0; i < no_of_die.Length; i++)
			{
				no_of_die[i] = die.Next(1, 7);
			}
			//ouput the dice using foreach loop
			foreach (var x in no_of_die)
			{
				dieNum++;
				Console.WriteLine("Die {0} : {1}", dieNum, x);
			}
			dieNum = 0;
		}
		//reroll method
		public static void die_reRoll()
		{
			int count = 0;
		    int[] newDice = new int[5];//array for re roll dices
			Array.Copy(no_of_die, newDice, 2);//copy the first 2 values of the original array
			Random Dice = new Random();
			//for loop to roll the remaining 3 values
			for (int index = 2; index < newDice.Length; index++)
			{
				newDice[index] = Dice.Next(1, 7);
			}
			foreach (int x in newDice)
			{
				count++;
				Console.WriteLine("Re roll die {0} : {1}", count, x);
			}
			//sort the array
			Array.Sort(newDice);
			//compare the array values 
			if (newDice[0] == newDice[4])
			{
				no_of_matches = no_of_matches + 5;
				score = score + 12;
			}
			else if (newDice[0] == newDice[3])
			{
				no_of_matches = no_of_matches + 4;
				score = score + 6;
			}
			else if (newDice[1] == newDice[4])
			{
				no_of_matches = no_of_matches + 4;
				score = score + 6;
			}
			else if (newDice[0] == newDice[2])
			{
				no_of_matches = no_of_matches + 3;
				score = score + 3;
			}
			else if (newDice[1] == newDice[3])
			{
				no_of_matches = no_of_matches + 3;
				score = score + 3;
			}
			else if (newDice[2] == newDice[4])
			{
				no_of_matches = no_of_matches + 3;
				score = score + 3;
			}
			else
			{
				Console.WriteLine("You get 0 points");
				Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
			}
		
		}
		//method to compare original array values
		public static void checkRolls()
		{
			//sort the array
			Array.Sort(no_of_die);
			if (no_of_die[0] == no_of_die[4])
			{
				no_of_matches = no_of_matches + 5;
				score = score + 12;
			}
			else if (no_of_die[0] == no_of_die[3])
			{
				no_of_matches = no_of_matches + 4;
				score = score + 6;
			}
			else if (no_of_die[1] == no_of_die[4])
			{
				no_of_matches = no_of_matches + 4;
				score = score + 6;
			}
			else if (no_of_die[0] == no_of_die[2])
			{
				no_of_matches = no_of_matches + 3;
				score = score + 3;
			}
			else if (no_of_die[1] == no_of_die[3])
			{
				no_of_matches = no_of_matches + 3;
				score = score + 3;
			}
			else if (no_of_die[2] == no_of_die[4])
			{
				no_of_matches = no_of_matches + 3;
				score = score + 3;
			}
			else
			{
				Console.WriteLine("--------------------------------------");
				Console.WriteLine("You have 2 or none matches");
				Console.WriteLine("You get 0 points");
				Console.WriteLine("--------------------------------------");
				Console.WriteLine("Press enter to re roll");
				Console.ReadLine();
				//call reroll method 
				die_reRoll();
			}
			//output the matches and the score
			if (no_of_matches > 0)
			{
				Console.WriteLine("--------------------------------------");
				Console.WriteLine("You have {0} matches", no_of_matches);
				Console.WriteLine("You get {0} points", score);
			}

		}


	}
	public class Game
	{
		public static int[] player_scores = new int[2];//array to accumulate both player scores
		public static bool gameEnd;//bool when to end the game
		//game playe method
		public static void gamePlay()
		{
			int getPlayerAmount = player.num_of_players;
			gameEnd = false;
			//while loop until game is ended
			while (!gameEnd)
			{
				//for loop to iterate for player amount
				for (int i = 1; i <= getPlayerAmount; i++)
				{
					Console.WriteLine("--------------------------------------");
					Console.WriteLine("Player {0} turn", i);
					Console.WriteLine("--------------------------------------");
					Console.WriteLine("Press enter to roll dice");
					Console.ReadKey();
					//call die roll method
					dice.dieRoll();
					//call compare the roll method
					dice.checkRolls();
					//if player is 1
					if (i == 1)
					{
						//add score to player 1 index
						player_scores[0] = player_scores[0] + dice.score;
					}
					//else if player is 2
					else if (i == 2)
					{
						//add score to player 2 index
						player_scores[1] = player_scores[1] + dice.score;
					}
					//call the displaye score method
					displayScore();
					//set matches and score to 0 for next iteration
					dice.no_of_matches = 0;
					dice.score = 0;

				}
				//call check winner method to find the winner
				checkWinner();
			}

		}
		//output the score method
		public static void displayScore()
		{
			//output the player name and their score
			Console.WriteLine("--------------------------------------");
			Console.WriteLine("Total " + player.playerNames[0] + " score is " + player_scores[0]);
			Console.WriteLine("Total " + player.playerNames[1] + " score is " + player_scores[1]);
			Console.WriteLine("--------------------------------------");

		}
		//check winner method
		public static void checkWinner()
		{
			//if statement to check which player got to the winning point first, then ouput the winnert
			if (Game.player_scores[0] > player.goal)
			{
				Game.gameEnd = true;
				Console.WriteLine(player.playerNames[0] + " wins!");
				Console.WriteLine("--------------------------------------");
			}
			else if (player_scores[1] > player.goal)
			{
				Game.gameEnd = true;
				Console.WriteLine(player.playerNames[1] + " wins!");
			}
		}
	}
}
