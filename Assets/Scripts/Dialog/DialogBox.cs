﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour {

    [SerializeField]
    private Image m_CharacterAvatar = null;

    [SerializeField]
    public Text m_Text = null;

    public void DisplayDialog(Dialog _Dialog, bool avatar) {
        if (avatar) {
            m_CharacterAvatar.sprite = _Dialog.GetSpeakerAvatar();
        } else {
            m_CharacterAvatar.sprite = null;
        }
        
        m_Text.text = _Dialog.GetText();
        gameObject.SetActive(true);
    }

    public void CloseDialog() {
        gameObject.SetActive(false);
    }

    private void Awake() {
        CloseDialog();
    }
    // Update is called once per frame
    void Update() {

    }
}
