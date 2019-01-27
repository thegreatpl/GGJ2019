using Assets.Scripts.StarSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Galaxy : MonoBehaviour
{
    public StarSystemViewModel StarSystemViewModel;

    public StarsystemGenerator StarsystemGenerator;

    public AuctionHouseController AuctionHouseController; 

    public Dictionary<Vector2Int, StarSystem> StarSystems = new Dictionary<Vector2Int, StarSystem>(); 

    // Start is called before the first frame update
    void Start()
    {
       // StarsystemGenerator = GetComponent<StarsystemGenerator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Generate()
    {
        ShipControlScript.MaxArea = StarsystemGenerator.PlayingArea * 2; 
        yield return null;
        yield return StartCoroutine(StarsystemGenerator.ResourceMananger.LoadResources()); 
        yield return null;
        yield return StartCoroutine(AuctionHouseController.GenerateCompanies()); 

        yield return StartCoroutine(GenerateSystem(Vector2Int.zero));

    }

    /// <summary>
    /// Generates a new star system on request. 
    /// </summary>
    /// <param name="system"></param>
    /// <returns></returns>
    IEnumerator GenerateSystem(Vector2Int system)
    {
        GameController.Game.UIManager.ToggleLoadScreen(true); 
        yield return StartCoroutine(StarsystemGenerator.GenerateSystem(system));
        _loadsystem(system);
        GameController.Game.UIManager.ToggleLoadScreen(false); 
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

        _loadsystem(starSystem);
        return true; 
    }

    private void _loadsystem(Vector2Int starSystem)
    {  
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
    }
}
