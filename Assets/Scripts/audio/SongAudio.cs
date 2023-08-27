using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongAudio : MonoBehaviour
{
   // Start is called before the first frame update
    [SerializeField] private AudioClip songs;
    private AudioSource audioData;
    private AudioClip audioClip;
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        
    }

    public void playGameSong()
    {
        audioClip = songs;

        audioData.PlayOneShot(audioClip);
    }

}
