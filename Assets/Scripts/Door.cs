using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour{
    public Sprite porteOuverte;

    [SerializeField]
    public bool playerInRange;

    public Renderer rend;

    private void Start() {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    void Update() {
        if (playerInRange && Input.GetKeyDown(KeyCode.E)) {
            if (GetComponentInChildren<PlayerController>().playerGotKey()) {
                Debug.Log("you got the key");
                GetComponent<SpriteRenderer>().sprite = porteOuverte;
                rend.enabled = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            playerInRange = false;
        }
    }
}
