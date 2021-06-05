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
            MovingAverage,
            AveragePerformanceIndicators
        };

        private double[] timeSeriesSet;
        private Methods selectedMethod = Methods.AverageGrowthRate;

        private double[][] absoluteIncrease;
        private double[][] chainGrowthRate;
        private double[][] baseGrowthRate;
        private double[][] increaseRate;
        private double[] absoluteIncreaseValueOnePercent;
        private double[] relativeAcceleration;
        private double[] leadRatio;
        private double averageRowLevel;
        private double averageAbsoluteIncrease;
        private double averageAverageChainGrowthRatePercent;

        private int forecastName;
        private int forecastCount = 15;
        private double[][] forecastValues;


        public double[] TimeSeriesSet { get => timeSeriesSet; set => timeSeriesSet = value; }
        public Methods SelectedMethod { get => selectedMethod; set => selectedMethod = value; }
        public double[][] AbsoluteIncrease { get => absoluteIncrease; set => absoluteIncrease = value; }
        public double[][] ChainGrowthRate { get => chainGrowthRate; set => chainGrowthRate = value; }
        public double[][] BaseGrowthRate { get => baseGrowthRate; set => baseGrowthRate = value; }
        public double[][] IncreaseRate { get => increaseRate; set => increaseRate = value; }
        public double[] AbsoluteIncreaseValueOnePercent { get => absoluteIncreaseValueOnePercent; set => absoluteIncreaseValueOnePercent = value; }
        public double[] RelativeAcceleration { get => relativeAcceleration; set => relativeAcceleration = value; }
        public double[] LeadRatio { get => leadRatio; set => leadRatio = value; }
        public double AverageRowLevel { get => averageRowLevel; set => averageRowLevel = value; }
        public double AverageAbsoluteIncrease { get => averageAbsoluteIncrease; set => averageAbsoluteIncrease = value; }
        public double AverageAverageChainGrowthRatePercent { get => averageAverageChainGrowthRatePercent; set => averageAverageChainGrowthRatePercent = value; }
        public double[][] ForecastValues { get => forecastValues; set => forecastValues = value; }
        public int ForecastCount { get => forecastCount; set => forecastCount = value; }
        public int ForecastName { get => forecastName; set => forecastName = value; }

        public TimeSeries()
        {
        }

        public void analyzeAndForecast()
        {
            this.analyze();
            this.forecast(this.SelectedMethod);
        }

        private void analyze()
        {
            this.AbsoluteIncrease = new double[this.timeSeriesSet.Length - 1][];
            this.ChainGrowthRate = new double[this.timeSeriesSet.Length - 1][];
            this.BaseGrowthRate = new double[this.timeSeriesSet.Length - 1][];
            this.IncreaseRate = new double[this.timeSeriesSet.Length - 1][];
            this.AbsoluteIncreaseValueOnePercent = new double[this.timeSeriesSet.Length - 1];
            this.RelativeAcceleration = new double[this.timeSeriesSet.Length - 2];
            this.LeadRatio = new double[this.timeSeriesSet.Length - 2];

            for (int i = 1; i < this.timeSeriesSet.Length; i++)
            {
                this.AbsoluteIncrease[i - 1] = this.calculateAbsoluteIncrease(timeSeriesSet[i], timeSeriesSet[i - 1], timeSeriesSet[0]);
                this.ChainGrowthRate[i - 1] = this.calculateChainGrowthRate(timeSeriesSet[i], timeSeriesSet[i - 1]);
                this.BaseGrowthRate[i - 1] = this.calculateBaseGrowthRate(timeSeriesSet[i], timeSeriesSet[0]);
                this.IncreaseRate[i - 1] = this.calculateIncreaseRate(this.ChainGrowthRate[i - 1][1], this.BaseGrowthRate[i - 1][1]);
                this.absoluteIncreaseValueOnePercent[i - 1] = this.calculateAbsoluteIncreaseValueOnePercent(this.AbsoluteIncrease[i - 1][0], this.IncreaseRate[i - 1][0]);

                if (i < 2)
                {
                    continue;
                }

                this.RelativeAcceleration[i - 2] = this.calculateRelativeAcceleration(this.ChainGrowthRate[i - 1][1], this.ChainGrowthRate[i - 2][1]);
                this.LeadRatio[i - 2] = this.calculateLeadRatio(this.ChainGrowthRate[i - 1][1], this.ChainGrowthRate[i - 2][1]);
            }

            this.AverageRowLevel = calculateAverageRowLevel();
            this.AverageAbsoluteIncrease = calculateAverageAbsoluteIncrease();
            this.AverageAverageChainGrowthRatePercent = calculateAverageChainGrowthRatePercent();
        }

        public double[] calculateAbsoluteIncrease(double current, double previous, double first)
        {
            double chainedIncrease = current - previous;
            double basisIncrease = current - first;

            double[] increaseValues = new double[2] { Math.Round(chainedIncrease, 2), Math.Round(basisIncrease, 2) };

            return increaseValues;
        }

        public double[] calculateChainGrowthRate(double current, double previous)
        {
            double chainedGrowthCoef = current / previous;
            double chainedGrowthPercent = (current / previous) * 100;

            double[] growthValues = new double[2] { Math.Round(chainedGrowthCoef, 2), Math.Round(chainedGrowthPercent, 2) };

            return growthValues;
        }

        public double[] calculateBaseGrowthRate(double current, double first)
        {
            double baseGrowthCoef = current / first;
            double baseGrowthPercent = current / first * 100;

            double[] growthValues = new double[2] { Math.Round(baseGrowthCoef, 2), Math.Round(baseGrowthPercent, 2) };

            return growthValues;
        }

        public double[] calculateIncreaseRate(double currentChainGrowthRate, double currentBaseGrowthRate)
        {
            double chainIncreaseRate = currentChainGrowthRate - 100;
            double baseIncreaseRate = currentBaseGrowthRate - 100;

            double[] growthValues = new double[2] { Math.Round(chainIncreaseRate, 2), Math.Round(baseIncreaseRate, 2) };

            return growthValues;
        }

        public double calculateAbsoluteIncreaseValueOnePercent(double currentChainAbsoluteIncrease, double currentChainIncreaseRate)
        {
            return Math.Round(currentChainAbsoluteIncrease / currentChainIncreaseRate, 2);
        }

        public double calculateRelativeAcceleration(double currentChainGrowthRate, double previousChainGrowthRate)
        {
            return Math.Round(currentChainGrowthRate - previousChainGrowthRate, 2);
        }

        public double calculateLeadRatio(double currentChainGrowthRate, double previousChainGrowthRate)
        {
            return Math.Round(currentChainGrowthRate / previousChainGrowthRate, 2);
        }

        public double calculateAverageRowLevel()
        {
            double timeSeriesSum = 0;

            foreach (double value in this.TimeSeriesSet)
            {
                timeSeriesSum += value;
            }

            return timeSeriesSum / this.TimeSeriesSet.Length;
        }

        public double calculateAverageAbsoluteIncrease()
        {
            double absoluteIncreaseSum = 0;

            foreach (double[] absoluteIncreaseItem in this.AbsoluteIncrease)
            {
                absoluteIncreaseSum += absoluteIncreaseItem[0];
            }

            return absoluteIncreaseSum / this.AbsoluteIncrease.Length;
        }

        public double calculateAverageChainGrowthRatePercent()
        {
            double chainGrowthRateMul = 1;

            foreach (double[] chainGrowthRateItem in this.ChainGrowthRate)
            {
                chainGrowthRateMul *= chainGrowthRateItem[0];
            }

            return Math.Pow(chainGrowthRateMul, 1.0 / this.ChainGrowthRate.Length) * 100;
        }

        private void forecastAverageGrowthRate()
        {
            Console.WriteLine("Средний коэф роста");
            for (int i = 0; i < this.ForecastCount; i++)
            {
                this.ForecastValues[i] = new double[2];
                this.ForecastValues[i][0] = this.ForecastName + i + 1;
                this.ForecastValues[i][1] = this.timeSeriesSet[this.TimeSeriesSet.Length - 1] * Math.Pow(this.AverageAverageChainGrowthRatePercent / 100, i + 1);
                Console.WriteLine(this.ForecastValues[i][0] + " | " + this.ForecastValues[i][1]);
            }
            Console.WriteLine("________________");
        }

        private void forecastAveragePerfomanceIndicators()
        {
            Console.WriteLine("Средние показатели динамики");
            for (int i = 0; i < this.ForecastCount; i++)
            {
                this.ForecastValues[i] = new double[2];
                this.ForecastValues[i][0] = this.ForecastName + i + 1;
                this.ForecastValues[i][1] = this.timeSeriesSet[this.TimeSeriesSet.Length - 1] + (this.AverageAbsoluteIncrease * (i + 1));
                Console.WriteLine(this.ForecastValues[i][0] + " | " + this.ForecastValues[i][1]);
            }
            Console.WriteLine("________________");
        }

        private void forecastMovingAverage()
        {
            Console.WriteLine("Скользящая с 3 уровнями");
            for (int i = 1; i < this.TimeSeriesSet.Length - 1; i++)
            {
                this.ForecastValues[i] = new double[2];
                this.ForecastValues[i][1] = (this.TimeSeriesSet[i - 1] + this.TimeSeriesSet[i] + this.TimeSeriesSet[i + 1]) / 3;
                Console.WriteLine(this.ForecastValues[i][0] + " | " + this.ForecastValues[i][1]);
            }
            Console.WriteLine("________________");
        }

        private void forecast(Methods method)
        {
            this.forecastValues = new double[this.forecastCount][];

            switch (method)
            {
                case Methods.AverageGrowthRate:
                    this.forecastAverageGrowthRate();
                    break;
                case Methods.MovingAverage:
                    this.forecastMovingAverage();
                    break;
                case Methods.AveragePerformanceIndicators:
                    forecastAveragePerfomanceIndicators();
                    break;
                default:
                    throw new Exception("Не выбран метод прогнозирования");
            }
        }

       
    }
}
 