using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarfieldUpdate : MonoBehaviour
{
    public float parralax = 2f;


    MeshRenderer MeshRenderer; 

    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer = GetComponent<MeshRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        var mat = MeshRenderer.material;

        var offset = mat.mainTextureOffset;
        offset.x = transform.position.x / transform.localScale.x / parralax;
        offset.y = transform.position.y / transform.localScale.y / parralax;
        mat.mainTextureOffset = offset; 
    }

    /// <summary>
    /// Sets the main starfield texture. 
    /// </summary>
    /// <param name="texture"></param>
    public void SetMainTexture(Texture texture)
    {
        var mat = MeshRenderer.material;
        mat.mainTexture = texture; 
    }
}
