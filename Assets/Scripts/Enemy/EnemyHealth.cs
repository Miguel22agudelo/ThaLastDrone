using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100; //Vida inicial;
    public int currentHealth; //Vida actual;
    public float sinkSpeed = 2.5f; //Velocidad de desaparición;
    public int scoreValue = 10;//Valor en el puntaje;
    public AudioClip deathClip;//Sonido de muerte;
    
    public static int muertes;
    
  

    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;



    void Awake()
    {

        enemyAudio = GetComponent<AudioSource>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        currentHealth = startingHealth;
       

    }


    void Update()
    {
        if (isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
      
    }


    public void TakeDamage(int amount, Vector3 hitPoint) //En este método se activará el daño del enemigo al jugador. Argumentos: cuánto quita el enemigo y lugar del golpe;
    {
        if (isDead) //Booleano que determina si el enemigo está muerto;
            return;

        enemyAudio.Play(); //Se reproduce audio de destrucción de enemigo;

        currentHealth -= amount; //A la salud se le resta lo que quite el arma del jugador;

        hitParticles.transform.position = hitPoint; //Se activa la animación de destrucción;
        hitParticles.Play(); 

        if (currentHealth <= 0) //Se activa el método muerte cuando la vida sea menor o igual a cero;
        {
            Death();
           
            
        }
    }


    void Death()
    {
        isDead = true;


      
        capsuleCollider.isTrigger = true;
          
        enemyAudio.clip = deathClip;
        enemyAudio.Play();
        KillsManager.kills= muertes++;
        Destroy(gameObject, 1);
        ScoreManager.score += scoreValue;
        

                             
    }

   

    public void StartSinking()
    {
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;


    }

    
}
