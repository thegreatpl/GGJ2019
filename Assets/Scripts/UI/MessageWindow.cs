using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageWindow : MonoBehaviour
{
    public static MessageWindow Instance; 

    public GameObject MessageObject; 

    // Start is called before the first frame update
    void Start()
    {
        Instance = this; 
    }


    public void Init()
    {
        MessageObject = GameController.Game.ContentManager.GetPrefab("Message"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Show(string message)
    {
        Instance.ShowMessage(message); 
    }


    public void ShowMessage(string message)
    {
        var mess = Instantiate(MessageObject, transform);
        var messageScript = mess.GetComponent<MessageScript>();
        messageScript.Text.text = message; 
    }
}
