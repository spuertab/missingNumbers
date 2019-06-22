namespace PuntosColombia.MissingNumbers.Application.Services
{
    using PuntosColombia.MissingNumbers.Core.Entities;
    using System;

    public class NumberService : INumberService
    {
        public string MissingNumbers(string astr, string bstr)
        {
            try
            {
                int[] arr = Array.ConvertAll(astr.Split(' '), arrTemp => Convert.ToInt32(arrTemp));

                int[] brr = Array.ConvertAll(bstr.Split(' '), brrTemp => Convert.ToInt32(brrTemp));

                // Get missing numbers
                Number number = new Number(arr, brr);
                Result<int[]> result = number.GetMissingNumbers();

                if (!result.Successful)
                {
                    throw new Exception("Address not supplied");
                }

                return result.Data.Length > 0 ? string.Join(" ", result.Data) : "none";
            }
            catch (Exception ex)
            {
                throw new Exception("Formato incorrecto");
            }
        }
    }
}
