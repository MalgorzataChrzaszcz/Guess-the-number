using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace zgadywanka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int playerGuesses = 0;
            int play = Draw();
            int kontunuujemy;
            Console.WriteLine($"Witaj w grze \"zgadywanka\". Masz 5 prób żeby odgadnąć liczbę wylosowaną przez komputer z zakresu od 0 do 20.");
            Thread.Sleep(1000);

            do
            {
                Console.WriteLine("Zaczynamy!");
                Console.WriteLine("Podaj 1 liczbę:");

                for (int i = 0; i < 5; i++)
                {
                    playerGuesses = int.Parse(Console.ReadLine());
                    if (playerGuesses != play)
                    {
                        if (i < 4)
                        {
                            Console.WriteLine($"Nie zgadłeś,\nWskazówka numer {i + 1}:");
                        }

                        Hints hint = new Hints();
                        switch (i)
                        {
                            case 0:
                                hint.Hint1(play);
                                break;
                            case 1:
                                hint.Hint2(play);
                                break;
                            case 2:
                                hint.Hint3(play);
                                break;
                            case 3:
                                hint.Hint4(play);
                                break;
                            case 4:
                                Console.WriteLine("Przegrałeś :(");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wygrałeś, gratulacje! :)");
                        break;
                    }
                }
                Console.WriteLine("Chcesz zagrać jeszcze raz?\nWciśnij \"1\" jeżeli tak");
                kontunuujemy = int.Parse(Console.ReadLine());
                Console.Clear();
            }
            while (kontunuujemy == 1);
            
            
            Console.ReadKey();
        }
        static int Draw()
        {
            int liczba = 0;
            Random random= new Random();
            liczba = random.Next(1, 20);
            return liczba;
        }
    }
    public class Hints
    {
        public void Hint1(int a)
        {
            if(a%2==0)
            {
                Console.WriteLine("Liczba jest parzysta");
            }
            else
            {
                Console.WriteLine("Liczba nie jest parzysta ");
            }
        }
        public void Hint2(int a)
        {
            if (a*a>20)
            {
                Console.WriteLine("Liczba po podniesieniu do kwadratu przyjmuje wartość większą od 20");
            }
            else
            {
                Console.WriteLine("Liczba po podniesieniu do kwadratu przyjmuje wartość mniejszą od 20");
            }
        }
        public void Hint3(int a)
        {
            double b;
            b = (double)a;

            if (Math.Sqrt(b)%1==0)
            {
                Console.WriteLine("Liczba po spierwiastkowaniu jest liczbą całkowitą");
            }
            else
            {
                Console.WriteLine("Liczba po spierwiastkowaniu nie jest liczbą całkowitą");
            }
        }
        public void Hint4(int a)
        {
            int start, end;
            Console.WriteLine("Podaj 2 liczby i sprawdz czy szukana liczba lezy w tym zakresie:");
            Console.WriteLine("Podaj początek zakresu:");
            start = int.Parse(Console.ReadLine());
            end = int.Parse(Console.ReadLine());

            if ((a>=start)&&(a<=end))
            {
                Console.WriteLine($"Liczba leży w zakresie <{start};{end}>");
            }
            else
            {
                Console.WriteLine($"Liczba nie leży w zakresie <{start};{end}>");
            }
        }
    }
}
