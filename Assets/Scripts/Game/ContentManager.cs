using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 

public class ContentManager : MonoBehaviour
{
    public static ContentManager Inst;

    /// <summary>
    /// List of prefabs for this object. 
    /// </summary>
    public List<Prefab> Prefabs;


    public Dictionary<string, Sprite> Spritemanager; 


    // Start is called before the first frame update
    void Start()
    {
        Inst = this;
        Spritemanager = new Dictionary<string, Sprite>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Loads all sprites into memory. 
    /// </summary>
    public void LoadSprites()
    {
        Spritemanager = new Dictionary<string, Sprite>();

        var sprites = Resources.LoadAll<Sprite>("Sprites"); 
        foreach (var s in sprites)
        {
            Spritemanager.Add(s.name, s); 
        }
    }

    public Sprite GetSprite(string name)
    {
        if (!Spritemanager.ContainsKey(name))
        {
            Debug.LogError($"Sprite {name} not found");
            return null;
        }

        return Spritemanager[name]; 
    }

    /// <summary>
    /// Gets the prefab with the given name from the prefab manager. 
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public GameObject GetPrefab(string name)
    {
        return Prefabs.FirstOrDefault(x => x.Name == name)?.Object; 
    }
}


[Serializable]
public class Prefab
{
    public string Name;

    public GameObject Object; 
}
