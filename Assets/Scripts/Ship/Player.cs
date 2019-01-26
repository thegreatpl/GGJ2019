using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

    public ShipControlScript ShipControlScript; 

    // Start is called before the first frame update
    void Start()
    {
        ShipControlScript = GetComponent<ShipControlScript>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Sets the location of this player. 
    /// </summary>
    /// <param name="location"></param>
    public void SetLocation(Vector3 location)
    {
        ShipControlScript.Rigidbody2D.velocity = Vector3.zero; 
        ShipControlScript.transform.position = location; 
        
    }
}
