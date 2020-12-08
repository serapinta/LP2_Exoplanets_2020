using System.Collections.Generic;

namespace LP2_Exoplanets_2020
{
    public class Star : IEntity
    {
        //star name
        public string StarName { get; set; }
        //star effective temperature (kelvins)
        public float St_teff { get; set; }
        //star radius (sun relation)
        public float St_rad { get; set; }
        // Star mass (sun relation)
        public float St_mass { get; set; }
        //star age (Giga-years)
        public float St_age { get; set; }
        //star rotational velocity (km/s)
        public float St_vsin { get; set; }
        //star rotational period (days)
        public float St_rotp { get; set; }
        //star distance from Sun
        public float Sy_dist { get; set; }

        public List<string> HostedPlanetsName { get; set; }

        public Star(string[] fields, string[] fieldsOrder)
        {
            for (int i = 0; i < fieldsOrder.Length; i++)
            {

                switch (fieldsOrder[i])
                {

                    case "hostname":
                        StarName = fields[i];
                        break;

                    case "st_teff":
                        St_teff = (fields[i] != null && fields[i].Length != 0) ?
                         (float)double.Parse(fields[i], System.Globalization.CultureInfo.InvariantCulture) : 0f;
                        break;

                    case "st_rad":
                        St_rad = (fields[i] != null && fields[i].Length != 0) ?
                         (float)double.Parse(fields[i], System.Globalization.CultureInfo.InvariantCulture) : 0f;
                        break;

                    case "st_mass":
                        St_mass = (fields[i] != null && fields[i].Length != 0) ?
                          (float)double.Parse(fields[i], System.Globalization.CultureInfo.InvariantCulture) : 0f;
                        break;

                    case "st_age":
                        St_age = (fields[i] != null && fields[i].Length != 0) ?
                         (float)double.Parse(fields[i], System.Globalization.CultureInfo.InvariantCulture) : 0f;
                        break;

                    case "st_vsin":
                        St_vsin = (fields[i] != null && fields[i].Length != 0) ?
                          (float)double.Parse(fields[i], System.Globalization.CultureInfo.InvariantCulture) : 0f;
                        break;

                    case "st_rotp":
                        St_rotp = (fields[i] != null && fields[i].Length != 0) ?
                          (float)double.Parse(fields[i], System.Globalization.CultureInfo.InvariantCulture) : 0f;
                        break;

                    case "sy_dist":
                        Sy_dist = (fields[i] != null && fields[i].Length != 0) ?
                          (float)double.Parse(fields[i], System.Globalization.CultureInfo.InvariantCulture) : 0f;
                        break;
                }
            }
        }

        public void ActualizeValues(Planet newValues)
        {
            St_teff = newValues.HostStar.St_teff;
            St_rad = newValues.HostStar.St_rad;
            St_mass = newValues.HostStar.St_mass;
            St_age = newValues.HostStar.St_age;
            St_rotp = newValues.HostStar.St_rotp;
            St_rotp = newValues.HostStar.St_rotp;
            Sy_dist = newValues.HostStar.Sy_dist;
            HostedPlanetsName.Add(newValues.Pl_name);

        }
        public int CountHostedPlanets() => HostedPlanetsName.Count;

    }
}