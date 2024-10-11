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
                string operace = Console.ReadLine();

                double vysledek = 0;
                
                bool spatnaOperace = true;
                

                if (operace == "mocnina")
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

                    double mocninaCislo;
                    double malo = a;
                    
                    while (true)
                    {
                        Console.WriteLine("Zadej číslo mocniny");
                        string mocninaCisloString = Console.ReadLine();


                        if (double.TryParse(mocninaCisloString, out _))
                        {
                            mocninaCislo = Convert.ToDouble(mocninaCisloString);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Nebylo zadané číslo");
                        }

                    }                    

                    if (mocninaCislo == 0)
                    {
                        vysledek = 1;

                        Console.WriteLine("Výsledek operace je " + vysledek);
                    }
                    else if (mocninaCislo > 1)
                    {
                        while (mocninaCislo > 1)
                        {
                            vysledek = malo * a;
                            mocninaCislo--;
                            malo = vysledek;
                        }

                        Console.WriteLine("Výsledek operace je " + vysledek);
                    }
                    else if (mocninaCislo == 1)
                    {
                        vysledek = a;

                        Console.WriteLine("Výsledek operace je " + vysledek);
                    }
                    else
                    {
                        double meziVypocet = 0;

                        while (mocninaCislo < -1)
                        {
                            meziVypocet = malo * a;
                            mocninaCislo++;
                            malo = meziVypocet;
                        }

                        vysledek = 1 / meziVypocet;

                        Console.WriteLine("Výsledek operace je 1/" + meziVypocet + ", což je zaokrouhleno na "+ vysledek);
                    }

                    spatnaOperace = false;
                }

                else if (operace == "druha odmocnina")
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
                        vysledek = (float)Math.Sqrt(a);
                        Console.WriteLine("Výsledek operace je " + vysledek);
                    }
                    else
                    {
                        Console.WriteLine("Nelze odmocnit zápornou hodnotu.");
                    }

                    spatnaOperace = false;                                        
                }

                else if (operace == "soucet" || operace == "rozdil" || operace == "soucin" || operace == "podil")
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

                    if (operace == "soucet")
                    {
                        vysledek = a + b;
                        Console.WriteLine("Výsledek operace je " + vysledek);
                    }
                    else if (operace == "rozdil")
                    {
                        vysledek = a - b;
                        Console.WriteLine("Výsledek operace je " + vysledek);
                    }
                    else if (operace == "soucin")
                    {
                        vysledek = a * b;
                        Console.WriteLine("Výsledek operace je " + vysledek);
                    }
                    else if (operace == "podil")
                    {
                        if (b == 0)
                        {
                            Console.WriteLine("Nelze dělit nulou");
                        }
                        else
                        {
                            vysledek = a / b;
                            Console.WriteLine("Výsledek operace je " + vysledek);
                        }
                    }

                }
                else if (operace == "zavorka")
                {
                    double zavorka = 0;

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
                    string operaceZavorka = Console.ReadLine();

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
                    
                    if (operaceZavorka == "soucet")
                    {
                        zavorka = a + b;                        
                    }
                    else if (operaceZavorka == "rozdil")
                    {
                        zavorka = a - b;
                    }
                    else if (operaceZavorka == "soucin")
                    {
                        zavorka = a * b;                        
                    }
                    else if (operaceZavorka == "podil")
                    {
                        if (b == 0)
                        {
                            Console.WriteLine("Nelze dělit nulou");
                        }
                        else
                        {
                            zavorka = a / b;                            
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nebyla zadaná operace");
                    }

                    Console.WriteLine("Zadej operaci, kterou chces mit mimo zavorce (soucet/rozdil/soucin/podil):");
                    string operaceMimoZavorku = Console.ReadLine();

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
                    
                    if (operaceMimoZavorku == "soucet")
                    {
                        vysledek = zavorka + c;
                    }
                    else if (operaceMimoZavorku == "rozdil")
                    {
                        vysledek = zavorka - c;
                    }
                    else if (operaceMimoZavorku == "soucin")
                    {
                        vysledek = zavorka * c;
                    }
                    else if (operaceMimoZavorku == "podil")
                    {
                        if (c == 0)
                        {
                            Console.WriteLine("Nelze dělit nulou");
                        }
                        else
                        {
                            vysledek = zavorka / c;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nebyla zadaná operace");
                    }
                    
                    Console.WriteLine("Výsledek operace je " + vysledek);

                    spatnaOperace = false;
                }
                else
                {
                    Console.WriteLine("Špatně zadaná operace.");
                    spatnaOperace = false;
                }

                while (spatnaOperace == true)
                {
                    Console.WriteLine("Chceš přidat ještě jednu operaci (ano/ne)?");
                    string druhaOperace = Console.ReadLine();

                    if (druhaOperace == "ano")
                    {
                        float novyVysledek = 0;
                                                
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
                        string operaceDva = Console.ReadLine();

                        if (operaceDva == "soucet")
                        {
                            novyVysledek = (float)(vysledek + x);
                            Console.WriteLine("Výsledek operace je " + novyVysledek);
                        }
                        else if (operaceDva == "rozdil")
                        {
                            novyVysledek = (float)(vysledek - x);
                            Console.WriteLine("Výsledek operace je " + novyVysledek);
                        }
                        else if (operaceDva == "soucin")
                        {
                            novyVysledek = (float)(vysledek * x);
                            Console.WriteLine("Výsledek operace je " + novyVysledek);
                        }
                        else if (operaceDva == "podil")
                        {
                            if (x == 0)
                            {
                                Console.WriteLine("Nelze dělit nulou");
                            }
                            else
                            {
                                novyVysledek = (float)(vysledek / x);
                                Console.WriteLine("Výsledek operace je " + novyVysledek);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nebyla zadaná operace");
                        }

                        vysledek = novyVysledek;

                    }
                    else if (druhaOperace == "ne")
                    {
                        Console.WriteLine(" ");
                        spatnaOperace = false;
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
