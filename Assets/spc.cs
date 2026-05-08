using System.Collections;
using UnityEngine;

public class CrossfadeZone : MonoBehaviour
{
    public AudioSource mainAudioSource;
    public AudioClip outdoorMusic;
    public AudioClip indoorMusic;

    private Coroutine currentSwitchCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (currentSwitchCoroutine != null)
                StopCoroutine(currentSwitchCoroutine);
            currentSwitchCoroutine = StartCoroutine(SwitchMusic(indoorMusic));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (currentSwitchCoroutine != null)
                StopCoroutine(currentSwitchCoroutine);
            currentSwitchCoroutine = StartCoroutine(SwitchMusic(outdoorMusic));
        }
    }

    private IEnumerator SwitchMusic(AudioClip newClip)
    {
        mainAudioSource.clip = newClip;
        mainAudioSource.Play();
        currentSwitchCoroutine = null;
        yield break;

    }
}