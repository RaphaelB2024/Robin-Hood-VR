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


    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer == 0f || targets.Length == 0)
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
