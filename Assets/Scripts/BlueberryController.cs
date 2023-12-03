using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueberryController : MonoBehaviour
{
    public AudioClip collectedClip;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            controller.speed = 0.5f;
            Destroy(gameObject);
            
            controller.PlaySound(collectedClip);
        }

    }
}
