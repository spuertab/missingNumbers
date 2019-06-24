namespace PuntosColombia.MissingNumbers.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PuntosColombia.MissingNumbers.Core.Entities;

    [TestClass]
    public class MissingNumberTest
    {
        ///<summary>
        ///Test: Missing numbers, ideal test
        ///</summary>
        [TestMethod]
        public void Test_MissingNumber_One()
        {
            int[] arr, brr;

            arr = new int[] { 203, 204, 205, 206, 207, 208, 203, 204, 205, 206 };

            brr = new int[] { 203, 204, 204, 205, 206, 207, 205, 208, 203, 206, 205, 206, 204 };

            MissingNumber number = new MissingNumber(arr, brr);
            Result<int[]> result = number.GetMissingNumbers();

            CollectionAssert.AreEqual(result.Data, new int[] { 204, 205, 206 });
        }

        ///<summary>
        ///Test: Missing numbers in disorder, ideal test
        ///</summary>
        [TestMethod]
        public void Test_MissingNumber_Two()
        {
            int[] arr, brr;

            arr = new int[] { 7, 2, 5, 3, 5, 3 };

            brr = new int[] { 7, 2, 5, 4, 6, 3, 5, 3 };

            MissingNumber number = new MissingNumber(arr, brr);
            Result<int[]> result = number.GetMissingNumbers();

            CollectionAssert.AreEqual(result.Data, new int[] { 4, 6 });
        }

        ///<summary>
        ///Test: Missing numbers, in the list there are numbers that are not in the original list of numbers, 
        ///for this case they are not taken as missing numbers
        ///</summary>
        [TestMethod]
        public void Test_MissingNumber_Three()
        {
            int[] arr, brr;

            arr = new int[] { 1, 1, 2, 3, 4 };

            brr = new int[] { 1, 2, 3 };

            MissingNumber number = new MissingNumber(arr, brr);
            Result<int[]> result = number.GetMissingNumbers();

            CollectionAssert.AreEqual(result.Data, new int[] { 1 });
        }

        ///<summary>
        ///Test: Missing numbers, The difference between maximum and minimum number
        ///in the second list is less than or equal to 100, for this reason does not appear in 1102
        ///</summary>
        [TestMethod]
        public void Test_MissingNumber_Four()
        {
            int[] arr, brr;

            arr = new int[] { 1001, 1002, 1003, 1004 };

            brr = new int[] { 1001, 1002, 1003, 1004, 1005, 1102 };

            MissingNumber number = new MissingNumber(arr, brr);
            Result<int[]> result = number.GetMissingNumbers();

            CollectionAssert.AreEqual(result.Data, new int[] { 1005 });
        }

        ///<summary>
        ///Test: Missing numbers, list b empty or null
        ///for this case they are not taken as missing numbers
        ///</summary>
        [TestMethod]
        public void Test_Listb_EmptyOrNull()
        {
            int[] arr, brr;

            arr = new int[] { 7, 2, 5, 3, 5, 3 };

            brr = null;

            MissingNumber number = new MissingNumber(arr, brr);
            Result<int[]> result = number.GetMissingNumbers();

            Assert.IsFalse(result.Successful);
        }

        ///<summary>
        ///Test: Missing numbers, list a empty or null
        ///for this case they are not taken as missing numbers
        ///</summary>
        [TestMethod]
        public void Test_Lista_EmptyOrNull()
        {
            int[] arr, brr;

            arr = null;

            brr = new int[] { 7, 2, 5, 4, 6, 3, 5, 3 };

            MissingNumber number = new MissingNumber(arr, brr);
            Result<int[]> result = number.GetMissingNumbers();

            Assert.IsTrue(result.Successful);
        }

        ///<summary>
        ///Test: Missing numbers, list a and list b empty or null
        ///for this case they are not taken as missing numbers
        ///</summary>
        [TestMethod]
        public void Test_ListaAndListb_EmptyOrNull()
        {
            int[] arr, brr;

            arr = null;

            brr = null;

            MissingNumber number = new MissingNumber(arr, brr);
            Result<int[]> result = number.GetMissingNumbers();

            Assert.IsFalse(result.Successful);
        }
    }
}
