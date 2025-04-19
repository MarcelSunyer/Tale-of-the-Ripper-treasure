using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    [Header("Configuración de Cámaras")]
    public Camera camera1;
    public Camera camera2;
    public KeyCode transitionKey = KeyCode.Space;

    [Header("Efecto de Fundido")]
    public float fadeDuration = 0.1f;

    private bool usingCamera1 = true;
    private bool isTransitioning = false;

    void Start()
    {
        // Configuración inicial
        camera1.enabled = true;
        camera2.enabled = false;
    }

    public void TransitionCameras()
    {
        
            StartCoroutine(TransitionEffect());
        
    }

    IEnumerator TransitionEffect()
    {
        isTransitioning = true;

        // Fade a negro
        yield return StartCoroutine(FadeScreen(0, 1));

        // Cambiar cámara
        if (usingCamera1)
        {
            camera1.enabled = false;
            camera2.enabled = true;
        }
        else
        {
            camera2.enabled = false;
            camera1.enabled = true;
        }

        usingCamera1 = !usingCamera1;

        // Fade a transparente
        yield return StartCoroutine(FadeScreen(1, 0));

        isTransitioning = false;
    }

    IEnumerator FadeScreen(float startAlpha, float endAlpha)
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

    }
}
