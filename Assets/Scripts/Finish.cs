using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private ParticleSystem finishEffect;
    [SerializeField] private int maxScene = 2;
    [SerializeField] private float delay = 2f;

    private int currentScene;

    private void OnTriggerEnter2D(Collider2D other)
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;

        if (IsPlayerAndBelowMaxScene(other))
        {
            PlayFinishEffect();
            PlayAudio();
            StartCoroutine(LoadNextLevel());
        }
    }

    private bool IsPlayerAndBelowMaxScene(Collider2D other)
    {
        return other.gameObject.CompareTag("Player") && currentScene < maxScene;
    }

    private void PlayFinishEffect()
    {
        finishEffect.Play();
    }

    private void PlayAudio()
    {
        GetComponent<AudioSource>().Play();
    }

     IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(delay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }
}
