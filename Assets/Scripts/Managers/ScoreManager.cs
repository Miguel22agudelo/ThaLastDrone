using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score; //Puntaje;
    public LeaderboardL1 leaderBoard; //Llamamos la clase Leaderboard;
    public InputField playerName; //Ingresaremos el nombre de la persona que puntúa;
    public Button acept; //El botón con el que listamos nuestro nombre y puntaje;
    

    Text text; //El texto del score en el canvas;

    void Awake ()
    {
        text = GetComponent <Text> (); //En el inicio se toman los componentes del texto y el marcador es cero;
        
        score = 0;
    }


    void Update ()
    {       
        text.text = "Score: " + score; //El marcador se va modificando según el puntaje de cada enemigo;
       
    }

    public void InitialEnterned()
    {
        Debug.Log(score);
        leaderBoard.OrganizarPuntajes(playerName.text,score);

    }
    

   

}
