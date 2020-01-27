using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    public bool inventory; // if true -> l'objet peut être ajouté

    public void DoInteraction()
    {
        gameObject.SetActive(false);
    }
}
