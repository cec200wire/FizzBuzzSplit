using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;

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
                Fizz myFizz = new Fizz();
                output = myFizz.Apply(output, ruleIndex, ruleActivate, i);
                Buzz myBuzz = new Buzz();
                output = myBuzz.Apply(output, ruleIndex, ruleActivate, i);
                Bang myBang = new Bang();
                output = myBang.Apply(output, ruleIndex, ruleActivate, i);
                Bong myBong = new Bong();
                output = myBong.Apply(output, ruleIndex, ruleActivate, i);
                Fezz myFezz = new Fezz();
                output = myFezz.Apply(output, ruleIndex, ruleActivate, i);
                Reverse myReverse = new Reverse();
                output = myReverse.Apply(output, ruleIndex, ruleActivate, i);

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

    abstract class Rule
    {
        public bool Condition(int divisor, int[] index, int[] active, int n)
        {
            int toggle = 0;
            for (int k = 0; k < index.Length; k++)
            {
                if (index[k] == divisor)
                {
                    if (active[k] == 1)
                    {
                        toggle += 1;
                    }
                }
            }

            if (n % divisor == 0)
            {
                toggle += 1;
            }

            return (toggle == 2);
        }
        public abstract string Apply(string display, int[] index, int[] active, int n);
    }

    class Fizz : Rule
    {
        public override string Apply(string display, int[] index, int[] active, int n)
        {
            if (Condition(3, index, active, n))
            {
                display += "Fizz";
            }
            return display;
        }
    }

    class Buzz : Rule
    {
        public override string Apply(string display, int[] index, int[] active, int n)
        {
            if (Condition(5, index, active, n))
            {
                display += "Buzz";
            }
            return display;
        }
    }

    class Bang : Rule
    {
        public override string Apply(string display, int[] index, int[] active, int n)
        {
            if (Condition(7, index, active, n))
            {
                display += "Bang";
            }
            return display;
        }
    }

    class Bong : Rule
    {
        public override string Apply(string display, int[] index, int[] active, int n)
        {
            if (Condition(11, index, active, n))
            {
                display = "Bong";
            }
            return display;
        }
    }

    class Fezz : Rule
    {
        public override string Apply(string display, int[] index, int[] active, int n)
        {
            if (Condition(13, index, active, n))
            {
                string tempFezzDisplay = display;
                for (int j = 0; j < tempFezzDisplay.Length; j++)
                {
                    if (tempFezzDisplay[j] == 'B')
                    {
                        display = tempFezzDisplay.Substring(0, j) + "Fezz" + tempFezzDisplay.Substring(j);
                    }
                }

                if (display == tempFezzDisplay)
                {
                    display += "Fezz";
                }
            }
            return display;
        }
    }

    class Reverse : Rule
    {
        public override string Apply(string display, int[] index, int[] active, int n)
        {
            if (Condition(17, index, active, n))
            {
                string tempRevDisplay = display;
                display = "";
                for (int k = tempRevDisplay.Length; k > 0; k -= 4)
                {
                    display += tempRevDisplay.Substring(k - 4, 4);
                }
            }
            return display;
        }
    }
}