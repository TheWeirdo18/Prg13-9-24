using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2024-2025.
 * Extended by students.
 */

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * ZADANI
             * Vytvor program ktery bude fungovat jako kalkulacka. Kroky programu budou nasledujici:
             * 1) Nacte vstup pro prvni cislo od uzivatele (vyuzijte metodu Console.ReadLine() - https://learn.microsoft.com/en-us/dotnet/api/system.console.readline?view=netframework-4.8.
             * 2) Zkonvertuje vstup od uzivatele ze stringu do integeru - https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number.
             * 3) Nacte vstup pro druhe cislo od uzivatele a zkonvertuje ho do integeru. (zopakovani kroku 1 a 2 pro druhe cislo)
             * 4) Nacte vstup pro ciselnou operaci. Rozmysli si, jak operace nazves. Muze to byt "soucet", "rozdil" atd. nebo napr "+", "-", nebo jakkoliv jinak.
             * 5) Nadefinuj integerovou promennou result a prirad ji prozatimne hodnotu 0.
             * 6) Vytvor podminky (if statement), podle kterych urcis, co se bude s cisly dit podle zadane operace
             *    a proved danou operaci - https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements.
             * 7) Vypis promennou result do konzole
             * 
             * Rozsireni programu pro rychliky / na doma (na poradi nezalezi):
             * 1) Vypis do konzole pred nactenim kazdeho uzivatelova vstupu co po nem chces (aby vedel, co ma zadat)
             * 2) a) Kontroluj, ze uzivatel do vstupu zadal, co mel (cisla, popr. ciselnou operaci). Pokud zadal neco jineho, napis mu, co ma priste zadat a program ukoncete.
             * 2) b) To same, co a) ale misto ukonceni programu opakovane cti vstup, dokud uzivatel nezada to, co ma
             *       - https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements#the-while-statement
             * 3) Umozni uzivateli zadavat i desetinna cisla, tedy prekopej kalkulacku tak, aby umela pracovat s floaty
             */

            Console.WriteLine("Vzhled zavorky vyjde na [(a /operace/ b) /operace/ c]." + "\n ");

            //pomoc od chatgpt pouze při vraceni uzivatele po nezadani cisla

            while (true) 
            {
                Console.WriteLine("Vyber operaci (soucet/rozdil/soucin/podil/mocnina/druha odmocnina/zavorka):");
                string operation = Console.ReadLine();

                double result = 0;
                
                bool wrongOperation = true;
                

                if (operation == "mocnina")
                {
                    /*Console.WriteLine("Zadej číslo, které chcete mocnit");
                    string aString = Console.ReadLine();
                    double a = Convert.ToDouble(aString);*/ //puvodni reseni bez vraceni uzivatele
                    
                    double a;

                    while (true)
                    {
                        Console.WriteLine("Zadej číslo, které chcete mocnit");
                        string aString = Console.ReadLine();
                        

                        if (double.TryParse(aString, out _))
                        {
                            a = Convert.ToDouble(aString);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Nebylo zadané číslo");                            
                        }

                    }

                    double multiNumber;
                    double tooLittle = a;
                    
                    while (true)
                    {
                        Console.WriteLine("Zadej číslo mocniny");
                        string multiNumberString = Console.ReadLine();


                        if (double.TryParse(multiNumberString, out _))
                        {
                            multiNumber = Convert.ToDouble(multiNumberString);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Nebylo zadané číslo");
                        }

                    }                    

                    if (multiNumber == 0)
                    {
                        result = 1;

                        Console.WriteLine("Výsledek operace je " + result);
                    }
                    else if (multiNumber > 1)
                    {
                        while (multiNumber > 1)
                        {
                            result = tooLittle * a;
                            multiNumber--;
                            tooLittle = result;
                        }

                        Console.WriteLine("Výsledek operace je " + result);
                    }
                    else if (multiNumber == 1)
                    {
                        result = a;

                        Console.WriteLine("Výsledek operace je " + result);
                    }
                    else
                    {
                        double addedCalculation = 0;

                        while (multiNumber < -1)
                        {
                            addedCalculation = tooLittle * a;
                            multiNumber++;
                            tooLittle = addedCalculation;
                        }

                        result = 1 / addedCalculation;

                        Console.WriteLine("Výsledek operace je 1/" + addedCalculation + ", což je zaokrouhleno na "+ result);
                    }

                    wrongOperation = false;
                }

                else if (operation == "druha odmocnina")
                {
                    double a;

                    while (true)
                    {
                        Console.WriteLine("Zadej číslo, které chceš odmocnit");
                        string aString = Console.ReadLine();

                        if (double.TryParse(aString, out _))
                        {
                            a = Convert.ToDouble(aString);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Nebylo zadané číslo");
                        }
                    }

                    if (a >= 0)
                    {
                        result = (float)Math.Sqrt(a);
                        Console.WriteLine("Výsledek operace je " + result);
                    }
                    else
                    {
                        Console.WriteLine("Nelze odmocnit zápornou hodnotu.");
                    }

                    wrongOperation = false;                                        
                }

                else if (operation == "soucet" || operation == "rozdil" || operation == "soucin" || operation == "podil")
                {
                    double a;
                    while (true)
                    {
                        Console.WriteLine("Zadej první číslo");
                        string aString = Console.ReadLine();

                        if (double.TryParse(aString, out _))
                        {
                            a = Convert.ToDouble(aString);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Nebylo zadané číslo");
                        }
                    }

                    double b;
                    while (true)
                    {
                        Console.WriteLine("Zadej druhé číslo");
                        string bString = Console.ReadLine();
                        if (double.TryParse(bString, out _))
                        {
                            b = Convert.ToDouble(bString);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Nebylo zadané číslo");
                        }
                    }

                    if (operation == "soucet")
                    {
                        result = a + b;
                        Console.WriteLine("Výsledek operace je " + result);
                    }
                    else if (operation == "rozdil")
                    {
                        result = a - b;
                        Console.WriteLine("Výsledek operace je " + result);
                    }
                    else if (operation == "soucin")
                    {
                        result = a * b;
                        Console.WriteLine("Výsledek operace je " + result);
                    }
                    else if (operation == "podil")
                    {
                        if (b == 0)
                        {
                            Console.WriteLine("Nelze dělit nulou");
                        }
                        else
                        {
                            result  = a / b;
                            Console.WriteLine("Výsledek operace je " + result);
                        }
                    }

                }
                else if (operation == "zavorka")
                {
                    double bracket = 0;

                    double a;
                    while (true)
                    {
                        Console.WriteLine("zadej prvni cislo v zavorce");
                        string aString = Console.ReadLine();
                        if (double.TryParse(aString, out _))
                        {
                            a = Convert.ToDouble(aString);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Nebylo zadané číslo");
                        }
                    }
                    
                    Console.WriteLine("Zadej operaci, kterou chces mit v zavorce (soucet/rozdil/soucin/podil):");
                    string operationBracket = Console.ReadLine();

                    double b;
                    while (true)
                    {
                        Console.WriteLine("zadej druhe cislo v zavorce");
                        string bString = Console.ReadLine();
                        if (double.TryParse(bString, out _))
                        {
                            b = Convert.ToDouble(bString);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Nebylo zadané číslo");
                        }
                    }
                    
                    if (operationBracket == "soucet")
                    {
                        bracket = a + b;                        
                    }
                    else if (operationBracket == "rozdil")
                    {
                        bracket = a - b;
                    }
                    else if (operationBracket == "soucin")
                    {
                        bracket = a * b;                        
                    }
                    else if (operationBracket == "podil")
                    {
                        if (b == 0)
                        {
                            Console.WriteLine("Nelze dělit nulou");
                        }
                        else
                        {
                            bracket = a / b;                            
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nebyla zadaná operace");
                    }

                    Console.WriteLine("Zadej operaci, kterou chces mit mimo zavorce (soucet/rozdil/soucin/podil):");
                    string operationOutOfBracket = Console.ReadLine();

                    double c;
                    while (true)
                    {
                        Console.WriteLine("Zadej číslo, které je mimo závorku");
                        string cString = Console.ReadLine();
                        if (double.TryParse(cString, out _))
                        {
                            c = Convert.ToDouble(cString);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Nebylo zadané číslo");
                        }
                    }
                    
                    if (operationOutOfBracket == "soucet")
                    {
                        result = bracket + c;
                    }
                    else if (operationOutOfBracket == "rozdil")
                    {
                        result = bracket - c;
                    }
                    else if (operationOutOfBracket == "soucin")
                    {
                        result = bracket * c;
                    }
                    else if (operationOutOfBracket == "podil")
                    {
                        if (c == 0)
                        {
                            Console.WriteLine("Nelze dělit nulou");
                        }
                        else
                        {
                            result = bracket / c;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nebyla zadaná operace");
                    }
                    
                    Console.WriteLine("Výsledek operace je " + result);

                    wrongOperation = false;
                }
                else
                {
                    Console.WriteLine("Špatně zadaná operace.");
                    wrongOperation = false;
                }

                while (wrongOperation == true)
                {
                    Console.WriteLine("Chceš přidat ještě jednu operaci (ano/ne)?");
                    string anotherOperation = Console.ReadLine();

                    if (anotherOperation == "ano")
                    {
                        float newResult = 0;
                                                
                        double x;
                        while (true)
                        {
                            Console.WriteLine("Zadej další číslo");
                            string xString = Console.ReadLine();
                            if (double.TryParse(xString, out _))
                            {
                                x = Convert.ToDouble(xString);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Nebylo zadané číslo");
                            }
                        }
                        
                        Console.WriteLine("Vyber operaci (soucet/rozdil/soucin/podil):");
                        string nextOperation = Console.ReadLine();

                        if (nextOperation == "soucet")
                        {
                            newResult = (float)(result + x);
                            Console.WriteLine("Výsledek operace je " + newResult);
                        }
                        else if (nextOperation == "rozdil")
                        {
                            newResult = (float)(result - x);
                            Console.WriteLine("Výsledek operace je " + newResult);
                        }
                        else if (nextOperation == "soucin")
                        {
                            newResult = (float)(result * x);
                            Console.WriteLine("Výsledek operace je " + newResult);
                        }
                        else if (nextOperation == "podil")
                        {
                            if (x == 0)
                            {
                                Console.WriteLine("Nelze dělit nulou");
                            }
                            else
                            {
                                newResult = (float)(result / x);
                                Console.WriteLine("Výsledek operace je " + newResult);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nebyla zadaná operace");
                        }

                        result = newResult;

                    }
                    else if (anotherOperation == "ne")
                    {
                        Console.WriteLine(" ");
                        wrongOperation = false;
                    }
                    else
                    {
                        Console.WriteLine("Špatně zadaná odpověď");
                    }
                }

                Console.WriteLine(" "); //volný řádek mezi koly
            }

            Console.ReadKey();
        }
    }
}
