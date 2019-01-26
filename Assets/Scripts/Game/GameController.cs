using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Game; 

    public Galaxy Galaxy;

    public ContentManager ContentManager; 

    public ContentLoader ContentLoader;

    /// <summary>
    /// The current player. 
    /// </summary>
    public Player Player; 

    // Start is called before the first frame update
    void Start()
    {
        Game = this; 
        ContentLoader = gameObject.AddComponent<ContentLoader>();
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

        yield return null;
        var player = ContentManager.Inst.GetPrefab("Player");
        var playerObj = Instantiate(player);
        yield return null;
        Player = playerObj.GetComponent<Player>(); 

        yield return null; 

        Galaxy = gameObject.AddComponent<Galaxy>();

        yield return StartCoroutine(Galaxy.Generate()); 

    }
}
