using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageScript : MonoBehaviour
{
    public Text Text; 

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fade()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Fade()
    {
        
        while (Text.color.a > 0)
        {
            Text.color = new Color(Text.color.r, Text.color.g, Text.color.b, Text.color.a -0.01f);
            yield return new WaitForSeconds(0.1f); 
        }

        Destroy(gameObject); 
    }
}
