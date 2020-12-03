namespace LP2_Exoplanets_2020
{
    public class Planet
    {
        
        //star name
        public string Pl_name { get; set; }
        //star effective temperature (kelvins)
        public string HostName {get;set;}
        public string Discoverymethod  { get; set; }
        //star radius (sun relation)
        public float? Disc_year  { get; set; }
        // Star mass (sun relation)
        public float? Pl_orbper { get; set; }
        //star age (Giga-years)
        public float? Pl_rade  { get; set; }
        //star rotational velocity (km/s)
        public float? Pl_masse  { get; set; }
        //star rotational period (days)
        public float? Pl_eqt  { get; set; }

        public Planet(
             string pl_name, string hostName, string discoveryMethod = default, 
            float disc_year = default, float pl_orbper = default,
            float pl_rade = default, float pl_masse = default, 
            float pl_eqt = default)
        {
            Pl_name = pl_name;
            HostName = hostName;
            Discoverymethod = discoveryMethod;
            Disc_year = disc_year;
            Pl_orbper = pl_orbper;
            Pl_rade = pl_rade;
            Pl_masse = pl_masse;
            Pl_eqt = pl_eqt;
        }


    }
}