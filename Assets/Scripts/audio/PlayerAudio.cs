using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    // Start is called before the first frame update
    public List<AudioClip> clips = new List<AudioClip>();
    private AudioSource audioData;
    private AudioClip audioClip;
    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7) {
            audioClip = clips[2];
            audioData.PlayOneShot(audioClip);
        }
        else if(collision.gameObject.layer != 7)
        {
            audioClip = clips[3];
            audioData.PlayOneShot(audioClip);
        }
    }
}
