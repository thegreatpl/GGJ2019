using Assets.Scripts.Generation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceMananger : MonoBehaviour
{

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
            ValuePerInstance = 5f
        });
        AddResource(new ResourceDefinition()
        {
            Name = "Titanium",
            PlanetTypes = new List<string>() { "Planet", "Asteroid" },
            Rarity = 0.25f,
            ValuePerInstance = 7.5f
        });
        AddResource(new ResourceDefinition()
        {
            Name = "Adimantium",
            PlanetTypes = new List<string>() { "Planet", "Asteroid" },
            Rarity = 0.01f,
            ValuePerInstance = 50
        });
        AddResource(new ResourceDefinition()
        {
            Name = "Uranium",
            PlanetTypes = new List<string>() { "Planet", "Asteroid" },
            Rarity = 0.05f,
            ValuePerInstance = 10
        });
        AddResource(new ResourceDefinition()
        {
            Name = "Gold",
            PlanetTypes = new List<string>() { "Planet", "Asteroid" },
            Rarity = 0.80f,
            ValuePerInstance = 0.1f
        });
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
