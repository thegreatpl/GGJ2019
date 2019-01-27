using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuShip : MonoBehaviour
{
    public ShipControlScript ShipControlScript; 
    // Start is called before the first frame update
    void Start()
    {
        ShipControlScript.MaxArea = 100; 
    }

    // Update is called once per frame
    void Update()
    {
        if (ShipControlScript.Rigidbody2D.velocity.magnitude < 5)
            ShipControlScript.Accelerate();
    }
}
