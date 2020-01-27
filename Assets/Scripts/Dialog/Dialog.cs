using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Dialog : ScriptableObject {

    [SerializeField, TextArea]
    public string m_Text = string.Empty;

    [SerializeField]
    private Sprite m_SpeakerAvatar = null;

    public string GetText() {
        return m_Text;
    }

    public Sprite GetSpeakerAvatar() {
        return m_SpeakerAvatar;
    }

    // Start is called before the first frame update
    void Start() {


    }

    // Update is called once per frame
    void Update() {

    }
}
