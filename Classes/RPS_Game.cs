public class RPS_Game
{

    public static void rpsGame(GameSpecs game)
    {
        int currentRound = 0;
        int userScore = 0;
        int computerScore = 0;

        if(game.options.version == 0)
        {
            Console.WriteLine("Welcome to the Rock-Paper-Scissors game!\n");
            if(game.options.get(1) != null)
            {
                if(game.options.capType == 0){
                    Console.WriteLine($"Play {game.options.get(4)} rounds to end this.\n");
                }
                while(game.options.get(1) > currentRound){

                }
            }else{
                Console.WriteLine($"Play until someone reaches {game.options.get(0)} points.\n");
                while(game.options.get(0) > userScore || game.options.get(0) > computerScore){

                }   
            }

        }else{
            Console.WriteLine("Welcome to the Rock-Paper-Scissors game!\n");
        }
    }
    public static void rpsLogic(){
        string[] rps = {"rock", "paper", "scissors"};
        Random rng = new Random();
        int userChoice = 0;
        int computerChoice = 0;
        int result = 0;

        while(userChoice < 1 || userChoice > 3){
            Console.WriteLine($"Choose your weapon: \n1. {rps[0]} \n2. {rps[1]} \n3. {rps[2]} \n");
            userChoice = Convert.ToInt32(Console.ReadLine());
        }
        computerChoice = rng.Next(1, 4);

        if(userChoice == computerChoice){
            result = 0;
        }else if(userChoice == 1 && computerChoice == 3){
            result = 1;
        }else if(userChoice == 2 && computerChoice == 1){
            result = 1;
        }else if(userChoice == 3 && computerChoice == 2){
            result = 1;
        }else{
            result = 2;
        }

        switch(result){
            case 0:
                Console.WriteLine("It's a tie!");
                break;
            case 1:
                Console.WriteLine("You won!");
                break;
            case 2:
                Console.WriteLine("You lost!");
                break;
        }
    }
}
        