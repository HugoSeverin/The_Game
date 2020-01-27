using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour{
    public Sprite porteOuverte;

    [SerializeField]
    public bool playerInRange;

    public Renderer rend;

    public PlayerController player;

    private void Start() {
        player = FindObjectOfType<PlayerController>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    void Update() {
        if (playerInRange && Input.GetKeyDown(KeyCode.E)) {
            if (player.playerGotKey()) {
                Destroy(gameObject);
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
