namespace PuntosColombia.MissingNumbers
{
    using PuntosColombia.MissingNumbers.Application.Services;
    using System;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            // ARREGLO UNO INGRESAR 203 204 205 206 207 208 203 204 205 206
            // ARREGLO DOS INGRESAR 203 204 204 205 206 207 205 208 203 206 205 206 204
            // RESULTADO 204 205 206

            Console.WriteLine("Enter numbers list one");
            string arr = Console.ReadLine();

            Console.WriteLine("Enter numbers list two");
            string brr = Console.ReadLine();

            Console.WriteLine("Missing numbers");
            NumberService numberService = new NumberService();

            Console.WriteLine(numberService.MissingNumbers(arr, brr));
            Console.ReadLine();
        }
    }
}
