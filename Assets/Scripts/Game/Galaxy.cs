using Assets.Scripts.StarSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Galaxy : MonoBehaviour
{
    public StarSystemViewModel StarSystemViewModel; 

    public Dictionary<Vector2Int, StarSystem> StarSystems = new Dictionary<Vector2Int, StarSystem>(); 

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Generate()
    {
        StarSystems.Add(Vector2Int.zero, new StarSystem()
        {
            Location = Vector2Int.zero,
            JumpPoint = new Vector3(10, 10),
            Name = "TestSystem",
            Objects = new List<SurveyObject>()
            {
                new SurveyObject() { Image = "Base3",
                    Position = new Vector3(20, 20),
                    Size = 1f,
                    Name = "test",
                    StarSystem = "TestSystem",
                SurveyDifficulty = 1f}
            }
        });
        for (int idx = 0; idx < 100; idx++)
        {

            yield return null; 
        }
        LoadStarSystem(Vector2Int.zero);

    }

    /// <summary>
    /// checks to see if the given star system exists. 
    /// </summary>
    /// <param name="exists"></param>
    /// <returns></returns>
    public bool StarSystemExists(Vector2Int exists)
    {
        return StarSystems.ContainsKey(exists); 
    }

    /// <summary>
    /// Loads a given star system, if it exists. 
    /// </summary>
    /// <param name="starSystem"></param>
    /// <returns></returns>
    public bool LoadStarSystem(Vector2Int starSystem)
    {
        if (!StarSystems.ContainsKey(starSystem))
            return false;

        var newStarSystem = StarSystems[starSystem];

        var oldSystem = StarSystemViewModel;

        var newObject = new GameObject();
        newObject.name = newStarSystem.Name;
        newObject.transform.parent = transform; 
        var starviewmodel = newObject.AddComponent<StarSystemViewModel>();
        starviewmodel.LoadStarSystem(newStarSystem);
        StarSystemViewModel = starviewmodel;
        GameController.Game.Player?.SetLocation(newStarSystem.JumpPoint); 

        //destroy the old star system.
        if (oldSystem != null)
            Destroy(oldSystem.gameObject);
        return true; 

    }
}
