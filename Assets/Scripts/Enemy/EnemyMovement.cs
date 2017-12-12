using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player;//Componente Trasnform del jugador;
    PlayerHealth playerHealth;//Salud del jugador;
    EnemyHealth enemyHealth;//Salud del enemigo;
    UnityEngine.AI.NavMeshAgent nav;//Navmesh del prefab del enemigo;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform; //Se toman los componentes de las variables ya mencionadas;
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
    }


    void Update ()
    {
        if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0) //Si la salud del enemigo y el jugador son mayor a 0...
        {
            nav.SetDestination (player.position); //El agente enemigo se dirige al lugar en que se ubica el jugador;
        }
        else
        {
            nav.enabled = false; //De lo contrario, se desactiva el agente del enemigo;
        }
    }
}
