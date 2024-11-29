using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsUkol2___HE
{
    internal class Program
    {
        static void PrintArray(int[,] arrayToPrint)
        {
            for (int i = 0; i < arrayToPrint.GetLength(0); i++)
            {
                for (int j = 0; j < arrayToPrint.GetLength(1); j++)
                {
                    Console.Write(arrayToPrint[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static int CheckIfNumber(string number)
        {
            int numberValue = Convert.ToInt32(number);
            return numberValue;
        }
        static void Main(string[] args)
        {
            /*
            string imput = Console.ReadLine();
            char firstChar = imput[0];
            List<char> rows = new List<char> {'a', 'b'};
            int index = rows.IndexOf(firstChar);
            */

            //souřadnice hráče (h) pojmenované anglicky, souřadnice počítače (p) německy (pro rozlišení)

            int[,] myArray = new int[11, 11]; //vytvoření pole h
            int number = -1;           
            for(int i = 0; i < myArray.GetLength(0); i++)
            {
                myArray[i, 0] = number + 1;
                number++;
            }
            number = -1;
            for (int j = 0; j < myArray.GetLength(1); j++)
            {
                myArray[0, j] = number + 1;
                number++;
            }

            int[,] opponentsArray = new int[11, 11]; //vytvoření pole p
            int otherNumber = -1;
            for (int i = 0; i < opponentsArray.GetLength(0); i++)
            {
                opponentsArray[i, 0] = otherNumber + 1;
                otherNumber++;
            }
            otherNumber = -1;
            for (int j = 0; j < opponentsArray.GetLength(1); j++)
            {
                opponentsArray[0, j] = otherNumber + 1;
                otherNumber++;
            }

            PrintArray(myArray); PrintArray(opponentsArray);

            int airplane = 5; int battle = 4; int cruiser = 3; int submarine = 3; int destroyer = 2; //délky lodí

            Random rnd = new Random();
            int einX = rnd.Next(1, 11); int einY = rnd.Next(1, 11); int zweiX = rnd.Next(1, 11); int zweiY = rnd.Next(1, 11); int dreiX = rnd.Next(1, 11); int dreiY = rnd.Next(1, 11); int vierX = rnd.Next(1, 11); int vierY = rnd.Next(1, 11); int funfX = rnd.Next(1, 11); int funfY = rnd.Next(1, 11); //vytvoření souřadnic p
            int directionEin = rnd.Next(0, 2); int directionZwei = rnd.Next(0, 2); int directionDrei = rnd.Next(0, 2); int directionVier = rnd.Next(0, 2); int directionFunf = rnd.Next(0, 2); //směry lodí p

            for (int i = 0; i < airplane; i++)
            {
                for ()
            }
            
                /*for (int i = 0; i < airplane; i++)
                {
                    if (opponentsArray[einX, einY] != 0)
                    {
                        
                    }
                    else
                    {
                        opponentsArray[einX, einY] = 1;
                        if (directionEin == 0)
                        {
                            einY++;
                        }
                        else
                        {
                            einX++;
                        }
                    }
                }*/
            if (opponentsArray[zweiX, zweiY] != 0)
            {

            }
            else
            {
                for (int i = 0; i < battle; i++)
                {
                    opponentsArray[zweiX, zweiY] = 1;
                    if (directionZwei == 0)
                    {
                        zweiY++;
                    }
                    else
                    {
                        zweiX++;
                    }
                }
            }
            if (opponentsArray[dreiX, dreiY] != 0)
            {

            }
            else
            {
                for (int i = 0; i < cruiser; i++)
                {
                    opponentsArray[einX, einY] = 1;
                    if (directionEin == 0)
                    {
                        einY++;
                    }
                    else
                    {
                        einX++;
                    }
                }
            }
            if (opponentsArray[einX, einY] != 0)
            {

            }
            else
            {
                for (int i = 0; i < airplane; i++)
                {
                    opponentsArray[einX, einY] = 1;
                    if (directionEin == 0)
                    {
                        einY++;
                    }
                    else
                    {
                        einX++;
                    }
                }
            }
            if (opponentsArray[einX, einY] != 0)
            {

            }
            else
            {
                for (int i = 0; i < airplane; i++)
                {
                    opponentsArray[einX, einY] = 1;
                    if (directionEin == 0)
                    {
                        einY++;
                    }
                    else
                    {
                        einX++;
                    }
                }
            }

            Console.WriteLine("\nMáte k dispozici 5 lodí - Letadlovou (1x5; 1), Bitevní(1x4; 2), " +
                "Křižník(1x3; 3), Ponorku(1x3; 4) a Torpédoborec(1x2; 5) v tomto pořadí. Souřadnice pište sloupec-řádek. Napište souřadnice předku první lodi.");

            string firstX = Console.ReadLine();            
            int oneX = CheckIfNumber(firstX);            
                        
            string firstY = Console.ReadLine();            
            int oneY = CheckIfNumber(firstY);
            
            Console.WriteLine("Chcete loď vodorovně?");
            string directionOne = Console.ReadLine();

            for (int i = 0; i < airplane; i++)
            {
                myArray[oneX, oneY] = 1;
                if (directionOne == "ano")
                {
                    oneY++;
                }
                else
                {
                    oneX++;
                }                
            }
            PrintArray(myArray);

            Console.WriteLine("Zadejte souřadnice druhé lodě");

            string secondX = Console.ReadLine();
            int twoX = CheckIfNumber(secondX);

            string secondY = Console.ReadLine();
            int twoY = CheckIfNumber(secondY);

            Console.WriteLine("Chcete loď vodorovně?");
            string directionTwo = Console.ReadLine();

            //if (twoX <= myArray.GetLength(0) && twoY <= myArray.GetLength(0))
            //{
                if (myArray[twoX, twoY] != 0)
                {
                    Console.WriteLine("Zde už je jiná loď");
                }
                else
                {
                    for (int i = 0; i < battle; i++)
                    {
                        myArray[twoX, twoY] = 2;
                        if (directionTwo == "ano")
                        {
                            twoY++;
                        }
                        else
                        {
                            twoX++;
                        }
                    }
                }
            /*}
            else
            {
                Console.WriteLine("Vložte loď do pole");
            }*/
            PrintArray(myArray);

            Console.WriteLine("Zadejte souřadnice třetí lodě");

            string thirdX = Console.ReadLine();
            int threeX = CheckIfNumber(thirdX);

            string thirdY = Console.ReadLine();
            int threeY = CheckIfNumber(thirdY);

            Console.WriteLine("Chcete loď vodorovně?");
            string directionThree = Console.ReadLine();

            if (myArray[threeX, threeY] != 0)
            {
                Console.WriteLine("Zde už je jiná loď");
            }
            else
            {
                for (int i = 0; i < cruiser; i++)
                {
                    myArray[threeX, threeY] = 3;
                    if (directionThree == "ano")
                    {
                        threeY++;
                    }
                    else
                    {
                        threeX++;
                    }
                }
            }
            PrintArray(myArray);

            Console.WriteLine("Zadejte souřadnice čtvrté lodě");

            string fourthX = Console.ReadLine();
            int fourX = CheckIfNumber(fourthX);

            string fourthY = Console.ReadLine();
            int fourY = CheckIfNumber(fourthY);

            Console.WriteLine("Chcete loď vodorovně?");
            string directionFour = Console.ReadLine();

            if (myArray[fourX, fourY] != 0)
            {
                Console.WriteLine("Zde už je jiná loď");
            }
            else
            {
                for (int i = 0; i < submarine; i++)
                {
                    myArray[fourX, fourY] = 4;
                    if (directionFour == "ano")
                    {
                        fourY++;
                    }
                    else
                    {
                        fourX++;
                    }
                }
            }
            PrintArray(myArray);

            Console.WriteLine("Zadejte souřadnice páté lodě");

            string fifthX = Console.ReadLine();
            int fiveX = CheckIfNumber(fifthX);

            string fifthY = Console.ReadLine();
            int fiveY = CheckIfNumber(fifthY);

            Console.WriteLine("Chcete loď vodorovně?");
            string directionFive = Console.ReadLine();

            if (myArray[fiveX, fiveY] != 0)
            {
                Console.WriteLine("Zde už je jiná loď");
            }
            else
            {
                for (int i = 0; i < destroyer; i++)
                {
                    myArray[fiveX, fiveY] = 5;
                    if (directionFive == "ano")
                    {
                        fiveY++;
                    }
                    else
                    {
                        fiveX++;
                    }
                }
            }
            PrintArray(myArray);

            Console.ReadKey();
        }
    }
}
