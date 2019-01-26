using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    /// <summary>
    /// Instance of the game. Accessible everywhere. 
    /// </summary>
    public static GameController Game; 

    public Galaxy Galaxy;

    public ContentManager ContentManager; 

    public ContentLoader ContentLoader;

    /// <summary>
    /// Reference to the camera script for the game. 
    /// </summary>
    public CameraFollowScript CameraFollowScript;  

    /// <summary>
    /// Ui manager. Controlls the UI. 
    /// </summary>
    public UIManager UIManager; 

    /// <summary>
    /// The current player. 
    /// </summary>
    public Player Player;



    public bool Pause = false; 

    // Start is called before the first frame update
    void Start()
    {
        Game = this; 
        ContentLoader = gameObject.AddComponent<ContentLoader>();
        UIManager = gameObject.AddComponent<UIManager>(); 
        StartCoroutine(LoadNewGame()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator LoadNewGame()
    {
        if (Galaxy != null)
            Destroy(Galaxy.gameObject); 
        yield return null;
        ContentManager = gameObject.GetComponent<ContentManager>();
        ContentManager.LoadSprites();
        UIManager.CM = ContentManager;
        UIManager.LoadScreen("Loading"); 
        yield return null;
        var player = ContentManager.Inst.GetPrefab("Player");
        var playerObj = Instantiate(player);
        yield return null;
        Player = playerObj.GetComponent<Player>(); 

        yield return null;
        var galaxyObj = Instantiate(ContentManager.GetPrefab("Galaxy"));
        galaxyObj.name = "Galaxy"; 
        Galaxy = galaxyObj.GetComponent<Galaxy>();

        yield return StartCoroutine(Galaxy.Generate());

        UIManager.LoadScreen("MainGame"); 
    }
}
