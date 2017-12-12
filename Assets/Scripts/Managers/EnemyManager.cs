using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;//Clase de Salud del jugador;
    public GameObject enemy;//Prefab de enemigo;
    public float spawnTime = 3f;//Tiempo que se tardan en salir los enemigos;
    public Transform spawnPoint; //Punto en que se instancian los enemigos;
    public Transform spawnPoint2;//Punto en que se instancian los enemigos;
    public Transform spawnPoint3;//Punto en que se instancian los enemigos;




    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime); 
    }

    private void Update()
    {   
     
    }


    void Spawn()
    {
        if (playerHealth.currentHealth <= 0f)//Si la salud actual es mayor a 0...
        { 
            return;
        }



        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation); //Se instancia enemigo en este punto;
        Instantiate(enemy, spawnPoint2.position, spawnPoint2.rotation);//Se instancia enemigo en este punto;
        Instantiate(enemy, spawnPoint3.position, spawnPoint3.rotation);//Se instancia enemigo en este punto;
    }
}


    
