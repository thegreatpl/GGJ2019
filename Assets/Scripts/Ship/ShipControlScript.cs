using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipControlScript : MonoBehaviour
{
    public float Speed = 1f;

    public float RotationSpeed = 0.1f;

    public Rigidbody2D Rigidbody2D; 

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        var horizonatal = Input.GetAxis("Horizontal");
        if (horizonatal < 0)
            RotateClockwise();
        if (horizonatal > 0)
            RotateAntiClockwise();

        var verticle = Input.GetAxis("Vertical");
        if (verticle < 0)
            Decelerate();
        if (verticle > 0)
            Accelerate(); 
    }

    void RotateClockwise()
    {
        Rigidbody2D.rotation += RotationSpeed; 
    }

    void RotateAntiClockwise()
    {
        Rigidbody2D.rotation -= RotationSpeed;

    }

    void Accelerate()
    {
        Rigidbody2D.AddForce(transform.up * Speed); 
    }

    void Decelerate()
    {
        Rigidbody2D.AddForce((transform.up * Speed) * -1);
    }
}
