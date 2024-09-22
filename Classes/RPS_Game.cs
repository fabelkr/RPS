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
                    rpsLogic(game.options.get(4), false, 0);
                } else{
                    Console.WriteLine($"Play until someone reaches {game.options.get(4)} points.\n");
                    rpsLogic(game.options.get(4), false, 1);  
                }
            }
            else{
                Console.WriteLine($"Play infinitely long game (it is surely gonna be fun)\n");
                rpsLogic(null, false, null);
            }

        }else{
            Console.WriteLine("Welcome to the Rock-Paper-Scissors-Lizard-Spock game!\n");
            // rpsLogic(game.options.get(4), true);
        }
    }
    public static void rpsLogic(int? capCount, bool version, int? capType){
        string[] rps;
        if(version){
            rps = ["rock", "paper", "scissors", "lizard", "spock"];
        }else{
            rps = ["rock", "paper", "scissors"];
        }
        Random rng = new Random();
        int userChoice;
        int computerChoice;
        bool? result = null;
        int currentRound = 0;
        int scoreComputer = 0;
        int scorePlayer = 0;

        if(version){
            Console.WriteLine($"Choose your weapon: \n1. {rps[0]} \n2. {rps[1]} \n3. {rps[2]} \n4. {rps[3]} \n5. {rps[4]} \n");
            computerChoice = rng.Next(1, 6);
            userChoice = Convert.ToInt32(Console.ReadLine());


            switch(result){
                case false:
                    Console.WriteLine("It's a tie!");
                    break;
                case true:
                    Console.WriteLine("You won!");
                    break;
                case null:
                    Console.WriteLine("You lost!");
                    break;
            }
        }else{
            while(capType == 0 ? currentRound < capCount : scoreComputer < capCount || scorePlayer < capCount){
                Console.WriteLine($"\nChoose your weapon: \n1. {rps[0]} \n2. {rps[1]} \n3. {rps[2]} \n");
                //input
                computerChoice = rng.Next(1, 4);
                userChoice = Convert.ToInt32(Console.ReadLine());
                //logic
                if(userChoice == computerChoice){
                    result = false;
                }else if(userChoice == 1 && computerChoice == 3){
                    result = true;
                }else if(userChoice == 2 && computerChoice == 1){
                    result = true;
                }else if (userChoice == 3 && computerChoice == 2){
                    result = true;
                }
                else{
                    result = null;
                }
                //result
                switch(result){
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
}
        