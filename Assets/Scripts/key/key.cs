using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class key : MonoBehaviour {

    [SerializeField]
    public bool playerInRange;

    [SerializeField]
    private DialogBox m_DialogBox = null;

    [SerializeField]
    private Dialog m_Dialog = null;

    [SerializeField]
    public bool keyPresent = true;

    [SerializeField]
    private PlayerController player;

    public Renderer rend;

    void Start() {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    // Update is called once per frame
    void Update() {
        if (playerInRange && keyPresent) {
            PlayDialog();
            keyPresent = false;
            rend.enabled = false;
            gotKey();
        }
    }
    private void PlayDialog() {
        m_DialogBox.DisplayDialog(m_Dialog, false);
    }

    private void gotKey() {
        player.gotKey();
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
