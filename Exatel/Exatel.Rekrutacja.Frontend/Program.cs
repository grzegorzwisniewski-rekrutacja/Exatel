using System;
using System.Linq;




namespace Exatel
{
    public static class Program
    {
        public static void Main
        (
            System.String[] args
        )
        {
            var gminaOperator = new Services.Rekrutacja.GminaService();


            do
            {
                System.Console.WriteLine("Podaj TERYT gminy:");




                var line = System.Console.ReadLine();


                if
                (
                    string.IsNullOrEmpty(line)
                )
                {
                    break;
                }


                if
                (
                    Teryt.TryParse
                    (
                        line, out var teryt
                    )
                )
                {
                    var miasta = gminaOperator.MiastaSearch(teryt.Woj, teryt.Pow, teryt.Gmi, teryt.Rod);




                    foreach (var miasto in miasta)
                    {
                        var ulice = miasto.Ulice;


                        foreach (var ulica in ulice)
                        {
                            System.Console.WriteLine($"{miasto.Nazwa} | {ulica.Cecha} {ulica.Nazwa}");
                        }
                    }
                }
                else
                {
                    System.Console.WriteLine("Podałeś błędy format TERYT");
                }
            }
            while (true);
        }
    }
}
