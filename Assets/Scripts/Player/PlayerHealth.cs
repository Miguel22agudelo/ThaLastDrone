using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public static int  startingHealth = 100; //Vida Inicial
    public int currentHealth;  //Vida actualizada   
    public Slider healthSlider; //Slider de la vida
    public Image damageImage; //Imagen que aparece cuando es golpeada la nave 
    public AudioClip deathClip; //Sonido de muerte
    public float flashSpeed = 5f; //Velocidad de aparición de imagen de daño
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);//Valores de color de la imagen de daño
    public Canvas leaderBoard;


    ParticleSystem deathParticle; 
    AudioSource playerAudio;
    PlayerController playerController;
    PlayerShooting playerShooting;
    MouseRotate mouseRotate;
    bool isDead;
    bool damaged;



    void Awake ()
    {
        leaderBoard.enabled = false;
        deathParticle = GetComponent<ParticleSystem>();//Se toman los componentes de las variables ya nombradas
        playerAudio = GetComponent <AudioSource> ();
        playerController = GetComponent <PlayerController> ();
        playerShooting = GetComponentInChildren <PlayerShooting> ();
        mouseRotate = GetComponent<MouseRotate>();
        currentHealth = startingHealth;
    }


    void Update () //En este método se avisa que si hay daño, aparecerá una imágen de color y de no ser así, transcurrirá normalmente.
    {
        if(damaged)
        {
            damageImage.color = flashColour;  
        }
        else
        {
            damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }


    public void TakeDamage (int amount)//En este método se activará el daño. 
    {
        damaged = true;

        currentHealth -= amount; //El daño corresponderá al valor que quita cada objeto.

        healthSlider.value = currentHealth; //El slider mostrará el valor actual de vida.

        playerAudio.Play (); //Se reproduce el sonido de daño.

        if(currentHealth <= 0 && !isDead) //Si la vida actual es menor o igual a cero y no está verdadero el estado de muerte, se activa la función de muerte.
        {
            Death ();
           
        }
    }

    

    void Death ()
    {

        isDead = true; //Booleano para anunciar estado de muerte verdadero.
        leaderBoard.enabled = true;
        playerAudio.clip = deathClip; //Se reproduce el sonido de muerte
        playerAudio.Play (); //También el de daño.

        playerController.enabled = false; //Se desactiva la Clase encargada del control, disparo y rotación.
        playerShooting.enabled = false;
        mouseRotate.enabled = false;
        deathParticle.transform.position = gameObject.transform.position; //Se activa el sistema de partículas de muerte.
        deathParticle.Play();

    }

   


   
}
