using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FollowEnemy : MonoBehaviour
{
    
    public Transform player;
    public float speed;

    private bool alive = true;

    private Animator ani;

    public AudioClip deathSound;



    void Start()
    {
        ani = GetComponent<Animator>();
    }

    void Update(){
        if(alive){
            transform.position =  Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    public void Kill(){
        alive = false;

        // to have the audio play after the slime has been destoryed we need to create an seprate object
        GameObject soundP = new GameObject();                               // create it
        soundP.transform.position = transform.position;                     // set its position to the same as the slime
        AudioSource audioS = soundP.AddComponent<AudioSource>();            // add the audiosource component
        audioS.clip = deathSound;                                           // set the audio the variable
        audioS.Play();                                                      // play
        Destroy(soundP,2f);                                                 // and destroy as its no longer needed after 2 seconds

        ani.SetTrigger("Death");
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController >();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

    public void SelfKill(){
        Destroy(gameObject);
    }
}
