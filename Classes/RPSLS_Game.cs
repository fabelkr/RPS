using System.Security.Cryptography.X509Certificates;

public class RPSLS_Game
{
    public static void rpslsGame(GameSpecs game)
    {
        // Example usage of rpslsLogic
        rpslsLogic(5, 1, null);
    }

    public static void rpslsLogic(int? capCount, int? capType, int? result)
    {
        string[] rpsls = { "rock", "paper", "scissors", "lizard", "spock" };
        Random rng = new Random();
        int userChoice;
        int computerChoice;
        // bool? outcome = null;
        int currentRound = 0;
        int scoreComputer = 0;
        int scorePlayer = 0;

        while((capType == 0 && currentRound < capCount) || 
                (capType == 1 && scorePlayer < capCount && scoreComputer < capCount) || 
                (capType == null && true)){
            Console.WriteLine("\nChoose your weapon:");
            for (int i = 0; i < rpsls.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {rpsls[i]}");
            }

            userChoice = Convert.ToInt32(Console.ReadLine());

            computerChoice = rng.Next(1, 6);

            Console.WriteLine($"You chose {rpsls[userChoice - 1]}");
            Console.WriteLine($"Computer chose {rpsls[computerChoice - 1]}");

            currentRound++;

            if (userChoice == computerChoice)
            {
                Console.WriteLine("It's a tie!");
            }
            else if ((userChoice == 1 && (computerChoice == 3 || computerChoice == 4)) ||
                    (userChoice == 2 && (computerChoice == 1 || computerChoice == 5)) ||
                    (userChoice == 3 && (computerChoice == 2 || computerChoice == 4)) ||
                    (userChoice == 4 && (computerChoice == 2 || computerChoice == 5)) ||
                    (userChoice == 5 && (computerChoice == 1 || computerChoice == 3)))
            {
                Console.WriteLine("You win!");
                scorePlayer++;
            }
            else
            {
                Console.WriteLine("You lose!");
                scoreComputer++;
            }
            Console.Write("Your score: " + scorePlayer +" \nComputer score: " + scoreComputer + "\n");
        }
        if(scorePlayer > scoreComputer){
            Console.WriteLine("You won the game!");
        }else if(scorePlayer < scoreComputer){
            Console.WriteLine("You lost the game!");
        }else{
            Console.WriteLine("The game ended a tie!");
        }
    }
}