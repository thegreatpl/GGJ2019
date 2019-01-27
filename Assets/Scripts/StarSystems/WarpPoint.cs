using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.StarSystems
{
    [Serializable]
    public class WarpPoint : IPosition
    {

        /// <summary>
        /// What system to warp to. 
        /// </summary>
        public Vector2Int ToSystem;

        public Vector3 Position { get; set; }
    }
}
