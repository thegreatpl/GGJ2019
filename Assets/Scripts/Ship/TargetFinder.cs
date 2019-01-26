using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TargetFinder : MonoBehaviour
{

    List<GameObject> targets = new List<GameObject>(); 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        

    }

    void UpdateTargets()
    {
        var currentStarSystem = GameController.Game.Galaxy.StarSystemViewModel;
        var toSurvey = currentStarSystem.surveyObjectViewModels.Where(x => x.SurveyObject.SurveyProgress < 1); 

    }
}
