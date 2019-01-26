using Assets.Scripts.StarSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurveyObjectViewModel : MonoBehaviour
{

    public SurveyObject SurveyObject;

    public SpriteRenderer SpriteRenderer;

    public SpriteRenderer MinimapSprite; 

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckMini(); 
    }

    public void LoadSurveyObject(SurveyObject surveyObject)
    {
        SurveyObject = surveyObject;
        var sprite = ContentManager.Inst.GetSprite(surveyObject.Image);
        if (sprite != null)
        {
            if (SpriteRenderer == null)
                SpriteRenderer = GetComponent<SpriteRenderer>(); 


            SpriteRenderer.sprite = sprite;

            GetComponent<CircleCollider2D>().RescaleToSprite(); 
        }
        else
            Debug.Log($"Sprite {surveyObject.Name} not found");


       

    }

    void CheckMini()
    {
        if (SurveyObject.SurveyProgress >= 1)
            MinimapSprite.color = Color.cyan;
    }
}

