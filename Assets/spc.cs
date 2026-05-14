using System.Collections;
using UnityEngine;

public class MusicCrossfadeZone : MonoBehaviour
{
    public AudioSource outdoorSource; 
    public AudioSource indoorSource; 
    public float fadeDuration = 5f;
    private Coroutine activeFade = null;
    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (activeFade != null) StopCoroutine(activeFade);
            activeFade = StartCoroutine(CrossfadeToIndoor());
        }
        enabled = false;
    }


    private IEnumerator CrossfadeToIndoor()
    {
        float elapsed = 0f;

        if (!indoorSource.isPlaying)
        {
            indoorSource.volume = 0f;
            indoorSource.Play();
        }

        while (elapsed < fadeDuration)
        {
            float t = elapsed / fadeDuration;
            outdoorSource.volume = Mathf.Lerp(0.1f, 0f, t);
            indoorSource.volume = Mathf.Lerp(0f, 0.1f, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        outdoorSource.volume = 0f;
        indoorSource.volume = 0.1f;

        if (outdoorSource.isPlaying) outdoorSource.Stop();

        activeFade = null;
    }

    private IEnumerator CrossfadeToOutdoor()
    {
        float elapsed = 0f;

        if (!outdoorSource.isPlaying)
        {
            outdoorSource.volume = 0f;
            outdoorSource.Play();
        }

        while (elapsed < fadeDuration)
        {
            float t = elapsed / fadeDuration;
            indoorSource.volume = Mathf.Lerp(0.1f, 0f, t);
            outdoorSource.volume = Mathf.Lerp(0f, 0.1f, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        indoorSource.volume = 0f;
        outdoorSource.volume = 0.1f;

        if (indoorSource.isPlaying) indoorSource.Stop();

        activeFade = null;
    }
}