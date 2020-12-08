namespace LP2_Exoplanets_2020
{
    public struct StringFilter : IFilter
    {
        public string FieldName { get; set; }

        public string FilterToCompare { get; set; }

public StringFilter(string fieldName, string filterToCompare)
        {
            FieldName = fieldName;
            FilterToCompare = filterToCompare;
        }
    }
}