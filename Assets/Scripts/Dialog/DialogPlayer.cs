using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogPlayer : MonoBehaviour {

    [SerializeField]
    private Dialog m_Dialog = null;

    [SerializeField]
    private DialogBox m_DialogBox = null;

    [SerializeField]
    public bool playerInRange;

    private void PlayDialog() {
        m_DialogBox.DisplayDialog(m_Dialog, true);
    }

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.E) && playerInRange){
            if(m_DialogBox.gameObject.activeInHierarchy){
                            m_DialogBox.CloseDialog();
                        }else  {
                        PlayDialog();
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
            m_DialogBox.CloseDialog();
        }
    }
}
