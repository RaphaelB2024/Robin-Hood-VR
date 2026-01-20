using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeScript : MonoBehaviour
{
    public float inspeed = 5;
    public float outspeed = 5;
    public void FadeIn()
    {
        StartCoroutine(startFadeIn());
    }

    private void Start()
    {
        StartCoroutine(startFadeOut());
    }

    IEnumerator startFadeIn()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime / inspeed;
            yield return null;
        }
        canvasGroup.interactable = false;
        yield return null;
    }

    IEnumerator startFadeOut()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while (canvasGroup.alpha > 0)
        {
            Debug.Log("FadeOut");
            canvasGroup.alpha -= Time.deltaTime / outspeed;
            yield return null;
        }
        canvasGroup.interactable = false;
        yield return null;
    }
}