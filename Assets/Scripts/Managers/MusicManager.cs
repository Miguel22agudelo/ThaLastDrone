using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour {

    
    public Slider musicVolume;//Slider del Volumen;
    public AudioSource myMusic;//Audio Source con la música;
	
	// Update is called once per frame
	void Update ()
    {
        myMusic.volume = musicVolume.value;	//Este método dará el valor del slider al volumen de la música;

	}

   
}
