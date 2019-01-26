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
        var horizonatal = Input.GetAxis("Horizontal");
        if (horizonatal < 0)
            RotateClockwise();
        if (horizonatal > 0)
            RotateAntiClockwise();

        var verticle = Input.GetAxis("Vertical");
        if (verticle < 0)
            Decelerate();
        else if (verticle > 0)
            Accelerate();

        //this close to zero speed? stop then. 
       else if (Rigidbody2D.velocity.magnitude < 0.2f)
            AllStop();

        if (Input.GetButtonDown("Survey"))
            Survey(); 

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

    /// <summary>
    /// Attempts to survey at the current position. 
    /// </summary>
    void Survey()
    {
        var speed = Rigidbody2D.velocity.magnitude; 

        if (speed > MaxSurveySpeed)
        {
            Debug.Log("Too fast to survey");
            return; 
        }

        var possibles = Physics2D.OverlapPointAll(new Vector2(transform.position.x, transform.position.y));
        var tosurvey = possibles.Where(x => x.GetComponent<SurveyObjectViewModel>() != null); 
        if (tosurvey.Count() < 1)
        {
            Debug.Log("Nothing to survey here!");
            return; 
        }
        AllStop(); 


    }

    void AllStop()
    {
        Rigidbody2D.velocity = Vector2.zero; 
    }
}
