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


    private void Update()
    {

        if (timeMode)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                StartCoroutine(NextScene());
            }
        }

        else if(targets.Length == 0 && targetMode)
        {
            StartCoroutine(NextScene());
        }
    }

    private IEnumerator NextScene()
    {
        while(fadeScreenRenderer.color.a < 100)
        {
            Color temporary = fadeScreenRenderer.GetComponent<SpriteRenderer>().color;
            temporary.a = 1 * Time.deltaTime;
        }
        if(fadeScreenRenderer.color.a >= 100)
        {
         //   SceneManager.LoadScene();
        }

        return null;
    }
}
