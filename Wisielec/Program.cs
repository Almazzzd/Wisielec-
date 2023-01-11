// See https://aka.ms/new-console-template for more information

using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System;
using System.Diagnostics;
using System.Threading;



String[] lines = System.IO.File.ReadAllLines(@"C:\Users\macie\OneDrive\Desktop\AMC\testy\testy\dane_wisielec.csv");

Random r = new Random();
int rInt = r.Next(0, 1000);

string haslo =lines[rInt];

Stopwatch zegar = new Stopwatch();

bool[] znalezione = new bool[haslo.Length];


    for (int i = 0; i < haslo.Length; i++)
    {
        Console.WriteLine(znalezione[i]);
    }
    void rysuj(int blad)
    {

        switch (blad)
        {
            case 1:
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("/|\\ ");
                break;
            case 2:
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(" | ");
                Console.WriteLine("/|\\ ");
                break;
            case 3:
                Console.WriteLine();
                Console.WriteLine(" | ");
                Console.WriteLine(" | ");
                Console.WriteLine(" | ");
                Console.WriteLine("/|\\ ");
                break;
            case 4:
                Console.WriteLine(" -----");
                Console.WriteLine(" | ");
                Console.WriteLine(" | ");
                Console.WriteLine(" | ");
                Console.WriteLine("/|\\ ");
                break;
            case 5:
                Console.WriteLine(" -----");
                Console.WriteLine(" |   O");
                Console.WriteLine(" | ");
                Console.WriteLine(" | ");
                Console.WriteLine("/|\\ ");
                break;
            case 6:
                Console.WriteLine(" -----");
                Console.WriteLine(" |   O");
                Console.WriteLine(" |  /|\\");
                Console.WriteLine(" | ");
                Console.WriteLine("/|\\");
                break;
            case 7:
                Console.WriteLine(" -----");
                Console.WriteLine(" |   O");
                Console.WriteLine(" |  /|\\ ");
                Console.WriteLine(" |  / \\ ");
                Console.WriteLine("/|\\ ");
                break;
        }

    }

    int dobrze = 0;
    int zle = 0;
    int np =0;

zegar.Start();

while (dobrze != haslo.Length && zle < 7)
{
    Console.Clear();
    string slowo = "";

    for (int i = 0; i < haslo.Length; i++)
    {
        if (znalezione[i] == false)
        {
            slowo += " _ ";


        }
        else
        {
            slowo += haslo[i];
        }
    }
    Console.WriteLine(slowo);

    rysuj(zle);

    Console.WriteLine("Podaj Literkę (proszę o małą :) )");

    string litera = Console.ReadLine();
    np++;
    while (!(litera.Length == 1 && ((litera[0] <= 'z' && litera[0] >= 'a') || (litera[0] <= 'Z' && litera[0] >= 'A'))))
    {
        Console.WriteLine("proszę podać poprawną literkę ;) ");
        litera = Console.ReadLine();
        np++;
    }
    bool trafione = false;

    for (int i = 0; i < haslo.Length; i++)
    {
        if (((haslo[i] == litera[0] || haslo[i] - 32 == litera[0]) || haslo[i] + 32 == litera[0]) && znalezione[i] == false)
            {
                znalezione[i] = true;
                dobrze++;
                trafione = true;
            }

        }
        if (!trafione)
        {
            zle++;
        }
    else { np--; }
    }
string kom = "";

zegar.Stop();

if (dobrze == haslo.Length)
    {
        Console.Clear();
        Console.WriteLine("Gratulacje wygranej");
        Console.WriteLine("Zajeło Ci to  " + zegar.Elapsed.Seconds + " sekund");
        Console.WriteLine("Hasło to: " + haslo);
        Console.WriteLine("Poełniłeś " + np + " błędów");
    kom = "Wygrałeś :D";
    }
    else
    {
        Console.Clear();
        rysuj(7);
        Console.WriteLine("Niestety Przegrałeś");
        Console.WriteLine("Zajeło Ci to  " + zegar.Elapsed.Seconds + " sekund");
        Console.WriteLine("Hasło to: " + haslo);
    kom = "Niesety, tym razem się nie udało ";
    }

string[] historia =
       {
          "Dziękuję za grę ", kom, "Twoje hasło to "+haslo , "poełniłeś "+ np + " Błędów","Czas gry "+zegar.Elapsed.Seconds +" sekund","Zapraszam do kolejnej gry :D ", "++++++++++++++++++++++++++++++++++++"
        };



await File.AppendAllLinesAsync("Historia.txt", historia);


