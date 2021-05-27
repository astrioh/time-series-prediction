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

                increaseValues[i] = new double[] { chainedIncrease, basisIncrease };
            }

            return increaseValues;
        }
        




    }
}
