using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public ContentManager CM; 

    /// <summary>
    /// The main UI Canvas. 
    /// </summary>
    public Canvas Canvas;

    public CameraFollowScript CameraScript; 

    /// <summary>
    /// Current elements on screen. 
    /// </summary>
    public Dictionary<string, GameObject> CurrentElements; 

    // Start is called before the first frame update
    void Start()
    {
        CurrentElements = new Dictionary<string, GameObject>(); 
        CM = GameController.Game.ContentManager;
        Canvas = GetComponentInChildren<Canvas>();
        CameraScript = GameController.Game.CameraFollowScript; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Loads the given screen. 
    /// </summary>
    /// <param name="screen"></param>
    public void LoadScreen(string screen)
    {
        //TearDown(); 

        switch(screen)
        {
            case "MainGame":
                LoadMainGame(); 

                break; 

            default:
                Debug.LogError($"Unknown screen {screen} was attempted to be loaded");
                break; 
        }
    }


    void TearDown()
    {
        foreach (var obj in CurrentElements)
            Destroy(obj.Value.gameObject); 
    }


    void LoadMainGame()
    {
        var speedControlPanelPrefab = CM.GetPrefab("SpeedControlPanel");

        var instance = Instantiate(speedControlPanelPrefab, Canvas.transform);
        instance.GetComponent<SpeedControlPanelScript>()?.SetFollowObject(GameController.Game.Player.gameObject);  
        CurrentElements.Add("SpeedControlPanel", instance);


        CameraScript.FollowObject = GameController.Game.Player.gameObject; 
    }

    public GameObject AddObject(string name, string prefabName)
    {
        var prefab = CM.GetPrefab(prefabName);
        var instance = Instantiate(prefab, Canvas.transform);
        CurrentElements.Add(name, instance);
        return instance;
    }


    public GameObject AddObject(string name, string prefabName, Vector3 position)
    {
        var prefab = CM.GetPrefab(prefabName);
        var instance = Instantiate(prefab, position, transform.rotation, Canvas.transform);
        CurrentElements.Add(name, instance);
        return instance; 
    }

    public void RemoveObject(string name)
    {
        if (CurrentElements.ContainsKey(name))
        {
            Destroy(CurrentElements[name].gameObject);
            CurrentElements.Remove(name); 
        }
    }
}
