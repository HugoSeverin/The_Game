using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour{
    public Sprite porteOuverte;

    [SerializeField]
    public bool playerInRange;
    [SerializeField]
    private DialogBox m_DialogBox = null;

    [SerializeField]
    private Dialog m_Dialog = null;

    public Renderer rend;

    public PlayerController player;

    private void Start() {
        player = FindObjectOfType<PlayerController>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    void Update() {
        if (playerInRange) {
            if (Input.GetKeyDown(KeyCode.E)){
                if (player.playerGotKey()) {
                    Destroy(gameObject);
                }
                else
                {
                    PlayDialog();
                }
            }

        }
    }
    private void PlayDialog()
    {
        m_DialogBox.DisplayDialog(m_Dialog, false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            playerInRange = false;
            m_DialogBox.CloseDialog();
        }
    }
}
