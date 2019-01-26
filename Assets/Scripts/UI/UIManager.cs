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
    public List<GameObject> CurrentElements; 

    // Start is called before the first frame update
    void Start()
    {
        CurrentElements = new List<GameObject>(); 
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
        TearDown(); 

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
            Destroy(obj.gameObject); 
    }


    void LoadMainGame()
    {
        var speedControlPanelPrefab = CM.GetPrefab("SpeedControlPanel");

        var instance = Instantiate(speedControlPanelPrefab, Canvas.transform);
        instance.GetComponent<SpeedControlPanelScript>()?.SetFollowObject(GameController.Game.Player.gameObject);  
        CurrentElements.Add(instance);


        CameraScript.FollowObject = GameController.Game.Player.gameObject; 
    }
}
