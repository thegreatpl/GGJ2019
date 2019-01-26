using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFinderController : MonoBehaviour
{
    public Player Player;

    public SurveyObjectViewModel SurveyObjectViewModel;

    public CameraFollowScript Camera; 

    // Start is called before the first frame update
    void Start()
    {
        Player = GameController.Game.Player;
        Camera = GameController.Game.CameraFollowScript; 
    }

    // Update is called once per frame
    void Update()
    {
        if (SurveyObjectViewModel == null)
        {
            Destroy(gameObject);
            return; 
        }

        var raycast = Physics2D.Linecast(SurveyObjectViewModel.transform.position, Player.transform.position, 8);
        transform.position = Camera.ToScreenPosition(raycast.point); 

    }
}
