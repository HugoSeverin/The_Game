using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour
{

    public string entrancePassword;

    void Start()
    {
        if(PlayerController.instance.scenePassword == entrancePassword)
        {
            PlayerController.instance.transform.position = transform.position; //transform.position c'est le point d'entrée de la salle
            Debug.Log("ENTRE");
        }
        else
        {
            Debug.LogWarning("wrong pwd");
        }
    }

}
