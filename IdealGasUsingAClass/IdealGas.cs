using System;
using System.Collections.Generic;
using System.Text;

namespace IdealGasUsingAClass
{
    class IdealGas
    {
        private double mass;
        private double volume;
        private double temp;
        private double molecularWeight;
        private double pressure;

        public IdealGas()
        {

        }
        public double GetMass()
        {
            return mass;
        }

        public void SetMass(double value)
        {
            mass = value;
            Console.WriteLine("Is the mass set? " + mass);// nope
            Calc();
        }

        public double GetVolume()
        {
            return volume;
        }

        public void SetVolume(double value)
        {

            volume = value;
            Calc();
        }

        public double GetTemp()
        {
            return temp;
        }

        public void SetTemp(double value)
        {

            temp = value;
            Calc();
        }

        public double GetMolecularWeight()
        {
            return molecularWeight;
        }

        public void SetMolecularWeight(double value)
        {
            molecularWeight = value;
            Calc();
        }

        public double GetPressure()
        {
            return pressure;
        }

        private void Calc()
        {

            double numberMoles = 0.0;
            const double r = 8.3145;
            double kelvin = 0.0;
            
            numberMoles = NumberOfMoles(mass, molecularWeight);
            //Console.WriteLine("Check print num moles?" + numberMoles);
            GetTemp();
            
            kelvin = CelsiusToKelvin(temp);

            pressure = (numberMoles * r * kelvin) / volume;
        }

        private static double NumberOfMoles(double mass, double moleWeight)
        {

            double numberMoles = mass / moleWeight;

            Console.WriteLine("The number of moles is " + $"{numberMoles}"); //calcs 4 times bc calls Calc() 4 times

            return numberMoles;
        }



        private static double CelsiusToKelvin(double temp)
        {

            temp = temp + 273.15;
            Console.WriteLine("Kelvin temp is " + $"{temp}");
            return temp;
        }
    }
}
