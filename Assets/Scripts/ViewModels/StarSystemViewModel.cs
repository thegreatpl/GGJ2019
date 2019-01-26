using Assets.Scripts.StarSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSystemViewModel : MonoBehaviour
{

    public StarSystem StarSystem;

    public List<SurveyObjectViewModel> surveyObjectViewModels = new List<SurveyObjectViewModel>(); 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Loads the star system given as this viewmodel. 
    /// </summary>
    /// <param name="starSystem"></param>
    public void LoadStarSystem(StarSystem starSystem)
    {
        StarSystem = starSystem;
        var surveyPrefab = ContentManager.Inst.GetPrefab("SurveyObject");
        if (surveyPrefab == null)
            return; 
        foreach(var obj in StarSystem.Objects)
        {
            var newobj = Instantiate(surveyPrefab, obj.Position, transform.rotation, transform);
            newobj.transform.localScale = Vector3.one * obj.Size; 
            var vm = newobj.GetComponent<SurveyObjectViewModel>();
            vm.LoadSurveyObject(obj);

            //if (vm.SurveyObject.SurveyProgress < 1)
            //{
            //    GameController.Game.UIManager.AddObject($"{vm.SurveyObject.Name}targeter", "TargetFinder")
            //        .GetComponent<TargetFinderController>().SurveyObjectViewModel = vm;
            //}

            surveyObjectViewModels.Add(vm); 
        }
    }

    private void OnDestroy()
    {
        foreach (var obj in surveyObjectViewModels)
            Destroy(obj.gameObject); 
    }
}
