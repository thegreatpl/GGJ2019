using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SpeedControlPanelScript : MonoBehaviour
{
    /// <summary>
    /// The object to follow. 
    /// </summary>
    public GameObject FollowObject;

    public Rigidbody2D FollowRigidbody; 


    public Text VelocityText;

    public Text PositionText; 

    // Start is called before the first frame update
    void Start()
    {
        var texts = GetComponentsInChildren<Text>();
        VelocityText = texts.FirstOrDefault(x => x.name == "Velocity");
        PositionText = texts.FirstOrDefault(x => x.name == "Position");
      
    }

    public void SetFollowObject(GameObject gameObject)
    {
        FollowObject = gameObject; 
        if (FollowObject != null)
            FollowRigidbody = FollowObject?.GetComponent<Rigidbody2D>(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FollowObject != null)
        {
            PositionText.text = $"Position: {FollowObject.transform.position}"; 
        }
        if (FollowRigidbody != null)
        {
            VelocityText.text = $"Velocity: {FollowRigidbody.velocity}"; 

        }
    }
}
