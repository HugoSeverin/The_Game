﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public string SceneName;
    [SerializeField]
    private string newScenePassword;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerController.instance.scenePassword = newScenePassword;
            //SceneManager.LoadScene(SceneName);
            FindObjectOfType<ScreenFader>().FadeTo(SceneName);
        }
    }

}
