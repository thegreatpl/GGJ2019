using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipControlScript : MonoBehaviour
{
    public float Speed = 1f;

    public float RotationSpeed = 0.1f;

    public float MaxSurveySpeed = 2f; 

    public Rigidbody2D Rigidbody2D; 

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        

    }

   public  void RotateClockwise()
    {
        Rigidbody2D.rotation += RotationSpeed; 
    }

    public void RotateAntiClockwise()
    {
        Rigidbody2D.rotation -= RotationSpeed;

    }

    public void Accelerate()
    {
        Rigidbody2D.AddForce(transform.up * Speed); 
    }

    public void Decelerate()
    {
        Rigidbody2D.AddForce((transform.up * Speed) * -1);
    }

   

    public void AllStop()
    {
        Rigidbody2D.velocity = Vector2.zero; 
    }
}
