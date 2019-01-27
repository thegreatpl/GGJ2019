using Assets.Scripts.StarSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpPointViewModel : MonoBehaviour
{
    public WarpPoint WarpPoint; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void LoadWarpPoint(WarpPoint warpPoint)
    {
        WarpPoint = warpPoint; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            GameController.Game.Galaxy.LoadStarSystem(WarpPoint.ToSystem);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            GameController.Game.Galaxy.LoadStarSystem(WarpPoint.ToSystem); 
    }

}
