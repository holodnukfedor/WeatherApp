namespace WeartherStateBLL.Models
{
    internal class OpenWeatherByZipCodeState
    {
        internal class Main
        {
            public double temp { get; set; }
        }

        public Main main { get; set; }
        public string name { get; set; }

    }
}
