namespace PuntosColombia.MissingNumbers
{
    using PuntosColombia.MissingNumbers.Application.Services;
    using System;

    public class Program
    {
        static void Main(string[] args) => EnterNumbers();

        private static void EnterNumbers()
        {
            try
            {
                // LIST A 203 204 205 206 207 208 203 204 205 206
                // LIST B 203 204 204 205 206 207 205 208 203 206 205 206 204
                // RESULT 204 205 206
                Console.WriteLine(string.Empty);
                Console.WriteLine("*** Attention enter the numbers separated by space for list ***");
                Console.WriteLine(string.Empty);

                Console.WriteLine("Enter numbers list 'a' (list with missing numbers):");
                string arr = Console.ReadLine();

                Console.WriteLine("Enter numbers list 'b' (original list of numbers):");
                string brr = Console.ReadLine();

                Console.WriteLine("Missing numbers");
                MissingNumberService numberService = new MissingNumberService();

                Console.WriteLine(numberService.MissingNumbers(arr, brr));
                EnterNumbers();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(string.Empty);
                EnterNumbers();
            }
        }
    }
}
