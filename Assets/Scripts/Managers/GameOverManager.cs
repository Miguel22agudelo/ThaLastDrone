using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;//Se toma la clase de la vida del jugador;

    bool gameInPlay = true; //Booleano que determinará el estado de juego;

    Animator anim; //Animación del Game Over;

    
    

    void Awake()
    {
        anim = GetComponent<Animator>(); //Tomamos los componentes de la animación;
        
    }



    void Update()
    {
        if (playerHealth.currentHealth <= 0) //Cuando la salud actual esté en 0 o menos, la animación de Game Over se activa, como el cursor del mouse;
        {
          
            anim.SetTrigger("GameOver");
            Cursor.visible = true;
            

        }
    }

    void enableLeaderBoard()
    {
        if (playerHealth.currentHealth <= 0)
        {
           
        }
    }
    void EndGame()
    {
        if(playerHealth.currentHealth <= 0)
        {

            gameInPlay = false; //El estado de juego se falsea;
            
        }
    }
}


