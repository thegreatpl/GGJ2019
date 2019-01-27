using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyPanelScript : MonoBehaviour
{

    public Player Player;

    public Text Text; 
    // Start is called before the first frame update
    void Start()
    {
        Text = GetComponentInChildren<Text>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
            Text.text = $"${Player.Money}"; 
    }
}
