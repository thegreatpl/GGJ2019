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

    public static T RandomElement<T>(this IEnumerable<T> collection)
    {
        var random = UnityEngine.Random.Range(0, collection.Count());
        return collection.ElementAt(random); 
    }

    public static string ToRoman(this int number)
    {
        //https://stackoverflow.com/questions/7040289/converting-integers-to-roman-numerals
        if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("insert value betwheen 1 and 3999");
        if (number < 1) return string.Empty;
        if (number >= 1000) return "M" + ToRoman(number - 1000);
        if (number >= 900) return "CM" + ToRoman(number - 900);
        if (number >= 500) return "D" + ToRoman(number - 500);
        if (number >= 400) return "CD" + ToRoman(number - 400);
        if (number >= 100) return "C" + ToRoman(number - 100);
        if (number >= 90) return "XC" + ToRoman(number - 90);
        if (number >= 50) return "L" + ToRoman(number - 50);
        if (number >= 40) return "XL" + ToRoman(number - 40);
        if (number >= 10) return "X" + ToRoman(number - 10);
        if (number >= 9) return "IX" + ToRoman(number - 9);
        if (number >= 5) return "V" + ToRoman(number - 5);
        if (number >= 4) return "IV" + ToRoman(number - 4);
        if (number >= 1) return "I" + ToRoman(number - 1);
        throw new ArgumentOutOfRangeException("something bad happened");
    }
}

