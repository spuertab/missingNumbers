namespace PuntosColombia.MissingNumbers
{
    using System.Linq;

    public class MissingNumbers
    {
        private readonly int[] _arr;
        private readonly int[] _brr;

        public MissingNumbers(int[] arr, int[] brr)
        {
            this._arr = arr;
            this._brr = brr;
        }

        public int[] GetMissingNumbers()
        {
            var alist = this._arr.GroupBy(a => a)
                           .Select(a => new { Number = a.Key, Count = a.Count() });

            int minValue = this._arr.Min();
            var blist = this._arr.GroupBy(bl => bl)
                           .Where(a => a.Key >= minValue && a.Key <= (minValue + 100))
                           .Select(bl => new { Number = bl.Key, Count = bl.Count() })
                           .OrderBy(bl => bl.Number);

            var aMissingNumbers = blist.Where(bl => !alist.Any(al => (al.Number == bl.Number && al.Count == bl.Count)))
                              .Select(bl => bl.Number)
                              .ToArray();

            return aMissingNumbers;
        }
    }
}
