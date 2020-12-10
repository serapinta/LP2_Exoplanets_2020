using System;

namespace LP2_Exoplanets_2020
{
    /// <summary>
    /// Numeric filter class
    /// </summary>
    public class NumericFilter : IFilter
    {
        public string FieldName { get; set; }
        public float MinValue { get;private set; }
        public float MaxValue { get; private set; }

        public NumericFilter(string fieldName, float minValue, float maxValue)
        {
            FieldName = fieldName;
            MinValue = minValue;
            MaxValue = maxValue;
        }
    }
}