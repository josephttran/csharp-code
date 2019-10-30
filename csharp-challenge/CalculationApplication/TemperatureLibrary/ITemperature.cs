using System.Collections.Generic;

namespace TemperatureLibrary
{
    interface ITemperature
    {
        List<int> Temperatures { get; }
        double? Average { get; }
        int? Maximum { get; }
        int? Minimum { get; }

        void Insert(int number);
        void Insert(string wordNumber);
    }
}
