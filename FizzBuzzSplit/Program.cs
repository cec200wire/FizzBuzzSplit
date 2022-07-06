using System.Data;

namespace FizzBuzzSplit
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to the FizzBuzz Counter!");
            string repeat = "yes";
            while (repeat != "no")
            {
                CountFizzBuzz();
                Console.Write("Would you like to continue counting? [type 'no' to exit] ");
                repeat = Console.ReadLine();
            }
        }
        
        static void CountFizzBuzz()
        {
            int min = RequestInteger("Choose a starting integer: ", 1);
            int max = RequestInteger("Choose a finishing integer: ", min);
            int[] ruleIndex = {3, 5, 7, 11, 13, 19};
            int[] ruleActivate = new int[ruleIndex.Length];
            int rule = 0;
            Console.WriteLine("[3]Fizz  [5]Buzz  [7]Bang  [11]Bong  [13]Fezz  [17]Reverse");
            do
            {
                for (int r = 0; r < ruleIndex.Length; r++)
                {
                    if (ruleIndex[r] == rule)
                    {
                        ruleActivate[r] = 1;
                        rule = 0;
                    }
                };
                if (rule != 0)
                {
                    Console.WriteLine("Sorry, the integer {0} does not correspond to any known rule.", rule);
                }
                rule = RequestInteger("Please enter the integer corresponding to a rule you would like to implement," +
                                      " or enter 0 if there are no further rules you would like to add: ", -1);
            } while (rule != 0);
            
            for (int i = min; i <= max; i++)
            {
                string output = "";
                if (i % 3 == 0 & ruleActivate[0] == 1)
                {
                    output = Rule.fizz(output);
                }

                if (i % 5 == 0 & ruleActivate[1] == 1)
                {
                    output = Rule.buzz(output);
                }

                if (i % 7 == 0 & ruleActivate[2] == 1)
                {
                    output = Rule.bang(output);
                }

                if (i % 11 == 0 & ruleActivate[3] == 1)
                {
                    output = Rule.bong(output);
                }

                if (i % 13 == 0 & ruleActivate[4] == 1)
                {
                    output = Rule.fezz(output);
                }
                
                if (i % 17 == 0 & ruleActivate[5] == 1)
                {
                    output = Rule.reverse(output);
                }
                
                if (output == "")
                {
                    Console.WriteLine(i);
                }
                else
                {
                    Console.WriteLine(output);
                }
            }
        }
        
        static int RequestInteger(string text, int minimum)
        {
            int n = -1;
            string success = "no";
            while (success == "no")
            {
                Console.Write(text);
                string input = Console.ReadLine();
                if (int.TryParse(input, out n))
                {
                    if (n >= minimum)
                    {
                        success = "yes";
                    }
                    else
                    {
                        text = "That integer is too low, please choose another: ";
                    }
                }
                else
                {
                    text = "That is not a valid integer. Please enter a valid integer: ";
                }
                
            }
            return n;
        }
    }
    class Rule
    {
        public static string fizz(string display)
        {
            display += "Fizz";
            return display;
        }
        
        public static string buzz(string display)
        {
            display += "Buzz";
            return display;
        }
        
        public static string bang(string display)
        {
            display += "Bang";
            return display;
        }
        
        public static string bong(string display)
        {
            display = "Bong";
            return display;
        }
        
        public static string fezz(string display)
        {
            string tempFezzDisplay = display;
            for (int j = 0; j < tempFezzDisplay.Length; j++)
            {
                if (tempFezzDisplay[j] == 'B')
                {
                    display = tempFezzDisplay.Substring(0,j) + "Fezz" + tempFezzDisplay.Substring(j);
                }
            }
            if (display == tempFezzDisplay)
            {
                display += "Fezz";
            }
            return display;
        }
        
        public static string reverse(string display)
        {
            string tempRevDisplay = display;
            display = "";
            for (int k = tempRevDisplay.Length; k > 0; k -= 4)
            {
                display += tempRevDisplay.Substring(k - 4, 4);
            }
            return display;
        }
    }
}