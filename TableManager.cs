using System;
using System.Collections.Generic;

namespace LP2_Exoplanets_2020
{
    public static class TableManager
    {

        public static void RunTable <T, U>(List<T> planets, List<U> filters) where T: IEntity where U: IFilter
        {
            if (planets == null)
                Console.WriteLine("aaaaaaaaaaa");
            else
            {
                if (filters != null)
                {
                    if (filters.Count > 0)
                    {
                        DrawTable.PrintEntity(GetFilteredList(planets,filters)[0]);
                    }
                    else
                    {
                        DrawTable.PrintEntity(planets[0]);
                    }
                }
               
            }
        }



        public static List<T> GetFilteredList<T, U>( List<T> entities, List<U> filters) where T : IEntity where U : IFilter
        {
            List<T> filteredList = new List<T>();



            for (int i = 0; i < entities.Count; i++)
            {
                if (ValidateFields(entities[i], filters))
                {
                    filteredList.Add(entities[i]);
                }
            }



            return filteredList;

        }

        public static bool ValidateFields<T, U>(T entityToValidate, List<U> filters) where T : IEntity where U : IFilter
        {
            if (entityToValidate is Planet)
            {
                for (int i = 0; i < filters.Count; i++)
                {

                    switch (filters[i].FieldName)
                    {

                        case "pl_name":

                            if (
                                (entityToValidate as Planet).Pl_name.Contains(
                                ((filters[i]) as StringFilter).FilterToCompare
                                )
                                )
                                return true;
                            break;

                        case "hostname":
                            if ((entityToValidate as Planet).HostStar.StarName.Contains(
                                ((filters[i]) as StringFilter).FilterToCompare))
                                return true;
                            break;


                        case "discoverymethod":
                            if ((entityToValidate as Planet).DiscoveryMethod.Contains(
                                ((filters[i]) as StringFilter).FilterToCompare))
                                return true;
                            break;

                        case "disc_year":

                            if (Convert.ToInt32(
                                ((filters[i]) as NumericFilter).MinValue) >= (entityToValidate as Planet).Disc_year &&
                            Convert.ToInt32(
                               ((filters[i]) as NumericFilter).MaxValue) <= (entityToValidate as Planet).Disc_year
                               )
                            { return true; }
                            break;

                        case "pl_orbper":

                            if (
                                ((filters[i]) as NumericFilter).MinValue >= (entityToValidate as Planet).Pl_orbper &&
                                ((filters[i]) as NumericFilter).MaxValue <= (entityToValidate as Planet).Pl_orbper
                                )
                            { return true; }
                            break;

                        case "pl_rade":

                            if (
                                ((filters[i]) as NumericFilter).MinValue >= (entityToValidate as Planet).Pl_rade &&
                                ((filters[i]) as NumericFilter).MaxValue <= (entityToValidate as Planet).Pl_rade
                                )
                            { return true; }
                            break;

                        case "pl_masse":

                            if (
                                ((filters[i]) as NumericFilter).MinValue >= (entityToValidate as Planet).Pl_masse &&
                                ((filters[i]) as NumericFilter).MaxValue <= (entityToValidate as Planet).Pl_masse
                                )
                            { return true; }
                            break;

                        case "pl_eqt":

                            if (
                               ((filters[i]) as NumericFilter).MinValue >= (entityToValidate as Planet).Pl_eqt &&
                               ((filters[i]) as NumericFilter).MaxValue <= (entityToValidate as Planet).Pl_eqt
                                )
                            { return true; }
                            break;
                    }
                }
            }

            if (entityToValidate is Star)
            {
                for (int i = 0; i < filters.Count; i++)
                {

                    switch (filters[i].FieldName)
                    {
                        case "starname":

                            if (
                                (entityToValidate as Star).StarName.Contains(
                                ((filters[i]) as StringFilter).FilterToCompare)
                                )
                                return true;
                            break;

                        case "st_teff":

                            if (
                                ((filters[i]) as NumericFilter).MinValue >= (entityToValidate as Star).St_teff &&
                                ((filters[i]) as NumericFilter).MaxValue <= (entityToValidate as Star).St_teff
                                )
                            { return true; }
                            break;

                        case "st_rad":

                            if (
                                ((filters[i]) as NumericFilter).MinValue >= (entityToValidate as Star).St_rad &&
                                ((filters[i]) as NumericFilter).MaxValue <= (entityToValidate as Star).St_rad
                                )
                            { return true; }
                            break;

                        case "st_mass":

                            if (
                                ((filters[i]) as NumericFilter).MinValue >= (entityToValidate as Star).St_mass &&
                                ((filters[i]) as NumericFilter).MaxValue <= (entityToValidate as Star).St_mass
                                )
                            { return true; }
                            break;

                        case "st_age":

                            if (
                                ((filters[i]) as NumericFilter).MinValue >= (entityToValidate as Star).St_age &&
                                ((filters[i]) as NumericFilter).MaxValue <= (entityToValidate as Star).St_age
                                )
                            { return true; }
                            break;

                        case "st_vsin":

                            if (
                                ((filters[i]) as NumericFilter).MinValue >= (entityToValidate as Star).St_vsin &&
                                ((filters[i]) as NumericFilter).MaxValue <= (entityToValidate as Star).St_vsin
                                )
                            { return true; }
                            break;


                        case "st_rotp":

                            if (
                                ((filters[i]) as NumericFilter).MinValue >= (entityToValidate as Star).St_rotp &&
                                ((filters[i]) as NumericFilter).MaxValue <= (entityToValidate as Star).St_rotp
                                )
                            { return true; }
                            break;

                        case "sy_dist":

                            if (
                                ((filters[i]) as NumericFilter).MinValue >= (entityToValidate as Star).Sy_dist &&
                                ((filters[i]) as NumericFilter).MaxValue <= (entityToValidate as Star).Sy_dist
                                )
                            { return true; }
                            break;
                    }
                }
            }
            return false;

        }

    }
}