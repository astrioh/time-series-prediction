using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vremRyad
{    
    class TimeSeries
    {
        enum Methods
        {
            AverageGrowthRate,
            Stationary,
            AveragePerformanceIndicators
        };

        private Methods method;
        private string[][] data;

        private Methods Method { get => method; set => method = value; }
        public string[][] Data { get => data; set => data = value; }

        public TimeSeries()
        {

        }


        

        
    }
}
