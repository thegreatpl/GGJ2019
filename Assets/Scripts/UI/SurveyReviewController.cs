using Assets.Scripts.StarSystems;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurveyReviewController : MonoBehaviour
{
    /// <summary>
    /// The content panel for the survey review controller. 
    /// </summary>
    public GameObject Contentpanel;

    /// <summary>
    /// Main information of the panel. 
    /// </summary>
    public Text Text; 

    // Start is called before the first frame update
    void Start()
    {
        if (Text == null)
            InitText(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitText()
    {
        var txtObj = new GameObject();
        txtObj.transform.parent = Contentpanel.transform;
        Text = txtObj.AddComponent<Text>(); 
    }

    /// <summary>
    /// Shows the survey in the survey review panel. 
    /// </summary>
    /// <param name="survey"></param>
    public void ShowSurvey(SurveyObject survey)
    {
        GameController.Game.Pause = true; 
        if (Text == null)
            InitText(); 

        Text.text = $"System Survey Review: {Environment.NewLine}" +
            $"StarSystem: {survey.StarSystem} {Environment.NewLine}" +
            $"Name: {survey.Name} {Environment.NewLine}" +
            $"Type: {survey.Type} {Environment.NewLine}" +
            $"Atmosphere: {survey.Atmosphere} {Environment.NewLine}" +
            $"Size: {survey.Size} {Environment.NewLine}" +
            $"Resources: {Environment.NewLine}"; 

        foreach(var res in survey.Resources)
        {
            Text.text += $"     {res.Name}: {res.Amount}"; 
        }
    }


    public void Close()
    {
        CloseWindow(); 
    }

    void CloseWindow()
    {
        GameController.Game.UIManager.RemoveObject("SurveyReview");
        GameController.Game.Pause = false;

    }
}
