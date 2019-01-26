using Assets.Scripts.StarSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsystemGenerator : MonoBehaviour
{
    readonly char[] Characters = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM".ToCharArray(); 

    public ResourceMananger ResourceMananger;


    public List<string> Atmospheres = new List<string>()
    {
        "None",
        "Oxygen",
        "Hydrogen",
        "Helium",
        "Methane"
    }; 

    public Galaxy Galaxy;

    public int MinObjects = 10;

    public int MaxObjects = 100;

    public int PlayingArea = 1000; 

    // Start is called before the first frame update
    void Start()
    {
        ResourceMananger = GetComponent<ResourceMananger>();
       // Galaxy = GetComponent<Galaxy>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator GenerateSystem(Vector2Int location)
    {
        var jumpPoint = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100));
        string name = ""; 
        for(int idx = 0; idx < 6; idx++)
        {
            name += Characters.RandomElement();  
        }
        var Starsystem = new StarSystem()
        {
            JumpPoint = jumpPoint,
            Location = location,
            Name = name,
            Objects = new List<SurveyObject>() 
        };

        yield return null;
        var objects = Random.Range(MinObjects, MaxObjects); 
        for(int idx = 0; idx < objects; idx++)
        {
            var obj = GenerateObject(Starsystem);
            obj.StarSystem = Starsystem.Name; 
            Starsystem.Objects.Add(obj); 
            yield return null; 
        }

        Galaxy.StarSystems.Add(location, Starsystem); 
    }


    SurveyObject GenerateObject(StarSystem starSystem)
    {
        var location = new Vector3();
        do
        {
            location.x = Random.Range(-PlayingArea, PlayingArea);
            location.y = Random.Range(-PlayingArea, PlayingArea); 
        } while (isTooClose(30, location, starSystem.Objects)); 


        var obj = new SurveyObject()
        {
            StarSystem = starSystem.Name,
            Position = location, 
            Name = $"{starSystem.Name} {(starSystem.Objects.Count + 1).ToRoman()}", 
            Atmosphere = Atmospheres.RandomElement(),
            Image = "Base3",
            Color = new Color32(165, 42, 42, 255),
            SurveyDifficulty = Random.Range(0.5f, 1.5f),
            Size = Random.Range(1, 5), Type = "Planet",
            Resources = new List<Resource>(), 
            SurveyProgress = 0f
        };

        return obj; 
    }

    bool isTooClose(float minDist, Vector3 current, List<SurveyObject> others)
    {
        foreach(var o in others)
        {
            if (Vector3.Distance(current, o.Position) < minDist)
                return true;
        }
        return false; 
    }

}
