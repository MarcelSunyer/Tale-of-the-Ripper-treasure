using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource BackgroundSFX;
    [SerializeField] AudioSource TriggerSFX;

    [Header("---------- Audio Clip ----------")]
    public AudioClip Sailing;
    public AudioClip KrakenGrowl;
    public AudioClip KrakenDeath;
    public AudioClip Birds;

    [Header("---------- Configuración de Loops ----------")]
    [SerializeField] private bool loopBirds = true;
    [SerializeField] private float birdsInterval = 10f;
    [SerializeField] private float birdsStartDelay = 5f;

    [SerializeField] private bool loopKrakenGrowl = true;
    [SerializeField] private float krakenGrowlInterval = 30f;
    [SerializeField] private float krakenGrowlStartDelay = 45f;

    private Coroutine birdsRoutine;
    private Coroutine krakenGrowlRoutine;

    private void Start()
    {
        BackgroundSFX.clip = Sailing;
        BackgroundSFX.Play();

        if (loopBirds && Birds != null)
            birdsRoutine = StartCoroutine(PlaySFXLoop(Birds, birdsInterval, birdsStartDelay));

        if (loopKrakenGrowl && KrakenGrowl != null)
            krakenGrowlRoutine = StartCoroutine(PlaySFXLoop(KrakenGrowl, krakenGrowlInterval, krakenGrowlStartDelay));
    }

    public void PlaySFX(AudioClip clip)
    {
        TriggerSFX.PlayOneShot(clip);
    }

    private IEnumerator PlaySFXLoop(AudioClip clip, float interval, float startDelay)
    {
        yield return new WaitForSeconds(startDelay);

        while (true)
        {
            PlaySFX(clip);
            yield return new WaitForSeconds(interval);
        }
    }
}
