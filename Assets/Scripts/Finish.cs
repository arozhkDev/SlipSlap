using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] ParticleSystem finishEffect;
    [SerializeField] int maxScene = 2;
    [SerializeField] float delay = 2f;
    int currentScene;


    void OnTriggerEnter2D(Collider2D other)
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;

        if (other.gameObject.CompareTag("Player") && currentScene < maxScene)
        {
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("LoadFinish", delay);
        }
    }

    void LoadFinish(){
        SceneManager.LoadScene(currentScene + 1);
    }
}
