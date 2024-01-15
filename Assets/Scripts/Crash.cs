using UnityEngine;
using UnityEngine.SceneManagement;

public class Crash : MonoBehaviour
{
    [SerializeField] private float delay = 0.5f;
    [SerializeField] private ParticleSystem crashEffect;
    [SerializeField] private AudioClip crashSFX;

    private bool isCrashed = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground") && !isCrashed)
        {
            DisablePlayerControls();
            PlayCrashEffect();
            PlayCrashSound();
            Invoke("LoadCrash", delay);
            isCrashed = true;
        }
    }

    private void DisablePlayerControls()
    {
        FindObjectOfType<PlayerController>().DisableControls();
    }

    private void PlayCrashEffect()
    {
        crashEffect.Play();
    }

    private void PlayCrashSound()
    {
        GetComponent<AudioSource>().PlayOneShot(crashSFX);
    }

    private void LoadCrash()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
