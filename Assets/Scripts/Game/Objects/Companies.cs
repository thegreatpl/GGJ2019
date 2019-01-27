using Assets.Scripts.StarSystems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Game.Objects
{
    public class Companies
    {
        public string Name;


        public float SizeModifier;

        public Dictionary<string, Rating> AtmosphereRating; 

        

        public float CalculateMaxCompanyPrice(SurveyObject obj)
        {
            //no interest in that atmosphere? return empty price. 
            if (!AtmosphereRating.ContainsKey(obj.Atmosphere))
                return 0;

            float price = 0;


            return price; 
        }
    }


    public class Rating
    {
        public string Name;

        public float Price; 
    }
}
