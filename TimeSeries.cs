using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vremRyad
{    
    class TimeSeries
    {
        public enum Methods
        {
            AverageGrowthRate,
            Stationary,
            AveragePerformanceIndicators
        };

        private double[] data;
        private Methods selectedMethod = Methods.AverageGrowthRate;


        public double[] Data { get => data; set => data = value; }
        public Methods SelectedMethod { get => selectedMethod; set => selectedMethod = value; }

        public TimeSeries()
        {
        }


        public double[][] absoluteIncrease()
        {
            double[][] increaseValues = new double[this.data.Length][];
            increaseValues[0] = new double[2];

            for (int i = 1; i < this.data.Length; i++)
            {
                double chainedIncrease = this.data[i] - this.data[i - 1];
                double basisIncrease = this.data[i] - this.data[0];

                increaseValues[i] = new double[] { Math.Round(chainedIncrease, 2), Math.Round(basisIncrease, 2) };
            }

            return increaseValues;
        }
        
        public double[][] growthRate()
        {
            double[][] growthValues = new double[this.data.Length][];
            growthValues[0] = new double[2];

            for (int i = 1; i < this.data.Length; i++)
            {
                double chainedGrowth = (this.data[i] / this.data[i - 1]) * 100;
                double basisGrowth = this.data[i] / this.data[0] * 100;

                growthValues[i] = new double[] { Math.Round(chainedGrowth, 2), Math.Round(basisGrowth, 2) };
            }

            return growthValues;
        }



    }
}
 