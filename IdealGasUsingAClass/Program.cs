using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace IdealGasUsingAClass
{
    class Program
    {
        static void Main(string[] args)
        {

            string another = " ";
            do
            {
                try
                {
                    string[] gasNames = new string[100];
                    double[] molecularWeights = new double[100];
                    int count = 0;
                    string gasName = " ";
                    int countGases = 0;
                    double mass = 0.0;
                    double molecularWeight = 0.0;
                    double volume = 0.0;
                    double temp = 0.0;
                    double pascals = 0.0;



                    GetMolecularWeights(ref gasNames, ref molecularWeights, out count);

                    DisplayGasNames(gasNames, countGases);

                    molecularWeight = GetMolecularWeightFromName(gasName, gasNames, molecularWeights, countGases);


                    IdealGas gas = new IdealGas();

                    Console.WriteLine("Please enter the mass of the gas in grams: ");
                    mass = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Please enter the temperature of the gas in Celcius: ");
                    temp = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Please enter the volume of your container in cubic meters: ");
                    volume = Convert.ToDouble(Console.ReadLine());

                    gas.SetVolume(volume);
                    gas.SetMass(mass);
                    gas.SetTemp(temp);

                    gas.SetMolecularWeight(molecularWeight);

                    pascals = gas.GetPressure();

                    DisplayPressure(pascals);
                }
                catch (FormatException exc)
                {
                    Console.WriteLine("There was a format exeception." + exc);
                }
                catch (OverflowException exc)
                {
                    Console.WriteLine("There was an overflow exeception." + exc);
                }
                catch (Exception exc)
                {
                    Console.WriteLine("Error: " + exc);
                }

                Console.WriteLine("Would you like to find the pressure of another gas? Please enter yes or no.");
                another = Console.ReadLine();

            } while (another.Equals("yes"));

            Console.WriteLine("Have a nice day. Goodbye.");
        }
        static void GetMolecularWeights(ref string[] gasNames, ref double[] molecularWeights, out int count)
        {
            string[] readText = File.ReadAllLines("MolecularWeightsGasesAndVapors (2).csv"); 
            readText = readText.Where(i => !string.IsNullOrEmpty(i)).ToArray(); 
            for (int i = 1; i < readText.Length; ++i)
            {
                string[] text = readText[i].Split(",");

                gasNames[i] = text[0];
                molecularWeights[i] = Convert.ToDouble(text[1]);              

            }

            count = readText.Length - 1;
        }

        private static void DisplayGasNames(string[] gasNames, int countGases)
        {

            Console.WriteLine("The gas names are: ");
            Console.WriteLine($"{ " First Column",-25 }\t{ "Second Column",-25}\t{ "Third Column",-25}");
            Console.WriteLine($"{" _____________",-25}\t{"______________",-25}\t{"______________",-25}");

            for (int i = 1; i < gasNames.Length; i += 3)
            {
                Console.WriteLine($"{gasNames[i],-25}\t{gasNames[i + 1],-25}\t{gasNames[i + 2], -25}");
            }

        }

         public static double GetMolecularWeightFromName(string gasName, string[] gasNames, double[] molecularWeights, int countGases)
        {

            double molecularWeight = 0.0;

                Console.WriteLine("Enter the gas name you would like to use.");
                gasName = Console.ReadLine();
                countGases = Array.IndexOf(gasNames, gasName);

                if (gasNames.Contains(gasName))
                {

                    Console.WriteLine("The gas name " + $"{ gasName }, is at index {countGases}. ");
                    molecularWeight = molecularWeights[countGases];
                    //Console.WriteLine("The molecular weight of your gas is " + $"{molecularWeight}.");


                    

                    return molecularWeight;
                 
                }
                else
                {
                    Console.WriteLine("The name you entered is not on the list.");
                    return -1;
                }
        }

        private static void DisplayPressure(double pascals)
        {
            double psi = 0.0;

            Console.WriteLine("The pressure of your gas in Pascals is " + $"{pascals}");
            psi = PaToPSI(pascals);
            Console.WriteLine("The pressure of your gas in psi is " + $"{psi}.");

        }

       
        private static double PaToPSI(double pascals)
        {

            double psi = 0.0;

            psi = pascals / 6895;

            return psi;
        }
    }
}
