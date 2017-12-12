using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    public GameObject pickupEffect;

	void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    void Pickup(Collider Player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        Debug.Log("Picked up");

        PlayerHealth playerHealth = Player.GetComponent<PlayerHealth>();
        if(playerHealth.currentHealth < 100)
        {
            if (playerHealth.currentHealth <= 80)
            {
                playerHealth.currentHealth += 10;
            }
            else
            if (playerHealth.currentHealth <= 60)
            {
                playerHealth.currentHealth += 20;
            }
            else
                if(playerHealth.currentHealth<= 40)
            {
                playerHealth.currentHealth += 40;
            }
            
        }

        Destroy(gameObject);
    }

}
