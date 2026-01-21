using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeScript : MonoBehaviour
{
    public float inspeed = 5;
    public float outspeed = 5;

    public SpriteRenderer fadeRenderer;
    public void FadeIn()
    {
        StartCoroutine(startFadeIn());
    }
    private void Awake()
    {
        fadeRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        StartCoroutine(startFadeOut());
    }

    IEnumerator startFadeIn()
    {
        float alphaValue = fadeRenderer.color.a;
        Color temporaryColour = fadeRenderer.color;

        while (fadeRenderer.color.a < 100)
        {
            alphaValue += inspeed;
            temporaryColour.a = alphaValue;
            fadeRenderer.color = temporaryColour;

            yield return new WaitForEndOfFrame();

        }
        yield break;
    }

    IEnumerator startFadeOut()
    {
        float alphaValue = fadeRenderer.color.a;
        Color temporaryColour = fadeRenderer.color;

        while (fadeRenderer.color.a > 0)
        {
            alphaValue -= outspeed;
            temporaryColour.a = alphaValue;
            fadeRenderer.color = temporaryColour;

            yield return new WaitForEndOfFrame();

        }
        yield break;
    }
}