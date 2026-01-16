using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class sceneController : MonoBehaviour
{
    [SerializeField] public float timer;
    public GameObject[] targets;
    public SpriteRenderer fadeScreenRenderer;

    [SerializeField] public bool timeMode;
    [SerializeField] public bool targetMode;

    public AudioSource badToTheBone;

    private bool next = true;


    private void Update()
    {
        /*
        if (timeMode)
        {
            timer -= Time.deltaTime;
            if(timer <= 0f)
            {
                StartCoroutine(NextScene());
            }
        }*/

        if (!badToTheBone.isPlaying && next)
        {
            Debug.Log("no bad to the bone. So next scene");
            StartCoroutine(NextScene());
        }

        else if(targets.Length == 0 && targetMode)
        {
            Debug.Log("Target mode next scene");
            StartCoroutine(NextScene());
        }
    }

    private IEnumerator NextScene()
    {
        next = false;
        while(fadeScreenRenderer.color.a < 100)
        {
            Debug.Log("fadeScreenRenderer.colour.a < 100");
            Color temporary = fadeScreenRenderer.GetComponent<SpriteRenderer>().color;  
            temporary.a += Time.deltaTime;
            fadeScreenRenderer.color = temporary;
        }
        if(fadeScreenRenderer.color.a >= 100)
        {
            Debug.Log("SceneManager.LoadScene()");
            //   SceneManager.LoadScene();
        }

        return null;
    }
}
