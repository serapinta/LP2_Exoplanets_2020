using System;

namespace LP2_Exoplanets_2020
{
    public class Planet : IEntity
    {
        //Planet name
        public string Pl_name { get; set; }
        //Planet discovery method
        public string DiscoveryMethod { get; set; }
        //Planet discovery year 
        public int Disc_year { get; set; }
        //Planet mass (sun relation)
        public float Pl_orbper { get; set; }
        //Planet age (Giga-years)
        public float Pl_rade { get; set; }
        //Planet rotational velocity (km/s)
        public float Pl_masse { get; set; }
        //Planet Equilibrium Temperature (Kelvin)
        public float Pl_eqt { get; set; }

        //Planet host star
        public Star HostStar { get; set; }

        public Planet(string[] fields, string[] fieldsOrder)
        {
            HostStar = new Star();
            for (int i = 0; i < fieldsOrder.Length; i++)
            {

                switch (fieldsOrder[i])
                {

                    case "pl_name":
                        Pl_name = fields[i];
                        break;

                    case "hostname":
                        HostStar.StarName = fields[i];
                        break;

                    case "discoverymethod":
                        DiscoveryMethod = fields[i];
                        break;

                    case "disc_year":
                        Disc_year = (fields[i] != null && fields[i].Length != 0) ?
                         int.Parse(fields[i], System.Globalization.CultureInfo.InvariantCulture) : 0;
                        break;

                    case "pl_orbper":
                        Pl_orbper = (fields[i] != null && fields[i].Length != 0) ?
                         (float)double.Parse(fields[i], System.Globalization.CultureInfo.InvariantCulture) : 0f;
                        break;

                    case "pl_rade":

                        Pl_rade = (fields[i] != null && fields[i].Length != 0) ?
                         (float)double.Parse(fields[i], System.Globalization.CultureInfo.InvariantCulture) : 0f;
                        break;

                    case "pl_masse":
                        Pl_masse = (fields[i] != null && fields[i].Length != 0) ?
                         (float)double.Parse(fields[i], System.Globalization.CultureInfo.InvariantCulture) : 0f;
                        break;

                    case "pl_eqt":
                        Pl_eqt = (fields[i] != null && fields[i].Length != 0) ?
                         (float)double.Parse(fields[i], System.Globalization.CultureInfo.InvariantCulture) : 0f;
                        break;

                    case "st_teff":
                        HostStar.St_teff = (fields[i] != null && fields[i].Length != 0) ?
                         (float)double.Parse(fields[i], System.Globalization.CultureInfo.InvariantCulture) : 0f;
                        break;

                    case "st_rad":
                        HostStar.St_rad = (fields[i] != null && fields[i].Length != 0) ?
                         (float)double.Parse(fields[i], System.Globalization.CultureInfo.InvariantCulture) : 0f;
                        break;

                    case "st_mass":
                        HostStar.St_mass = (fields[i] != null && fields[i].Length != 0) ?
                         (float)double.Parse(fields[i], System.Globalization.CultureInfo.InvariantCulture) : 0f;
                        break;

                    case "st_age":
                        HostStar.St_age = (fields[i] != null && fields[i].Length != 0) ?
                         (float)double.Parse(fields[i], System.Globalization.CultureInfo.InvariantCulture) : 0f;
                        break;

                    case "st_vsin":
                        HostStar.St_vsin = (fields[i] != null && fields[i].Length != 0) ?
                         (float)double.Parse(fields[i], System.Globalization.CultureInfo.InvariantCulture) : 0f;
                        break;

                    case "st_rotp":
                        HostStar.St_rotp = (fields[i] != null && fields[i].Length != 0) ?
                         (float)double.Parse(fields[i], System.Globalization.CultureInfo.InvariantCulture) : 0f;
                        break;

                    case "sy_dist":
                        HostStar.Sy_dist = (fields[i] != null && fields[i].Length != 0) ?
                         (float)double.Parse(fields[i], System.Globalization.CultureInfo.InvariantCulture) : 0f;
                        break;
                }
            }
        }
    }
}