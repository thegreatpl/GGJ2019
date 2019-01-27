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
        /// <summary>
        /// Name of the company.
        /// </summary>
        public string Name;

        /// <summary>
        /// Multiplier on size. 
        /// </summary>
        public float SizeModifier;

        /// <summary>
        /// Ratings on atmosphere. 
        /// </summary>
        public Dictionary<string, Rating> AtmosphereRating;

        /// <summary>
        /// When this one last won an auction in ticks. 
        /// </summary>
        public int LastWon;

        /// <summary>
        /// How long between it bids. 
        /// </summary>
        public int MinTimeToDevelop;

        /// <summary>
        /// The ratings for the resouces. 
        /// </summary>
        public Dictionary<string, Rating> ResourceRatings; 

        

        public float CalculateMaxCompanyPrice(SurveyObject obj)
        {
            //no interest in that atmosphere? return empty price. 
            if (!AtmosphereRating.ContainsKey(obj.Atmosphere))
                return 0;

            if (MinTimeToDevelop > LastWon)
                return 0; 

            float price = 0;

            if (AtmosphereRating.ContainsKey(obj.Atmosphere))
                price += AtmosphereRating[obj.Atmosphere].Price; 

            foreach(var resource in obj.Resources)
            {
                if (ResourceRatings.ContainsKey(resource.Name))
                {
                    price += ResourceRatings[resource.Name].Price * resource.Amount; 
                }
            }

            price *= (obj.Size * SizeModifier); 

            return price; 
        }
    }


    public class Rating
    {
        public string Name;

        public float Price; 
    }
}
