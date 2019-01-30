using System;
using System.Collections.Generic;
using System.IO;

namespace ProgrammingAssignment
{
	//class to do the text processing
	public class CheckText
	{
		//methods counts the number of sentences in the string
		public void CountSentences(string sentence)//string is passed as a parameter
		{
			int count = 0;//declare a variable count and set it to 0
						  //for loop to iterate through the string
			for (int i = 0; i < sentence.Length; i++)
			{
				//switch statement to look for the sentence endings 
				switch (sentence[i])
				{
					case '.':
						count++; // counter increments whenever it finds a full stop
						break;
					case '?':
						count++; // counter increments whenever it finds a question mark
						break;
					case '!':
						count++; // counter increments whenever it finds a exclamation mark
						break;

				}
			}
			//outputs to the console the total count of sentences
			Console.WriteLine("Number of sentences: {0}", count);
		}
		//method to count upper and lower case letters
		public void CheckCase(string textCase)
		{
			int countUpper = 0;//counter to hold no of upper case letters
			int countLower = 0;//counter to hold no of lower case letters

			//for loop to loop through the user input
			for (int i = 0; i < textCase.Length; i++)
			{
				if (char.IsUpper(textCase[i])) countUpper++;//if the current character in the string is upper case, then increment upper counter
				if (char.IsLower(textCase[i])) countLower++;//if the current character in the string is lower case, then increment lower counter
			}
			//output to the console the total number of upper and lower case letters
			Console.WriteLine("Number of upper case letters : {0}", countUpper);
			Console.WriteLine("Number of lower case letters : {0}", countLower);

		}
		//method to count the number of vowels in the string
		public void CountVowels(string str)
		{
			int count = 0;//counter to hold the no of vowels
						  //char array to hold lower and uppercase vowels
			char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
			//foreach loop to loop through each character in the user input
			foreach (char element in str)
			{
				//for loop to iterate through the array
				for (int i = 0; i < vowels.Length; i++)
				{
					//if an element from the user input matches the array element, then increment the vowel counter
					if (element == vowels[i])
					{
						count++;
					}
				}
			}
			//output the total number of vowels to the console
			Console.WriteLine("Number of vowels: {0}", count);
		}
		//method to count the consonants
		public void CountConsonants(string con)
		{
			int count = 0;//counter to hold the no of consonants
						  //char array to hold the upper and lower case consonants
			char[] consonants = { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z',
			'B','C','D','F','G','H','J','K','L','M','N','P','Q','R','S','T','V','W','X','Y','Z'};
			//foreach loop to loop through each character in the user input
			foreach (char element in con)
			{
				//for loop to iterate through the array
				for (int i = 0; i < consonants.Length; i++)
				{
					//if an element from the user input matches the array elemet, then increment the consonant counter
					if (element == consonants[i])
					{
						count++;
					}
				}
			}
			//output to the console the total number of consonants
			Console.WriteLine("Number of consonants: {0}", count);
		}
		public void LetterFrequency(string frequency)
		{
			//array to hold the frequency
			int[] store = new int[(int)char.MaxValue];

			//foreach loop to iterate over the characters in the string
			foreach (char x in frequency)
			{
				//add the chars to the array
				store[(int)x]++;
			}
			//output all the letters found to the console
			for (int l = 0; l < (int)char.MaxValue; l++)
			{
				if (store[l] > 0 && char.IsLetter((char)l))
				{
					Console.WriteLine("Letter: {0}  Frequency: {1}", (char)l, store[l]);
				}
			}
		}
		//method to create a new long words file
		public void LongWords(string userText)
		{
			//array to store the words from the array
			string[] words = userText.Split(' ');
			//a list is used to add the words that are greater than 7 letter
			List<string> longWords = new List<string>();
			//foreach loop to iterate through words array 
			foreach (string word in words)
			{
				if (word.Length > 7)
					{
						longWords.Add(word);
						//variable holds the file path of the new long words file that is created
						string outputFile = "/Users/shivampanday/Desktop/ProgrammingAssignment/ProgrammingAssignment/testingFiles/longwords.txt";
						//creates a new file with all the words that are greater than 7 letters
						File.WriteAllLines(outputFile, longWords);

					}
			}
		}
	}
	//new class for sentiment analysis
	public class sentiment
	{
		//method for mood analysis
		public void moodAnalysis(string mood)
		{
			//variable to hold the negative words file path
			string negativeFile = @"/Users/shivampanday/Desktop/ProgrammingAssignment/ProgrammingAssignment/moodFiles/negative.txt";
			//variable to hold the positive words positive file path
			string positiveFile = @"/Users/shivampanday/Desktop/ProgrammingAssignment/ProgrammingAssignment/moodFiles/positive.txt";
			//read the the files into arrays
			string[] negativeText = File.ReadAllLines(negativeFile);
			string[] positiveText = File.ReadAllLines(positiveFile);

			//foreach loops to iterate through the file, if any words from the user input match the files, then output the mood
			foreach (string negative in negativeText)
			{
				if (mood == negative)
				{
					Console.WriteLine("The mood is {0}", negative);
					Console.ReadLine();
				}
			}
			foreach (string positive in positiveText)
			{
				if (mood == positive)
				{
					Console.WriteLine("The mood is positive");
					Console.ReadLine();
				}
			}
		}
	}
	//main class
	public class MainClass
	{
		//main method
		public static void Main(string[] args)
		{
			int option;//variable to hold the user menu option
			bool valid = true;//boolean initially set to true, so the while loop runs
			bool filevalid = true;//boolean initally set to true, so the while loop in case 2 runs
			string usertext;//string to hold the user input from keyboard
			string filePath;//string to hold the file path entered by the user
			//while loop runs until a format exceptiong 
			while (valid)
			{
				//boolean is set to false
				valid = false;
				//try catch statements for error handling when the input is not an integer
				try
				{
					//user menu is shown on the screen
					Console.WriteLine("1.Do you want to enter the text via the keyboard?");
					Console.WriteLine("2.Do you want to read in the text from a file?");
					//the option user chooses is held by this variable
					option = Convert.ToInt32(Console.ReadLine());
					//switch statement is used here to process option input 1 or 2
					switch (option)
					{
						//when the option is one the following statements are executed
						case 1:
							//user is asked to enter a string via keyboard
							Console.WriteLine("Enter the text to be analysed");
							usertext = Console.ReadLine();//the string is read into this variable
							var analysis = new CheckText();//an oject of the class is instantiated
							//the user input string is passed onto the methods in CheckText class as parameters
							analysis.CountSentences(usertext);
							analysis.CountVowels(usertext);
							analysis.CountConsonants(usertext);
							analysis.CheckCase(usertext);
							analysis.LetterFrequency(usertext);
							//an object of the class sentiment is instantiated
							var textMood = new sentiment();//
							textMood.moodAnalysis(usertext);//the user text is passed onto the method as parameter
							break;
							//the following statements are executed when option 2 is chosen
						case 2:
							//while loop runs until the file path is corrext
							while (filevalid)
							{
								filevalid = false;//boolean is set to false, runs until true
								//try catch statement for error handling, when the filepath is invalid
								try
								{
									//ask the user to input a filepath
									Console.WriteLine("Please enter file name");
									filePath = Console.ReadLine();//string to read the filepath
									string filename = @"" + filePath;//variable to hold the complete file path
									string text = File.ReadAllText(filename);//file is read and stored as a string 
									var fileAnalysis = new CheckText();//an object of the class CheckText is instantiated
									//the text file is passed onto the methods in CheckText as a string parameter
									fileAnalysis.CountSentences(text);
									fileAnalysis.CountVowels(text);
									fileAnalysis.CountConsonants(text);
									fileAnalysis.CheckCase(text);
									fileAnalysis.LetterFrequency(text);
									fileAnalysis.LongWords(text);
								}
								//this catches an invalid file path
								catch (FileNotFoundException)
								{
									//user is asked to input the file path again
									Console.WriteLine("Invalid file path, Enter a vaild file path");
									filevalid = true;
								}
							}
							break;
					}
				}
				//catches a format exception for the menu options
				catch (FormatException )
				{
					//ask the user to input option 1 or 2
					Console.WriteLine("Error... Please enter option 1 or 2");
					valid = true;
				}
			}
		}
	}
}