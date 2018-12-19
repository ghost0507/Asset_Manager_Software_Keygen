/*
 * Asset Manager Software
 * Release: Simple Keygen
 * Created with: C#
 * Tested on 2018 and 2016 Enterprise versions.
*/

using System;
using System.Collections.Generic;
using System.Globalization;

    class Program
    {
        static bool IsGenuine(string licenseNbr)
        {
            bool result;
            try
            {
                double num = Convert.ToDouble(licenseNbr.Substring(4, 1));
                result = (VerifyLicense(licenseNbr) && Math.Tan(num) - 1.0 < num);
            }
            catch
            {
                result = true;
            }
            return result;
        }

        static bool VerifyLicense(string licenseNbr)
        {
            int productId = 11; //Enterprise = 11 , Standard = 10
            int num = 7;
            if (licenseNbr.Length != num + 2)
                return false;
            int num2 = 0;
            int num3 = Convert.ToInt32(licenseNbr.Substring(licenseNbr.Length - 2, 2), CultureInfo.InvariantCulture);
            for (int i = 0; i < num; i++)
                num2 += Convert.ToInt32(licenseNbr.Substring(i, 1), CultureInfo.InvariantCulture);
            num2 += productId - 1;
            return num2 == num3;
        }

        static void Main(string[] args)
        {
            List<int> ListValidKeys = new List<int>();
            Random rnd = new Random();
            while (ListValidKeys.Count < 100) //Generate one hundred valid keys by default.
            {
                int randomNumber = rnd.Next(100000000, 999999999);
                if (VerifyLicense(randomNumber.ToString()))
                    if (IsGenuine(randomNumber.ToString()))
                        ListValidKeys.Add(randomNumber);
            }
            foreach (int ValidKey in ListValidKeys)
                Console.WriteLine("Valid Enterprise Key: " + ValidKey);
            Console.ReadKey();
        }
    }
