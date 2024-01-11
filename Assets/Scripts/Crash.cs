using UnityEngine;
using UnityEngine.SceneManagement;

public class Crash : MonoBehaviour
{
    [SerializeField] float delay = 1.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("LoadCrash", delay);
        }
    }

    void LoadCrash()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
