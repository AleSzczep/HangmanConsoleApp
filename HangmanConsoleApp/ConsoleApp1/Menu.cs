using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class Menu
    {
        public bool userChooseCheck;
        public int playerChooseNumber;

        public void PlayerIntroduction()
        {
            Console.WriteLine();
            Console.WriteLine("Witaj w grze Wisielec.");
            Console.WriteLine("System wylosuje słowo z bazy danych.");
            Console.WriteLine("Wciśnij dowolny przycisk na klawiaturze, aby rozpocząć");
            Console.ReadKey();
        }

        public void PlayerDecision()
        {
            Console.WriteLine();
            Console.WriteLine("*****OPCJE GRY*****");
            Console.WriteLine("0 - Rozpocznij od nowa");
            Console.WriteLine("1 - Koniec gry");
            userChooseCheck = int.TryParse(Console.ReadLine(), out int number);

            if (!userChooseCheck)
            {
                PlayerDecision();
            }

            playerChooseNumber = number;
        }
    }
}
