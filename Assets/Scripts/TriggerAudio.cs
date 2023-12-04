using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class TriggerAudio : MonoBehaviour
{
    public AudioClip audioClip;
    AudioSource audioS;

    private Animator ani;

    void Start()
    {
        ani = GetComponent<Animator>();
        audioS = GetComponent<AudioSource>();
        audioS.clip = audioClip;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(!(other.gameObject.tag == "RubyController")) return;

        audioS.Play();
        ani.SetTrigger("Interact");
        
    }
}
