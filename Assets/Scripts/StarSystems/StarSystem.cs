using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.StarSystems
{
    public class StarSystem
    {
        /// <summary>
        /// The name of the star system. 
        /// </summary>
        public string Name; 

        /// <summary>
        /// The location of the star system. 
        /// </summary>
        public Vector2Int Location;

        /// <summary>
        /// Where the player will arrive in the star system. 
        /// </summary>
        public Vector3 JumpPoint; 

        /// <summary>
        /// List of objects in the star system that can be surveyed. 
        /// </summary>
        public List<SurveyObject> Objects; 
    }
}
