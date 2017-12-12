using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f; //Tiempo entre ataques;
    public int attackDamage = 10;//Valor de daño al jugador; Varía según el enemigo;


    
    GameObject player; //Aquí va el jugador;
    PlayerHealth playerHealth;//Su salud;
    EnemyHealth enemyHealth;//La salud del enemigo;
    bool playerInRange;//Determina si el jugador puede ser atacado;
    float timer; //Determinará si se puede atacar o no según el tiempo entre ataques;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");//Encuentra al drone corresponiente al jugador que está taggeado como "Player";
        playerHealth = player.GetComponent <PlayerHealth> (); //Toma componentes de salud de jugador;
        enemyHealth = GetComponent<EnemyHealth>();//De enemigo;
       
    }


    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject == player) //Si el collider del jugador está activado, el jugador está disponible para ser atacado;
        {
            playerInRange = true;
        }
    }


    void OnTriggerExit (Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = false;
        }
    }


    void Update ()
    {
        timer += Time.deltaTime; //Se activa el timer;

        if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0) //Si el tiempo es mayor que el que se requiere para atacar y el jugador ha sido tocado y la salud del enemigo es mayor a cero...
        {
            Attack ();//Se activa el método de ataque;
        }

        if(playerHealth.currentHealth <= 0)
        {
           
        }
    }


    void Attack ()
    {
        timer = 0f; //El timer vuelve a iniciar;

        if(playerHealth.currentHealth > 0)//Si la salud del jugador es mayor a 0...
        {
            playerHealth.TakeDamage (attackDamage);//Se realiza el daño correspondiente al valor de ataque;
        }
    }
}
