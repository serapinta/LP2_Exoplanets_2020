using System;

namespace LP2_Exoplanets_2020
{
    public class Planet
    {

        //star name
        public string Pl_name { get; set; }
        public string Discoverymethod { get; set; }
        //star radius (sun relation)
        public float Disc_year { get; set; }
        // Star mass (sun relation)
        public float Pl_orbper { get; set; }
        //star age (Giga-years)
        public float Pl_rade { get; set; }
        //star rotational velocity (km/s)
        public float Pl_masse { get; set; }
        //star rotational period (days)
        public float Pl_eqt { get; set; }

        public Star HostStar { get; set; }

        public Planet(string[] fields, string[] fieldsOrder)
        {
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
                        Discoverymethod = fields[i];
                        break;

                    case "pl_orbper":
                        Pl_orbper = fields[i] != null ? (float)Convert.ToDouble(fields[i]) : 0f;
                        break;

                    case "pl_rade":
                        Pl_rade = fields[i] != null ? (float)Convert.ToDouble(fields[i]) : 0f;
                        break;

                    case "pl_masse":
                        Pl_masse = fields[i] != null ? (float)Convert.ToDouble(fields[i]) : 0f;
                        break;

                    case "pl_eqt":
                        Pl_eqt = fields[i] != null ? (float)Convert.ToDouble(fields[i]) : 0f;
                        break;

                    case "st_teff":
                        HostStar.St_teff = fields[i] != null ? (float)Convert.ToDouble(fields[i]) : 0f;
                        break;

                    case "st_rad":
                        HostStar.St_rad = fields[i] != null ? (float)Convert.ToDouble(fields[i]) : 0f;
                        break;

                    case "st_mass":
                        HostStar.St_mass = fields[i] != null ? (float)Convert.ToDouble(fields[i]) : 0f;
                        break;

                    case "st_age":
                        HostStar.St_age = fields[i] != null ? (float)Convert.ToDouble(fields[i]) : 0f;
                        break;

                    case "st_vsin":
                        HostStar.St_vsin = fields[i] != null ? (float)Convert.ToDouble(fields[i]) : 0f;
                        break;

                    case "st_rotp":
                        HostStar.St_rotp = fields[i] != null ? (float)Convert.ToDouble(fields[i]) : 0f;
                        break;

                    case "sy_dist":
                        HostStar.Sy_dist = fields[i] != null ? (float)Convert.ToDouble(fields[i]) : 0f;
                        break;


                }


            }

        Console.WriteLine("planet {0} generated.",Pl_name);

        }


    }
}