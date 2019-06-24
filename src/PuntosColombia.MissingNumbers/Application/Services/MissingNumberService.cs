namespace PuntosColombia.MissingNumbers.Application.Services
{
    using PuntosColombia.MissingNumbers.Core.Entities;
    using System;

    public class MissingNumberService : IMissingNumberService
    {
        public string MissingNumbers(string astr, string bstr)
        {
            int[] arr, brr;

            try
            {
                arr = astr != "" && astr != null ? Array.ConvertAll(astr.Split(' '), arrTemp => Convert.ToInt32(arrTemp)) : null;
                brr = bstr != "" && bstr != null ? Array.ConvertAll(bstr.Split(' '), brrTemp => Convert.ToInt32(brrTemp)) : null;
            }
            catch (Exception)
            {
                throw new Exception("The missing numbers could not be found, the entered data is incorrect, only numbers separated by space are allowed");
            }

            // Get missing numbers
            MissingNumber number = new MissingNumber(arr, brr);
            Result<int[]> result = number.GetMissingNumbers();

            if (!result.Successful)
            {
                throw new Exception($"Error looking for the missing numbers: {result.Message}");
            }

            return result.Data.Length > 0 ? string.Join(" ", result.Data) : "none";
        }
    }
}
