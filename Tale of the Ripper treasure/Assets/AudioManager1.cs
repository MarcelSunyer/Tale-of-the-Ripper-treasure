using System.Collections;
using UnityEngine;

public class AudioManager1 : MonoBehaviour
{
    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource WavesSFX;
    [SerializeField] AudioSource BirdsSFX;

    [Header("---------- Audio Clip ----------")]
    public AudioClip Waves;
    public AudioClip Birds;

    [Header("---------- Configuración de Loops ----------")]
    [SerializeField] private bool loopBirds = true;
    [SerializeField] private float birdsInterval = 10f;
    [SerializeField] private float birdsStartDelay = 5f;

    private Coroutine birdsRoutine;

    private void Start1()
    {
        WavesSFX.clip = Waves;
        WavesSFX.Play();

        if (loopBirds && Birds != null)
            birdsRoutine = StartCoroutine(PlaySFXLoop(Birds, birdsInterval, birdsStartDelay));

    }

    public void PlaySFX(AudioClip clip)
    {
        BirdsSFX.PlayOneShot(clip);
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
