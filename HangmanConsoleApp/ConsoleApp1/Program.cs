using Hangman;

internal class Program
{
    private static void Main(string[] args)
    {
        Menu menu = new Menu();

        Game game = new Game();

        do
        {
            //Player introduction (cosnoleTXT's)
            menu.PlayerIntroduction();
            //Game logics
            game.GameLogic();
            //After game ends
            menu.PlayerDecision();

        }//Turn off app when player call "1" in keyboard after game
        while (menu.playerChooseNumber != (int)Decision.EXIT);
    }
}