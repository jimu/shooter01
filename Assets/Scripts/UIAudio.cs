using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// dedicated audio source for ui sfx
public class UIAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.uiAudioSource = GetComponent<AudioSource>();
    }

}
