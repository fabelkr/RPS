public class RPS_Game
{

    public static void rpsGame(GameSpecs game)
    {

        if(game.options.version == 0)
        {
            Console.WriteLine("Welcome to the Rock-Paper-Scissors game!\n");
            if(game.options.get(1) != 2)
            {
                if(game.options.capType == 0){
                    Console.WriteLine($"Play {game.options.get(4)} rounds to end this.\n");
                    rpsLogic(game.options.get(4), 0, game.options.get(0));
                } else{
                    Console.WriteLine($"Play until someone reaches {game.options.get(4)} points.\n");
                    rpsLogic(game.options.get(4), 1, game.options.get(0));
                }
            }
            else{
                Console.WriteLine($"Play infinitely long game (it is surely gonna be fun)\n");
                rpsLogic(null, null, game.options.get(0));
            }

        }else{
            Console.WriteLine("Welcome to the Rock-Paper-Scissors-Lizard-Spock game!\n");
            if(game.options.get(1) != 2)
            {
                if(game.options.capType == 0){
                    Console.WriteLine($"Play {game.options.get(4)} rounds to end this.\n");
                    RPSLS_Game.rpslsLogic(game.options.get(4), 0, game.options.get(0));
                } else{
                    Console.WriteLine($"Play until someone reaches {game.options.get(4)} points.\n");
                    RPSLS_Game.rpslsLogic(game.options.get(4), 1, game.options.get(0));
                }
            }
            else{
                Console.WriteLine($"Play infinitely long game (it is surely gonna be fun)\n");
                RPSLS_Game.rpslsLogic(null, null, game.options.get(0));
            }
        }
    }
    public static void rpsLogic(int? capCount, int? capType, int? result){
        string[] rps;
        rps = ["rock", "paper", "scissors"];
        Random rng = new Random();
        int userChoice;
        int computerChoice;
        bool? outcome = null;
        int currentRound = 0;
        int scoreComputer = 0;
        int scorePlayer = 0;

        if(result == 1 && capType == null){
            Console.WriteLine("You chose an endless misery knowing you won't be able to win a single time, didn't you?\n Play as long as your heart can take it, or simply just kill your terminal :)\n");
        }else if(capType == null){
            Console.WriteLine("You chose an endless misery, didn't you?\n Play as long as your heart can take it, or simply just kill your terminal :)\n");
        }
        
        while((capType == 0 && currentRound < capCount) || 
                (capType == 1 && scorePlayer < capCount && scoreComputer < capCount) || 
                (capType == null && true)){
            Console.WriteLine($"\nChoose your weapon: \n1. {rps[0]} \n2. {rps[1]} \n3. {rps[2]} \n");
            
            //input

            userChoice = Convert.ToInt32(Console.ReadLine());
            while(userChoice < 1 || userChoice > 3){
                Console.WriteLine("Invalid input, try again.");
                userChoice = Convert.ToInt32(Console.ReadLine());
            }
            if(result == 2){
                computerChoice = rng.Next(1, 4);
            }else if(result == 1){
                computerChoice = userChoice + 1;
                if(userChoice == 3){
                    computerChoice = 1;
                }
            }else{
                computerChoice = userChoice - 1;
                if(userChoice == 1){
                    computerChoice = 3;
                }
            }
            //logic
                if(userChoice == computerChoice){
                    outcome = false;
                }else if(userChoice == 1 && computerChoice == 3){
                    outcome = true;
                }else if(userChoice == 2 && computerChoice == 1){
                    outcome = true;
                }else if (userChoice == 3 && computerChoice == 2){
                    outcome = true;
                }
                else{
                    outcome = null;
                }
            //result
            switch(outcome){
                case false:
                    Console.WriteLine("\nIt's a tie!\n");
                    break;
                case true:
                    Console.WriteLine("\nYou won!\n");
                    scorePlayer++;
                    break;
                case null:
                    Console.WriteLine("\nYou lost!\n");
                    scoreComputer++;
                    break;
            }
            Console.Write("Score: \nPlayer: " + scorePlayer + "\nComputer: " + scoreComputer + "\n");
            //incrementation
            if(capType == 0){
                currentRound++;
            }
        }
        if (scorePlayer > scoreComputer)
        {
            Console.WriteLine("\nYou won the game!\n");
        }
        else if (scorePlayer == scoreComputer)
        {
            Console.WriteLine("\nThe game ended in a tie!\n");
        }
        else
        {
            Console.WriteLine("\nYou lost the game!\n");
        }
    }
}
        