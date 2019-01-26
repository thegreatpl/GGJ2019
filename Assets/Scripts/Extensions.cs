using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static partial class Extensions
{
    public static void RescaleToSprite<T>(this T collider) where T : Collider2D
    {
        if (collider is BoxCollider2D)
        {
            Vector2 newSize = collider.gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
            (collider as BoxCollider2D).size = newSize;
            return; 
        }

        if (collider is CircleCollider2D)
        {
            Vector2 newSize = collider.gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
            (collider as CircleCollider2D).radius = newSize.x / 2; 
        }
    }
}

