using Assets.Scripts.Generation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceMananger : MonoBehaviour
{
    /// <summary>
    /// How much to multiply the cost of the resource by. 
    /// </summary>
    public float DifficultyMultiplier = 10; 

    public Dictionary<string, ResourceDefinition> ResourceDefinitions = new Dictionary<string, ResourceDefinition>(); 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator LoadResources()
    {
        ResourceDefinitions = new Dictionary<string, ResourceDefinition>();
        yield return null;

        AddResource(new ResourceDefinition()
        {
            Name = "Iron Ore",
            PlanetTypes = new List<string>() { "Planet", "Asteroid" },
            Rarity = 0.75f,
            ValuePerInstance = 0.5f
        });
        AddResource(new ResourceDefinition()
        {
            Name = "Titanium",
            PlanetTypes = new List<string>() { "Planet", "Asteroid" },
            Rarity = 0.25f,
            ValuePerInstance = 0.75f
        });
        AddResource(new ResourceDefinition()
        {
            Name = "Adimantium",
            PlanetTypes = new List<string>() { "Planet", "Asteroid" },
            Rarity = 0.01f,
            ValuePerInstance = 5
        });
        AddResource(new ResourceDefinition()
        {
            Name = "Uranium",
            PlanetTypes = new List<string>() { "Planet", "Asteroid" },
            Rarity = 0.05f,
            ValuePerInstance = 1
        });
        AddResource(new ResourceDefinition()
        {
            Name = "Gold",
            PlanetTypes = new List<string>() { "Planet", "Asteroid" },
            Rarity = 0.80f,
            ValuePerInstance = 0.01f
        });


        foreach (var rd in ResourceDefinitions)
            rd.Value.ValuePerInstance *= DifficultyMultiplier; 
    }
    void AddResource(ResourceDefinition rd)
    {
        ResourceDefinitions.Add(rd.Name, rd); 
    }

    /// <summary>
    /// Gets the base price for a resource. 
    /// </summary>
    /// <param name="resource"></param>
    /// <returns></returns>
    public float GetBasePriceForResource(string resource)
    {
        if (ResourceDefinitions.ContainsKey(resource))
        {
            return ResourceDefinitions[resource].ValuePerInstance; 
        }
        return 0; 
    }
}
