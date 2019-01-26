using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.StarSystems
{
    [Serializable]
    public class SurveyObject
    {
        /// <summary>
        /// Name of this object. 
        /// </summary>
        public string Name; 

        /// <summary>
        /// Starsystem this object is in. 
        /// </summary>
        public string StarSystem; 

        /// <summary>
        /// Position of this object in the star system. 
        /// </summary>
        public Vector3 Position; 

        /// <summary>
        /// What atmosphere this planet has. 
        /// </summary>
        public string Atmosphere;

        /// <summary>
        /// What sort of object this is. ie; asteroid, rock planet, gas giant. 
        /// </summary>
        public string Type;

        /// <summary>
        /// The image this survey object uses. 
        /// </summary>
        public string Image;

        /// <summary>
        /// Color of this survey object. 
        /// </summary>
        public Color Color; 

        /// <summary>
        /// Size of this object. 
        /// </summary>
        public float Size; 

        /// <summary>
        /// List of resources this planet has. 
        /// </summary>
        public List<Resource> Resources;

        /// <summary>
        /// How difficult this is to survey. 
        /// </summary>
        public float SurveyDifficulty; 

        /// <summary>
        /// How much progress has been made on the survey. 
        /// </summary>
        public float SurveyProgress = 0f; 
    }
}
