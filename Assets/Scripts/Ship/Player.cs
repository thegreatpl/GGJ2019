using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    /// <summary>
    /// How fast this player surveys. 
    /// </summary>
    public float SurveySpeed = 0.01f; 

    public ShipControlScript ShipControlScript;

    /// <summary>
    /// Money this player has. 
    /// </summary>
    public float Money; 

    // Start is called before the first frame update
    void Start()
    {
        ShipControlScript = GetComponent<ShipControlScript>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameController.Game.Pause)
        {
            var horizonatal = Input.GetAxis("Horizontal");
            if (horizonatal < 0)
                ShipControlScript.RotateClockwise();
            if (horizonatal > 0)
                ShipControlScript.RotateAntiClockwise();

            var verticle = Input.GetAxis("Vertical");
            if (verticle < 0)
                ShipControlScript.Decelerate();
            else if (verticle > 0)
                ShipControlScript.Accelerate();

            //this close to zero speed? stop then. 
            else if (ShipControlScript.Rigidbody2D.velocity.magnitude < 0.2f)
                ShipControlScript.AllStop();

            if (Input.GetButtonDown("Survey"))
                Survey();
        }
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

    /// <summary>
    /// Attempts to survey at the current position. 
    /// </summary>
    public void Survey()
    {
        var speed = ShipControlScript. Rigidbody2D.velocity.magnitude;

        if (speed > ShipControlScript. MaxSurveySpeed)
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
        ShipControlScript.AllStop();

        var survey = tosurvey.First().GetComponent<SurveyObjectViewModel>();
        if (survey == null)
            return;


        if (survey.SurveyObject.SurveyProgress < 1)
            StartCoroutine(SurveyObject(survey));
        else
            ShowSurveyReview(survey); 
    }

    public IEnumerator SurveyObject(SurveyObjectViewModel target)
    {
        if (target == null)
            yield break; 

        var ui = GameController.Game.UIManager;
        var obj = ui.AddObject("surveyProgress", "Text", ui.CameraScript.ToScreenPosition(transform.position));
        var text = obj.GetComponent<Text>(); 
        while(target.SurveyObject.SurveyProgress < 1 && Input.GetButton("Survey"))
        {
            target.SurveyObject.SurveyProgress += (SurveySpeed / target.SurveyObject.SurveyDifficulty);
            text.text = $"{(target.SurveyObject.SurveyProgress * 100).ToString("#.##")}% "; 
            yield return null; 
        }
        if (target.SurveyObject.SurveyProgress > 1)
             target.SurveyObject.SurveyProgress = 1; 
        ui.RemoveObject("surveyProgress"); 

        if (target.SurveyObject.SurveyProgress == 1)
            ShowSurveyReview(target);

    }


    void ShowSurveyReview(SurveyObjectViewModel surveyObjectViewModel)
    {
        var ui = GameController.Game.UIManager;
        var obj = ui.AddObject("SurveyReview", "SurveyReview");
        obj.GetComponent<SurveyReviewController>().ShowSurvey(surveyObjectViewModel.SurveyObject); 

    }
}
