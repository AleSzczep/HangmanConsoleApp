using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Hangman
{
    public class Game
    {
        public void GameLogic()
        {
            int numberOfFails;
            string randomWord;
            int randomDbItem;
            int lifesCounter = 10;
            int numberOfGuessed = 0;
            bool winner = false;

            List<string> wordsDB = new List<string>();

            string[] wordsFromFileArray = File.ReadLines("randomWordsTXT.txt").ToArray();

            wordsDB.AddRange(wordsFromFileArray);

            List<char> lettersOfWord = new List<char>();

            List<char> rememberedLetters = new List<char>();

            Random random = new Random();

            randomDbItem = random.Next(wordsDB.Count);

            randomWord = wordsDB[randomDbItem];

            int randomWordLenght = randomWord.Length;
            //Adding each of the drawn word letters to char's list
            //ex: WORD  [1] = W, [2] = O, [3] = R, [4] = D
            for (int i = 0; i < randomWordLenght; i++)
            {
                lettersOfWord.Add(randomWord[i]);
            }
            //Empty line
            Console.WriteLine();
            //Writing underlines first time (after drawn word) ex: WORD (4 letters) ==> _ _ _ _
            for (int i = 0; i < randomWordLenght; i++)
            {
                Console.Write("_ ");
            }

            do
            {
                //Empty line
                Console.WriteLine("\n");

                //Reading user input
                string userAnswer = Console.ReadLine();

                //Checking if only one letter
                if (userAnswer.Length == 1)
                {
                    //Lowercase, uppercase letters from user doesn't matter 
                    char letter = char.Parse(userAnswer.ToLower());

                    //Checking if drawn word contains letter entered by user 
                    //and whether it's already entered
                    if (randomWord.Contains(letter) && !rememberedLetters.Contains(letter))
                    {
                        //Empty line
                        Console.WriteLine();

                        //Add entered letter do remembered letters list
                        rememberedLetters.Add(letter);

                        //Informs user about guessed letter
                        Console.WriteLine("Trafiłeś!");

                        //For each letter of the drawn word
                        for (int i = 0; i < randomWordLenght; i++)
                        {
                            //If letter of drawn word matches to entered letter (by user) 
                            //reaplce "_" by this letter
                            //Ex: letter entered by user "R", ===> _ _ R _
                            if (lettersOfWord[i].Equals(letter))
                            {
                                //Console.Write(letter + " ");
                                //Counting number of guessed letter to know when end a game 
                                numberOfGuessed++;
                            }
                        }
                        //Checking if user won
                        if (numberOfGuessed == randomWordLenght)
                        {
                            winner = true;
                        }

                    }
                    //If user didn't guess the letter of drawn word
                    else
                    {
                        //Info about miss
                        Console.WriteLine("Nie trafiłeś");

                        //Decrement user chances
                        lifesCounter--;
                    }
                }
                //If user entered more than 1 char 
                else
                {
                    //Info about miss
                    Console.WriteLine("Nie trafiłeś");

                    //Info about max allowed number of chars 
                    Console.WriteLine("Maksymalna dozwolona ilość liter to 1");

                    //Decrement user chances
                    lifesCounter--;
                }

                //Shows the status of the word being guessed
                for (int i = 0; i < randomWordLenght; i++)
                {
                    if (rememberedLetters.Contains(lettersOfWord[i]))
                    {
                        Console.Write(lettersOfWord[i] + " ");
                    }
                    else
                    {
                        Console.Write("_ ");
                    }
                }
                //Info about user chances
                Console.WriteLine("\nPozostała ilość szans: " + lifesCounter);


                DrawHangman(lifesCounter);

                static void DrawHangman(int attempts)
                {
                    string[] hangmanStages = new string[]
                    {
//0
            @"
  +---+
  |   |
  O   |
 /|\  |
 / \  |
      |
      |
=========",
//1
            @"
  +---+
  |   |
  O   |
 /|\  |
 /    |
      |
      |
=========",
//2
            @"
  +---+
  |   |
  O   |
 /|\  |
      |
      |
      |
=========",
//3
            @"
  +---+
  |   |
  |   |
  O   |
 /|   |
      |
      |
=========",
//4
            @"
  +---+
  |   |
  |   |
  O   |
  |   |
      |
      |
=========",
//5
            @"
  +---+
  |   |
  |   |
  O   |
      |
      |
      |
=========",
//6
            @"
  +---+
  |   |  
  |   |
      |     
      |
      |
      |
=========",
//7
            @"
  +---+
  |   |
      |
      |
      |
      |
      |
=========",
//8
            @"
  +---+
      |
      |
      |
      |
      |
      |
=========",
//9
            @"
      |
      |
      |
      |
      |
      |
=========",
//10 
            @" 
      
      

      
      
      
========="
                    };

                    Console.WriteLine(hangmanStages[attempts]);
                }






            }
            //Each game ends when user:
            //- won
            //- exhausted all chances 
            while (!winner && lifesCounter > 0);

            //Informs user about win
            if (winner)
            {
                Console.WriteLine("\nWYGRAŁEŚ!!! Gratulacje");
            }
            //Informs user about loss
            else
            {
                Console.WriteLine("\nNiestety przegrałeś");
            }
            //Shows hidden word
            Console.WriteLine("Ukryte słowo to: " + randomWord);
        }
    }
}
