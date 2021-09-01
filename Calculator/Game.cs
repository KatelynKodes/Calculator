using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    class Game
    {
        public int firstNum;
        public int secondNum;

        public string input;
        public string Operation;

        public bool CalcOpen = true;

        public void Run()
        {
            while (CalcOpen)
            {
                SelectOption();
            }
        }

        /// <summary>
        /// Selects the operation the player would like to preform
        /// </summary>
        void SelectOption()
        {
            bool MenuOpen = true;
            while (MenuOpen)
            {
                Console.Clear();
                Console.WriteLine("Choose if you'd like to: \n [A] Add \n [S] Subtract \n [M] Multiply. \n Press [E] or type \"Exit\" to leave the calculator");
                Console.Write(">");
                input = Console.ReadLine();

                //Checks if the input is equal to an actual operation in the menu
                if (input.ToLower() == "a" ||input.ToLower() == "add")
                {
                    MenuOpen = false;
                    //Sets operation
                    Operation = "add";
                    InputNumbers();
                }
                else if (input.ToLower() == "s" || input.ToLower() == "subtract")
                {
                    MenuOpen = false;
                    //Sets operation
                    Operation = "subtract";
                    InputNumbers();
                }
                else if (input.ToLower() == "m" || input.ToLower() == "multiply")
                {
                    MenuOpen = false;
                    //Sets operation
                    Operation = "multiply";
                    InputNumbers();
                }
                else if (input.ToLower() == "e" || input.ToLower() == "exit")
                {
                    MenuOpen = false;
                    //Calls the CloseCalculator Method.
                    CloseCalculator();
                }
                else
                {
                    Console.WriteLine("That is not a valid input");
                }
            }
        }

        /// <summary>
        /// Allows player to input numbers
        /// </summary>
        void InputNumbers()
        {
            string Num1Input;
            bool num1Success;
            bool num2Success;
            string Num2Input;
            bool completeOperation = false;

            while (!completeOperation)
            {
                Console.Clear();
                Console.WriteLine("Input your first number. (MUST be an integer, no decimal values)");
                Console.Write(">");
                Num1Input = Console.ReadLine();
                num1Success = int.TryParse(Num1Input, out firstNum);

                //Detects if Num1Input is actually an integer.
                if (num1Success)
                {
                    bool validSecondNumber = false;
                    while (!validSecondNumber)
                    {
                        Console.WriteLine("Input your second number. (MUST be an integer, no decimal values)");
                        Console.Write(">");
                        Num2Input = Console.ReadLine();

                        //Detects if Num2Input is actually an integer.
                        num2Success = int.TryParse(Num2Input, out secondNum);
                        if (num2Success)
                        {
                            //Sets both values to true, exiting the loop
                            completeOperation = true;
                            validSecondNumber = true;
                        }
                        else
                        {
                            Console.WriteLine("That is not a valid input");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("That is not a valid input");
                }
            }


            // Inputs firstNum and secondNum into the appropriate operation
            // based on the Operation string
            if (Operation == "add")
            {
                AddNums(firstNum, secondNum);
            }
            else if (Operation == "subtract")
            {
                SubNums(firstNum, secondNum);
            }
            else if (Operation == "multiply")
            {
                Multiply(firstNum, secondNum);
            }
        }

        /// <summary>
        /// Closes Calculator
        /// </summary>
        void CloseCalculator()
        {
            bool InputValid = false;
            
            while (!InputValid)
            {
                Console.Clear();
                Console.WriteLine("Would you like to close the calculator \n[Y] Yes \n[N] No");
                Console.Write(">");
                string CloseInpt = Console.ReadLine();
                if (CloseInpt.ToLower() == "y" || CloseInpt.ToLower() == "yes")
                {
                    CalcOpen = false;
                    InputValid = true;
                }
                else if (CloseInpt.ToLower() == "n" || CloseInpt.ToLower() == "no")
                {
                    InputValid = true;
                }
                else
                {
                    Console.WriteLine("Not a valid input");
                }
            }
        }

        /// <summary>
        /// Adds num1 and num2 together, returning a value of totalvalue;
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        int AddNums(int num1, int num2)
        {
            int totalvalue = num1 + num2;
            Console.WriteLine(num1 + " + " + num2 + " = " + totalvalue);
            Console.ReadKey();
            return totalvalue;
        }

        /// <summary>
        /// Subtracts num2 from num1, returning a value of subtractvalue;
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        int SubNums(int num1, int num2)
        {
            int subtractvalue = num1 - num2;
            Console.WriteLine(num1 + " - " + num2 + " = " + subtractvalue);
            Console.ReadKey();
            return subtractvalue;
        }

        /// <summary>
        /// Multiplies num1 and num2 together, returning a value of mult_Value;
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        int Multiply(int num1, int num2)
        {
            int mult_Value = num1 * num2;
            Console.WriteLine(num1 + " x " + num2 + " = " + mult_Value);
            Console.ReadKey();
            return mult_Value;
        }

    }
}
