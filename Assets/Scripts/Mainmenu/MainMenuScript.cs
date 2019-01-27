using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Attack"))
            NewGame();

        if (Input.GetButtonDown("Menu"))
            Quit(); 
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Space"); 
    }

    public void Quit()
    {
        Application.Quit(); 
    }

    
}
