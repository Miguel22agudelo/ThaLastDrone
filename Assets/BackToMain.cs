﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BackToMain : MonoBehaviour {

	public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;

    }
}
