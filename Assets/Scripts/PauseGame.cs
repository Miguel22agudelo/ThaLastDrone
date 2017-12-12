using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {

    bool active; //Booleano que indicará el estado de activación del canvas;
    public Canvas canvas;//Canvas específico del menú de pausa;
   

    public void BackToMainMenu()//Método que llama la escena de Main Menu;
    {
        SceneManager.LoadScene(0);//Vuelve al menú principal;
        Time.timeScale = 1;//Vuelve a correr el tiempo;
    }

    private void Start()
    {
        canvas = GetComponent<Canvas>();//Toma los componentes del Canvas de Pausa;
        canvas.enabled = false;//Desactiva de inicio el canvas de pausa;
        
    }

    private void Update()
    {
        if (Input.GetKeyDown("escape"))//El botón de esc será el activador de pausa;
        {
            active = !active;//Cuando se presiona, el booleano de activación cambia al valor contrario del que se encuentre en el momento;
            canvas.enabled = active;//El canvas se activa;
            

            if(Time.timeScale == 1) 
            {
                Time.timeScale = 0;//Si el tiempo está transcurriendo normalmente, se deteie;
                Cursor.visible = true;//El cursor se hace visible;

            }
            else
            {
                Time.timeScale = 1;//De estar ya en pausa, el tiempo se reanuda;
                Cursor.visible = false;//El cursor vuelve a desaparecer;
            }
            
        }   
    }



}
