namespace PuntosColombia.MissingNumbers
{
    using PuntosColombia.MissingNumbers.Core.Entities;
    using System.Linq;

    public class Number
    {
        private readonly int[] _arr;
        private readonly int[] _brr;

        public Number(int[] arr, int[] brr)
        {
            _arr = arr;
            _brr = brr;
        }

        // Validator of entity MissingNumbers
        private Result<string> Valid()
        {
            if (_arr.Count() == 0 || _brr.Count() == 0)
            {
                return new Result<string>() { Successful = false, Message = "El arreglo a o b esta vacio" };
            }

            return new Result<string>() { Successful = true };
        }

        // Get the missing numbers
        public Result<int[]> GetMissingNumbers()
        {
            Result<int[]> result = new Result<int[]>();

            if (!Valid().Successful)
            {
                result.Successful = false;
                result.Message = Valid().Message;

                return result;
            }

            var alist = _arr.GroupBy(a => a)
                           .Select(a => new { Number = a.Key, Count = a.Count() });

            int minValue = _arr.Min();
            var blist = _brr.GroupBy(bl => bl)
                           .Where(bl => bl.Key >= minValue && bl.Key <= (minValue + 100))
                           .Select(bl => new { Number = bl.Key, Count = bl.Count() })
                           .OrderBy(bl => bl.Number);

            var aMissingNumbers = blist.Where(bl => !alist.Any(al => (al.Number == bl.Number && al.Count == bl.Count)))
                              .Select(bl => bl.Number)
                              .ToArray();

            result.Successful = true;
            result.Data = aMissingNumbers;

            return result;
        }
    }
}
