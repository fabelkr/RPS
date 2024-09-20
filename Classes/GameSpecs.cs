using System.Threading.Tasks.Dataflow;

public struct GameOptions
{
    public GameOptions(int? result = null, int? length = null, int? version = null, int? capType = null, int? capCount = null)
    {
        this.result = result;
        this.length = length;
        this.version = version;
        this.capType = capType;
        this.capCount = capCount;
    }
    public int? result;
    //until rounds = 0
    //until score = 1
    //endless = 2
    public int? length;
    //rock paper scissors = 0
    //rock paper scissors lizard spock = 1
    public int? version;
    public int? capType;
    public int? capCount;

    public int?[] toArray(){
        return [result, length, version, capType, capCount];
    }
    public string[] specNames(){
        return ["result", "length", "version", "capType", "capCount"];
    }
    public int? get(int key){
        switch(key){
            case 0:
                return result;
            case 1:
                return length;
            case 2:
                return version;
            default:
                return null;
        }
    }
}

public class GameSpecs
{
    private GameOptions options;
    //constructor
    public GameSpecs()
    {
        options = new GameOptions();
    }


    public void setGameSpecs()
    {
        Console.WriteLine("Main menu \n");
        Console.WriteLine("My game settings:\n");
        writeSettings();
        ConsoleColor settingColor = options.result == null ? ConsoleColor.Red : ConsoleColor.Green;
        Console.ForegroundColor = settingColor;
        Console.ResetColor();
        Console.Write("0. Exit\n1. Set result of the game\n2. Set length of the game\n3. Set version of the game\n4. All set, start the game! \n");

        switch(Console.ReadLine()){
            case "0":
                //TODO: loading fake animation
                Console.Write("Exiting the game \nGoodbye :(\n");
                Environment.Exit(0);
                break;

            case "1":
                options.result = setSpecs(options.result, "result");
                setGameSpecs();
                break;

            case "2":
                options.length = setSpecs(options.length, "length");
                setGameSpecs();
                break;

            case "3":
                options.version = setSpecs(options.version, "version");
                setGameSpecs();
                break;

            case "4":
                if(options.result == null || options.length == null || options.version == null)
                {
                    Console.WriteLine("Not all specs are set\n");
                    setGameSpecs();
                    break;
                }
                else
                {
                    // TODO: loading fake animation
                    Console.Write("All specs are set \nStarting the game\n");
                    break;
                }

            default:
                Console.WriteLine("Invalid input for main menu");
                setGameSpecs();
                break;
        }
    }

    private int? setSpecs(int? spec, string specName)
    {
        if (spec == null)
        {
            Console.WriteLine($"Set {specName}\n");
            spec = getSpecsFromInput(spec, specName);
        }
        else
        {
            Console.WriteLine($"{specName} already set");
            Atomic.accept("Do you want to change it? (y/n)");
            spec = getSpecsFromInput(spec, specName);
        }
        return spec;
    }

    private int? getSpecsFromInput(int? spec, string specName)
    {
        if(specName == "result")
        {
            Console.Write("0. always win \n1. always lose \n2. random\n");
        }
        else if(specName == "length")
        {
            Console.Write("0. until rounds \n1. until score \n2. endless\n");
        }
        else if(specName == "version")
        {
            Console.Write("0. rock paper scissors \n1. rock paper scissors lizard spock\n");
        }
        switch(Console.ReadLine()){
            case "0":
                spec = 0;
                if(specName == "length")
                {
                    Console.WriteLine("Set the number of rounds");
                    options.capCount = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                break;

            case "1":
                spec = 1;
                if(specName == "length")
                {
                    Console.WriteLine("Set the score cap");
                    options.capCount = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                break;

            case "2":
                if (specName != "version")
                {
                    spec = 2;
                }
                break;

            default:
                Console.WriteLine("Invalid input for setting " + specName);
                getSpecsFromInput(spec, specName);
                break;
        }
        return spec;
    }
    private void writeSettings(){
        Console.ForegroundColor = ConsoleColor.Green;

        Dictionary<string, string[]> valueMappings = new Dictionary<string, string[]>{
            { "result", [
                "Unicorn rainbow poop",
                "Demonic necromancer",
                "Tough fight",
                ]
            },
            {"length", [
                $"Play {options.capCount} rounds to end this",
                $"Score {options.capCount} to end this",
                "Endless misery",
                ]
            },
            {"version", [
                "Rock Paper Scissors",
                "Rock Paper Scissors Lizard Spock",
                ]
            }
        };
        int currentField = 0;
        foreach(string field in valueMappings.Keys){
            int? fieldIndex = options.get(currentField);
            Console.ForegroundColor = ConsoleColor.Green;
            if(fieldIndex == null) Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(field + ": " + (fieldIndex != null ? valueMappings[field][(int)fieldIndex] : "Is not set"));
            currentField++;
        }
        Console.ResetColor();
        Console.WriteLine();
    }
}

