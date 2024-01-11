using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem snowTrailEffect;
    [SerializeField] AudioClip sleddingSFX;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            snowTrailEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(sleddingSFX);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            snowTrailEffect.Stop();
            GetComponent<AudioSource>().Stop();
        }
    }
}
