namespace PuntosColombia.MissingNumbers
{
    using PuntosColombia.MissingNumbers.Core.Entities;
    using System.Linq;

    public class MissingNumber
    {
        private readonly int[] _arr;
        private readonly int[] _brr;

        public MissingNumber(int[] arr, int[] brr)
        {
            _arr = arr ?? (new int[0]);
            _brr = brr ?? (new int[0]);
        }

        ///<summary>
        ///Validate the entries of the entity, for this case the list b can not be empty since it is the original list of numbers
        ///</summary>
        private Result<string> Valid()
        {
            if (_brr.Count() == 0 || _brr == null)
            {
                return new Result<string>() { Successful = false, Message = "The list b can not be empty" };
            }

            return new Result<string>() { Successful = true };
        }

        ///<summary>
        ///Find the missing numbers from list a in b, according to the business logic specified in the exercise
        ///</summary>
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

            int minValue = _brr.Min();
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
