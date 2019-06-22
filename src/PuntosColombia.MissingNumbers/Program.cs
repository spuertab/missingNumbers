namespace PuntosColombia.MissingNumbers
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            // ARREGLO UNO INGRESAR 203 204 205 206 207 208 203 204 205 206
            // ARREGLO DOS INGRESAR 203 204 204 205 206 207 205 208 203 206 205 206 204
            // RESULTADO 204 205 206

            Console.WriteLine("Enter numbers list one");
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));

            Console.WriteLine("Enter numbers list two");
            int[] brr = Array.ConvertAll(Console.ReadLine().Split(' '), brrTemp => Convert.ToInt32(brrTemp));

            Console.WriteLine("Missing numbers");
            MissingNumbers missingNumbers = new MissingNumbers(arr, brr);
            int[] result = missingNumbers.GetMissingNumbers();

            Console.WriteLine(result.Count() > 0 ? string.Join(" ", result) : "none");
            Console.ReadLine();
        }
    }
}
