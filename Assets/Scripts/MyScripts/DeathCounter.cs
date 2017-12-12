using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DeathCounter : MonoBehaviour {

    public Text textoMuertes;
    public static int muertes;

    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        
    }

    void Update()
    {
        text.text = "Kills: " + muertes;

    }
}
