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
