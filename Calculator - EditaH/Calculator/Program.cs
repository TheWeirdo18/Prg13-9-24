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

            Console.WriteLine("Zadávání desetinných čísel nelze, prosíme o zadání celého čísla" + "\n ");

            while (true) 
            {
                Console.WriteLine("Vyber operaci (soucet/rozdil/soucin/podil/mocnina/druha odmocnina/chci pouzit zavorku):");
                string operace = Console.ReadLine();

                float vysledek = 0;
                
                bool spatnaOperace = true;

                if (operace == "mocnina")
                {
                    Console.WriteLine("Zadej číslo, které chcete mocnit");
                    string aString = Console.ReadLine();
                    float a = Convert.ToInt32(aString);
                    
                    Console.WriteLine("Zadej číslo mocniny");
                    string mocninaCisloString = Console.ReadLine();
                    float mocninaCislo = Convert.ToInt32(mocninaCisloString);
                    float malo = a;
                    if (mocninaCislo == 0)
                    {
                        vysledek = 0;

                        Console.WriteLine("Výsledek operace je " + vysledek);
                    }
                    else if (mocninaCislo > 0)
                    {
                        while (mocninaCislo > 1)
                        {
                            vysledek = malo * a;
                            mocninaCislo--;
                            malo = vysledek;
                        }

                        Console.WriteLine("Výsledek operace je " + vysledek);
                    }
                    else
                    {
                        float meziVypocet = 0;

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
                    Console.WriteLine("Zadej číslo, které chceš odmocnit");
                    string aString = Console.ReadLine();
                    float a = Convert.ToInt32(aString);

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
                    Console.WriteLine("Zadej první číslo");
                    string aString = Console.ReadLine();
                    float a = Convert.ToInt32(aString);

                    Console.WriteLine("Zadej druhé číslo");
                    string bString = Console.ReadLine();
                    float b = Convert.ToInt32(bString);

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
                else if (operace == "chci pouzit zavorku")
                {
                    float zavorka = 0;
                    
                    Console.WriteLine("zadej prvni cislo v zavorce");
                    string aString = Console.ReadLine();
                    float a = Convert.ToInt32(aString); 
                    
                    Console.WriteLine("Zadej operaci, kterou chces mit v zavorce (soucet/rozdil/soucin/podil):");
                    String operaceZavorka = Console.ReadLine();
                    
                    Console.WriteLine("zadej druhe cislo v zavorce");
                    string bString = Console.ReadLine();
                    float b = Convert.ToInt32(bString);
                    
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
                    
                    Console.WriteLine("Zadej operaci, kterou chces mit mimo zavorce (soucet/rozdil/soucin/podil):");
                    String operaceMimoZavorku = Console.ReadLine();

                    Console.WriteLine("Zadej číslo, které je mimo závorku"); 
                    string cString = Console.ReadLine();
                    float c = Convert.ToInt32(cString);
                    
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
                    
                    Console.WriteLine("Výsledek operace je " + vysledek);
                }
                else
                {
                    Console.WriteLine("Špatně zadaná operace.");
                    spatnaOperace = false;
                }

                while (spatnaOperace == true)
                {
                    Console.WriteLine("Chceš přidat ještě jednu operaci (ano/ne)?");
                    String druhaOperace = Console.ReadLine();

                    if (druhaOperace == "ano")
                    {
                        float novyVysledek = 0;

                        Console.WriteLine("Vyber operaci (soucet/rozdil/soucin/podil):");
                        string operaceDva = Console.ReadLine();

                        Console.WriteLine("Zadej další číslo");
                        string xString = Console.ReadLine();
                        float x = Convert.ToInt32(xString);

                        if (operaceDva == "soucet")
                        {
                            novyVysledek = vysledek + x;
                            Console.WriteLine("Výsledek operace je " + novyVysledek);
                        }
                        else if (operaceDva == "rozdil")
                        {
                            novyVysledek = vysledek - x;
                            Console.WriteLine("Výsledek operace je " + novyVysledek);
                        }
                        else if (operaceDva == "soucin")
                        {
                            novyVysledek = vysledek * x;
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
                                novyVysledek = vysledek / x;
                                Console.WriteLine("Výsledek operace je " + novyVysledek);
                            }
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
