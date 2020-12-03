namespace LP2_Exoplanets_2020
{
    public class Star
    {
        //star name
        public string StarName { get; set; }
        //star effective temperature (kelvins)
        public float? St_teff { get; set; }
        //star radius (sun relation)
        public float? St_rad { get; set; }
        // Star mass (sun relation)
        public float? St_mass { get; set; }
        //star age (Giga-years)
        public float? St_age { get; set; }
        //star rotational velocity (km/s)
        public float? St_vsin { get; set; }
        //star rotational period (days)
        public float? St_rotp { get; set; }
        //star distance from Sun
        public float? Sy_dist { get; set; }

        public Star(
            string hostName, float st_teff = default, 
            float st_rad = default, float st_mass = default,
            float st_age = default, float st_vsin = default, 
            float st_rotp = default, float sy_dist = default)
        {
            StarName = hostName;
            St_teff = st_teff;
            St_rad = st_rad;
            St_mass = st_mass;
            St_age = st_age;
            St_vsin = st_vsin;
            St_rotp = st_rotp;
            Sy_dist = sy_dist;
        }


    }
}