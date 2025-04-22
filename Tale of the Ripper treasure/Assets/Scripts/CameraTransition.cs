using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    [Header("Configuración de Cámaras")]
    public Camera playerCamera;    // Cámara del jugador
    public Camera shipCamera;      // Cámara del barco
    public KeyCode transitionKey = KeyCode.Space;

    [Header("Efecto de Fundido")]
    public float fadeDuration = 0.1f;
    public CanvasGroup fadeCanvas; // Añadir un CanvasGroup para el efecto de fade

    private bool isTransitioning = false;

    void Start()
    {
        // Configuración inicial explícita
        playerCamera.enabled = true;
        shipCamera.enabled = false;

        // Inicializar fade (si existe)
        if (fadeCanvas != null)
            fadeCanvas.alpha = 0;
    }

    public void TransitionCameras()
    {
        if (!isTransitioning)
            StartCoroutine(TransitionEffect());
    }

    IEnumerator TransitionEffect()
    {
        isTransitioning = true;

        // 1. Fade a negro
        if (fadeCanvas != null)
            yield return StartCoroutine(FadeScreen(0, 1));

        // 2. Cambiar cámaras
        playerCamera.enabled = !playerCamera.enabled;
        shipCamera.enabled = !shipCamera.enabled;

        isTransitioning = false;
    }

    IEnumerator FadeScreen(float startAlpha, float endAlpha)
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            fadeCanvas.alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        fadeCanvas.alpha = endAlpha; // Asegurar valor final
    }
}

