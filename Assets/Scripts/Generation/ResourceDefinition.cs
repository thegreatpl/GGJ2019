using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Generation
{
    [Serializable]
    public class ResourceDefinition
    {
        /// <summary>
        /// Name of this resource. 
        /// </summary>
        public string Name;

        /// <summary>
        /// How rare is this resource. 
        /// </summary>
        public float Rarity;

        /// <summary>
        /// Value per instance of this resource. 
        /// </summary>
        public float ValuePerInstance;

        /// <summary>
        /// What planets these are found on. 
        /// </summary>
        public List<string> PlanetTypes; 
    }
}
