using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KillsManager: MonoBehaviour
{
    public static int kills;

    public Slider subirSangre;
    public Text muertes;    
    
    void Awake ()
    {
        subirSangre = GetComponent <Slider> ();
        muertes = GetComponent<Text>();     
       
    }

    void Update ()
    {
        Debug.Log(kills);
       
        subirSangre.value = kills;   
        
    }
}
