using System;
using System.Collections.Generic;

namespace LP2_Exoplanets_2020
{
    public static class TableManager
    {

        public static List<IEntity> GetFilteredList(List<IFilter> filters, List<IEntity> entities, bool isPlanet)
        {
            List<IEntity> filteredList = new List<IEntity>();
            if (isPlanet)
            {
                for (int i = 0; i < entities.Count; i++)
                {
                    if (ValidatePlanetFields((Planet)entities[i], filters))
                    {
                        filteredList.Add(entities[i]);
                    }
                }
            }
            else{

                for (int i = 0; i < entities.Count; i++)
                {

                    if (ValidateStarFields((Star)entities[i], filters))
                    {
                        filteredList.Add(entities[i]);
                    }
                }
            }

        return filteredList;

        }

        public static bool ValidatePlanetFields(Planet entityToValidate, List<IFilter> filters)
        {
            for (int i = 0; i < filters.Count; i++)
            {

                switch (filters[i].FieldName)
                {

                    case "pl_name":

                        if (entityToValidate.Pl_name.Contains(((StringFilter)filters[i]).FilterToCompare))
                            return true;
                        break;

                    case "hostname":
                        if (entityToValidate.HostStar.StarName.
                            Contains(((StringFilter)filters[i]).FilterToCompare))
                            return true;
                        break;


                    case "discoverymethod":
                        if (entityToValidate.DiscoveryMethod.Contains(((StringFilter)filters[i]).FilterToCompare))
                            return true;
                        break;

                    case "disc_year":

                        if (Convert.ToInt32(((NumericFilter)filters[i]).MinValue) >= entityToValidate.Disc_year &&
                        Convert.ToInt32(((NumericFilter)filters[i]).MinValue) <= entityToValidate.Disc_year)
                        { return true; }
                        break;

                    case "pl_orbper":

                        if (((NumericFilter)filters[i]).MinValue >= entityToValidate.Pl_orbper &&
                            ((NumericFilter)filters[i]).MinValue <= entityToValidate.Pl_orbper)
                        { return true; }
                        break;

                    case "pl_rade":

                        if (((NumericFilter)filters[i]).MinValue >= entityToValidate.Pl_rade &&
                            ((NumericFilter)filters[i]).MinValue <= entityToValidate.Pl_rade)
                        { return true; }
                        break;

                    case "pl_masse":

                        if (((NumericFilter)filters[i]).MinValue >= entityToValidate.Pl_masse &&
                            ((NumericFilter)filters[i]).MinValue <= entityToValidate.Pl_masse)
                        { return true; }
                        break;

                    case "pl_eqt":

                        if (((NumericFilter)filters[i]).MinValue >= entityToValidate.Pl_eqt &&
                            ((NumericFilter)filters[i]).MinValue <= entityToValidate.Pl_eqt)
                        { return true; }
                        break;
                }
            }
            return false;

        }

        public static bool ValidateStarFields(Star entityToValidate, List<IFilter> filters)
        {
            for (int i = 0; i < filters.Count; i++)
            {

                switch (filters[i].FieldName)
                {
                    case "starname":

                        if (entityToValidate.StarName.Contains(((StringFilter)filters[i]).FilterToCompare))
                            return true;
                        break;

                    case "st_teff":

                        if (((NumericFilter)filters[i]).MinValue >= entityToValidate.St_teff &&
                            ((NumericFilter)filters[i]).MinValue <= entityToValidate.St_teff)
                        { return true; }
                        break;

                    case "st_rad":

                        if (((NumericFilter)filters[i]).MinValue >= entityToValidate.St_rad &&
                            ((NumericFilter)filters[i]).MinValue <= entityToValidate.St_rad)
                        { return true; }
                        break;

                    case "st_mass":

                        if (((NumericFilter)filters[i]).MinValue >= entityToValidate.St_mass &&
                            ((NumericFilter)filters[i]).MinValue <= entityToValidate.St_mass)
                        { return true; }
                        break;

                    case "st_age":

                        if (((NumericFilter)filters[i]).MinValue >= entityToValidate.St_age &&
                            ((NumericFilter)filters[i]).MinValue <= entityToValidate.St_age)
                        { return true; }
                        break;

                    case "st_vsin":

                        if (((NumericFilter)filters[i]).MinValue >= entityToValidate.St_vsin &&
                            ((NumericFilter)filters[i]).MinValue <= entityToValidate.St_vsin)
                        { return true; }
                        break;


                    case "st_rotp":

                        if (((NumericFilter)filters[i]).MinValue >= entityToValidate.St_rotp &&
                            ((NumericFilter)filters[i]).MinValue <= entityToValidate.St_rotp)
                        { return true; }
                        break;

                    case "sy_dist":

                        if (((NumericFilter)filters[i]).MinValue >= entityToValidate.Sy_dist &&
                            ((NumericFilter)filters[i]).MinValue <= entityToValidate.Sy_dist)
                        { return true; }
                        break;
                }
            }
            return false;

        }

    }
}