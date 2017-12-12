using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 10.0F;//Velocidad de movimiento;
    public float rotationSpeed = 100.0F;//Velocidad de rotación;
    public float thrust;
    public Rigidbody rb;//Componente Rigidbody del jugador;
    public GameObject pauseMenu;//Menú de pausa;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;//La translación es el valor del input por la velocidad;
        float horizon = Input.GetAxis("Horizontal") * speed;//El movimiento horizontal es el valor del input por la velocidad;
        translation *= Time.deltaTime;
        horizon *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Translate(horizon, 0, 0);
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump") && estaEnElPiso == true)
        {
            rb.AddForce(0, 2, 0, ForceMode.Impulse);
        }          
        
    }

    public bool estaEnElPiso = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Piso"))
        {

            estaEnElPiso = true;
            Debug.Log("Tocando el piso " + estaEnElPiso);
        }
    }

    void OnCollisionExit(Collision cosito)
    {

        estaEnElPiso = false;
        print("No longer in contact with " + estaEnElPiso);
    }
}
