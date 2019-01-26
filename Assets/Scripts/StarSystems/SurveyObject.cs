using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.StarSystems
{
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
        /// Size of this object. 
        /// </summary>
        public float Size; 

        /// <summary>
        /// List of resources this planet has. 
        /// </summary>
        public List<string> Resources; 
    }
}
