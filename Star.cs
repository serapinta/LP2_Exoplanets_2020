namespace LP2_Exoplanets_2020
{
    public class Star
    {
        //star name
        public string StarName { get; internal set; }
        //star effective temperature (kelvins)
        public float St_teff { get;internal set; }
        //star radius (sun relation)
        public float St_rad { get;internal set; }
        // Star mass (sun relation)
        public float St_mass { get; internal set; }
        //star age (Giga-years)
        public float St_age { get; internal set; }
        //star rotational velocity (km/s)
        public float St_vsin { get;internal set; }
        //star rotational period (days)
        public float St_rotp { get;internal set; }
        //star distance from Sun
        public float Sy_dist { get;internal set; }

    }
}