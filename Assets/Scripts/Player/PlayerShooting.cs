using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 20;//Daño por tiro;
    public float timeBetweenBullets = 0.15f;//Tiempo entre disparos;
    public float range = 100f;//Rango de disparo;


    float timer; //Temporizador para medir tiempo entre disparos;
    Ray shootRay = new Ray();//Nueva instancia de rayo;
    RaycastHit shootHit;//Golpe del rayo;
    int shootableMask;
    ParticleSystem gunParticles;//Partícula de arma;
    LineRenderer gunLine;//Dibujo de la línea que representa el rayo;
    AudioSource gunAudio;//Sonido de disparo;
    Light gunLight; //Luz en el disparo;
    float effectsDisplayTime = 0.2f; //Tiempo del efecto de disparo;
    public GameObject pauseMenu; //Menú de pausa;

    void Awake ()
    {
        shootableMask = LayerMask.GetMask ("Shootable");
        gunParticles = GetComponent<ParticleSystem> ();
        gunLine = GetComponent <LineRenderer> ();
        gunAudio = GetComponent<AudioSource> ();
        gunLight = GetComponent<Light> ();
    }


    void Update ()
    {
        timer += Time.deltaTime; //Al temporizador se le está sumando el tiempo real del juego;

		if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)//Si se oprime fire1 y el temporizador es mayor al necesario para poder disparar y el juego no está pausado...
        {
            Shoot ();//Se activa el método de disparo;
        }



        if(timer >= timeBetweenBullets * effectsDisplayTime)//Si el temporizador está más alto que el tiempo de disparo por el tiempo de efecto...
        {
            DisableEffects ();//Se activa el método de desactivación de efectos;
        }
    }

    public void Pause()
    {
        if (Input.GetButton("Cancel"))//Si se oprime esc...
        {
            pauseMenu.SetActive(true);//Se activa el menú de pausa;
        }
    }
    
            
    

    public void DisableEffects ()
    {
        gunLine.enabled = false; //Linea de disparo desactivada;
        gunLight.enabled = false; //Luz de disparo desactivada;
    }


    void Shoot ()
    {
        timer = 0f;//El temporizador vuelve a iniciar;

        gunAudio.Play ();//Suena el audio de disparo;

        gunLight.enabled = true;//La luz de disparo se activa;

        gunParticles.Stop ();//Las partículas de disparo se detienen;
        gunParticles.Play ();// E inician de inmediato;

        gunLine.enabled = true;//La línea de disparo se activa;
        gunLine.SetPosition (0, transform.position);//e establece  el punto de partida de la línea de disparo;

        shootRay.origin = transform.position;//El origen del rayo es la posición de la línea;
        shootRay.direction = transform.forward;//La dirección es hacia adelante;

        if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();
            if(enemyHealth != null)
            {
                enemyHealth.TakeDamage (damagePerShot, shootHit.point);
            }
            gunLine.SetPosition (1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
        }
    }
}
