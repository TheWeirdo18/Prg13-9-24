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
        static void PrintArray(int[,] arrayToPrint) //funkce pro tisknutí pole
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
        static int CheckIfNumber(string number) //funkce pro přepsání string na int
        {
            int numberValue = Convert.ToInt32(number);
            return numberValue;
        }
        static void Main(string[] args)
        {
            //souřadnice hráče (h) pojmenované anglicky, souřadnice počítače (p) německy (pro rozlišení)
            //pokud je pole větší jak 15x15, tak je možnost vepsat ještě 6. loď

            int a = 11;
            int b = 11;

            Console.WriteLine("Zadejte rozměr pole"); //vlastní rozměry pole (čtverec/obdélník)
            string arrayA = Console.ReadLine();
            a = (CheckIfNumber(arrayA)) + 1;
            string arrayB = Console.ReadLine();
            b = (CheckIfNumber(arrayB)) + 1;

            int[,] myArray = new int[a, b]; //vytvoření pole h
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

            int[,] opponentsArray = new int[a, b]; //vytvoření pole p (s rozpoložením lodí)
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

            int[,] opponentsShowedArray = new int[a, b]; //vytvoření pole p (s rozpoložením střel h)
            int otherOtherNumber = -1;
            for (int i = 0; i < opponentsShowedArray.GetLength(0); i++)
            {
                opponentsShowedArray[i, 0] = otherOtherNumber + 1;
                otherOtherNumber++;
            }
            otherOtherNumber = -1;
            for (int j = 0; j < opponentsShowedArray.GetLength(1); j++)
            {
                opponentsShowedArray[0, j] = otherOtherNumber + 1;
                otherOtherNumber++;
            }

            Random rnd = new Random();
            int airplane = 5; int battle = 4; int cruiser = 3; int submarine = 3; int destroyer = 2; int dreadnought = 6; //délky lodí

            int airplaneDirection = rnd.Next(0, 2); int battleDirection = rnd.Next(0, 2); int cruiserDirection = rnd.Next(0, 2); int submarineDirection = rnd.Next(0, 2); int destroyerDirection = rnd.Next(0, 2); int dreadnoughtDirection = rnd.Next(0, 2); //směry lodí p
            int einX, einY; //vytvoření souřadnic p
            
            //umístění airplane
            if (airplaneDirection == 0)
            {
                einX = rnd.Next(1, a - airplane);
                einY = rnd.Next(1, b);
            }
            else
            {
                einX = rnd.Next(1, a);
                einY = rnd.Next(1, b - airplane);
            }
            for (int i = 0; i < airplane; i++)
            {
                opponentsArray[einX+(airplaneDirection == 0 ? i : 0), einY+(airplaneDirection == 1 ? i : 0)] = 1;                                                              
            }

            //umístění battle
            bool occupied = false;
            do
            {
                occupied = false;
                if (battleDirection == 0)
                {
                    einX = rnd.Next(1, a - battle);
                    einY = rnd.Next(1, b);
                }
                else
                {
                    einX = rnd.Next(1, a);
                    einY = rnd.Next(1, b - battle);
                }
                for (int i = 0; i < battle; i++)
                {
                    if(opponentsArray[einX + (battleDirection == 0 ? i : 0), einY + (battleDirection == 1 ? i : 0)] != 0)
                    {
                        occupied = true;
                    }
                }
            } while (occupied);
            for (int i = 0; i < battle; i++)
            {
                opponentsArray[einX + (battleDirection == 0 ? i : 0), einY + (battleDirection == 1 ? i : 0)] = 2;
            }

            //umístění cruiser
            occupied = false;
            do
            {
                occupied = false;
                if (cruiserDirection == 0)
                {
                    einX = rnd.Next(1, a - cruiser);
                    einY = rnd.Next(1, b);
                }
                else
                {
                    einX = rnd.Next(1, a);
                    einY = rnd.Next(1, b - cruiser);
                }
                for (int i = 0; i < cruiser; i++)
                {
                    if (opponentsArray[einX + (cruiserDirection == 0 ? i : 0), einY + (cruiserDirection == 1 ? i : 0)] != 0)
                    {
                        occupied = true;
                    }
                }
            } while (occupied);
            for (int i = 0; i < cruiser; i++)
            {
                opponentsArray[einX + (cruiserDirection == 0 ? i : 0), einY + (cruiserDirection == 1 ? i : 0)] = 3;
            }

            //umístění submarine
            occupied = false;
            do
            {
                occupied = false;
                if (submarineDirection == 0)
                {
                    einX = rnd.Next(1, a - submarine);
                    einY = rnd.Next(1, b);
                }
                else
                {
                    einX = rnd.Next(1, a);
                    einY = rnd.Next(1, b - submarine);
                }
                for (int i = 0; i < submarine; i++)
                {
                    if (opponentsArray[einX + (submarineDirection == 0 ? i : 0), einY + (submarineDirection == 1 ? i : 0)] != 0)
                    {
                        occupied = true;
                    }
                }
            } while (occupied);
            for (int i = 0; i < submarine; i++)
            {
                opponentsArray[einX + (submarineDirection == 0 ? i : 0), einY + (submarineDirection == 1 ? i : 0)] = 4;
            }

            //umístění destroyer
            occupied = false;
            do
            {
                occupied = false;
                if (destroyerDirection == 0)
                {
                    einX = rnd.Next(1, a - destroyer);
                    einY = rnd.Next(1, b);
                }
                else
                {
                    einX = rnd.Next(1, a);
                    einY = rnd.Next(1, b - destroyer);
                }
                for (int i = 0; i < destroyer; i++)
                {
                    if (opponentsArray[einX + (destroyerDirection == 0 ? i : 0), einY + (destroyerDirection == 1 ? i : 0)] != 0)
                    {
                        occupied = true;
                    }
                }
            } while (occupied);
            for (int i = 0; i < destroyer; i++)
            {
                opponentsArray[einX + (destroyerDirection == 0 ? i : 0), einY + (destroyerDirection == 1 ? i : 0)] = 5;
            }

            if((a + b) > 30)
            {
                //umístění dreadnought
                occupied = false;
                do
                {
                    occupied = false;
                    if (dreadnoughtDirection == 0)
                    {
                        einX = rnd.Next(1, a - dreadnought);
                        einY = rnd.Next(1, b);
                    }
                    else
                    {
                        einX = rnd.Next(1, a);
                        einY = rnd.Next(1, b - dreadnought);
                    }
                    for (int i = 0; i < dreadnought; i++)
                    {
                        if (opponentsArray[einX + (dreadnoughtDirection == 0 ? i : 0), einY + (dreadnoughtDirection == 1 ? i : 0)] != 0)
                        {
                            occupied = true;
                        }
                    }
                } while (occupied);
                for (int i = 0; i < dreadnought; i++)
                {
                    opponentsArray[einX + (dreadnoughtDirection == 0 ? i : 0), einY + (dreadnoughtDirection == 1 ? i : 0)] = 3;
                }
            }

            if ((a + b) > 30)
            {
                Console.WriteLine("Máte k dispozici 6 lodí - Letadlovou (1x5; 1), Bitevní(1x4; 2), " +
                "Křižník(1x3; 3), Ponorku(1x3; 4), Torpédoborec(1x2; 5) a Dreadnought(1x6; 6) v tomto pořadí. Souřadnice pište sloupec-řádek. Napište souřadnice předku první lodi.");
            }
            else
            {
                Console.WriteLine("Máte k dispozici 5 lodí - Letadlovou (1x5; 1), Bitevní(1x4; 2), " +
                "Křižník(1x3; 3), Ponorku(1x3; 4) a Torpédoborec(1x2; 5) v tomto pořadí. Souřadnice pište sloupec-řádek. Napište souřadnice předku první lodi.");
            }

            string firstX = Console.ReadLine();
            int oneX = CheckIfNumber(firstX);                        
            string firstY = Console.ReadLine();            
            int oneY = CheckIfNumber(firstY);            
            Console.WriteLine("Chcete loď vodorovně?");
            string directionOne = Console.ReadLine();

            if (oneX + oneY > (a + b) - airplane) //umístění vlastní airplane
            {
                Console.WriteLine("Jste mimo pole");
            }
            else
            {
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
            }
            PrintArray(myArray);

            Console.WriteLine("Zadejte souřadnice druhé lodě");
            string secondX = Console.ReadLine();
            int twoX = CheckIfNumber(secondX);
            string secondY = Console.ReadLine();
            int twoY = CheckIfNumber(secondY);
            Console.WriteLine("Chcete loď vodorovně?");
            string directionTwo = Console.ReadLine();

            if (myArray[twoX, twoY] != 0) //umístění vlastní battle
            {
                Console.WriteLine("Zde už je jiná loď");
            }
            else if (twoX + twoY > (a + b) - battle) 
            {
                Console.WriteLine("Jste mimo pole");
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
            PrintArray(myArray);

            Console.WriteLine("Zadejte souřadnice třetí lodě");
            string thirdX = Console.ReadLine();
            int threeX = CheckIfNumber(thirdX);
            string thirdY = Console.ReadLine();
            int threeY = CheckIfNumber(thirdY);
            Console.WriteLine("Chcete loď vodorovně?");
            string directionThree = Console.ReadLine();

            if (myArray[threeX, threeY] != 0) //umístění vlastní cruiser
            {
                Console.WriteLine("Zde už je jiná loď");
            }
            else if (threeX + threeY > (a + b) - cruiser)
            {
                Console.WriteLine("Jste mimo pole");
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

            if (myArray[fourX, fourY] != 0) //umístění vlastní sumbarine
            {
                Console.WriteLine("Zde už je jiná loď");
            }
            else if (fourX + fourY > (a + b) - submarine)
            {
                Console.WriteLine("Jste mimo pole");
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

            if (myArray[fiveX, fiveY] != 0) //umístění vlastní destroyer
            {
                Console.WriteLine("Zde už je jiná loď");
            }
            else if (fiveX + fiveY > (a + b) - destroyer)
            {
                Console.WriteLine("Jste mimo pole");
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

            if((a+b)> 30)
            {
                Console.WriteLine("Zadejte souřadnice šesté lodě");
                string sixthX = Console.ReadLine();
                int sixX = CheckIfNumber(sixthX);
                string sixthY = Console.ReadLine();
                int sixY = CheckIfNumber(sixthY);
                Console.WriteLine("Chcete loď vodorovně?");
                string directionSix = Console.ReadLine();

                if (myArray[sixX, sixY] != 0) //umístění vlastní dreadnought
                {
                    Console.WriteLine("Zde už je jiná loď");
                }
                else if (sixX + sixY > (a + b) - dreadnought)
                {
                    Console.WriteLine("Jste mimo pole");
                }
                else
                {
                    for (int i = 0; i < dreadnought; i++)
                    {
                        myArray[sixX, sixY] = 2;
                        if (directionSix == "ano")
                        {
                            sixY++;
                        }
                        else
                        {
                            sixX++;
                        }
                    }
                }
                PrintArray(myArray);
            }

            int shipsPlayer, shipsOpponent;
            if ((a + b) > 30)
            {
                shipsPlayer = 17 + dreadnought;
                shipsOpponent = 17 + dreadnought;
            }
            else 
            {
                shipsPlayer = 17;
                shipsOpponent = 17;
            }

            Console.WriteLine("\nZačíná hra.");

            while (true)
            {                
                Console.WriteLine("\nNapište souřadnice políčka, které chcete odstřelit.");
                string attackedXString = Console.ReadLine();
                int attackedX = CheckIfNumber(attackedXString);
                string attackedYString = Console.ReadLine();
                int attackedY = CheckIfNumber(attackedYString);

                if (opponentsArray[attackedX, attackedY] == 0)
                {
                    Console.WriteLine("\nŽádná loď nesesřelena");
                    opponentsArray[attackedX, attackedY] = 8;
                    opponentsShowedArray[attackedX, attackedY] = 8;
                }
                else
                {
                    shipsOpponent--;
                    if(shipsOpponent == 0)
                    {
                        Console.WriteLine("\nHráč sestřelil všechny lodě a vyhrál");
                        break;
                    }
                    Console.WriteLine("\nSestřelena loď");
                    opponentsArray[attackedX, attackedY] = 9;
                    opponentsShowedArray[attackedX, attackedY] = 9;                    
                }

                int itAttackedX, itAttackedY;
                
                bool beenThere = false;
                do
                {
                    beenThere = false;
                    itAttackedX = rnd.Next(1, a);
                    itAttackedY = rnd.Next(1, b);                    
                    if (myArray[itAttackedX, itAttackedY] == 8 || myArray[itAttackedX, itAttackedY] == 9)
                    {
                        beenThere = true;
                    }                    
                } while (beenThere);
              
                if (myArray[itAttackedX, itAttackedY] == 0)
                {
                    myArray[itAttackedX, itAttackedY] = 8;
                }
                else
                {
                    myArray[itAttackedX, itAttackedY] = 9;
                    shipsPlayer--;
                    if(shipsPlayer == 0)
                    {
                        Console.WriteLine("\nPočítač sestřelil všechny lodě vyhrál");
                        break;
                    }
                }

                PrintArray(opponentsShowedArray);

                Console.WriteLine("\n");
                Console.WriteLine("Počítač sestřelil pole " + itAttackedX + ", " + itAttackedY);
                PrintArray(myArray);
            }
            Console.ReadKey();
        }
    }
}
