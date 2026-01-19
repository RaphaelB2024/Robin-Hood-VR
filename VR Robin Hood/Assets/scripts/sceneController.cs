using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class sceneController : MonoBehaviour
{
    public GameObject[] targets;

    public GameObject fadeScreen;
    private SpriteRenderer fadeScreenRenderer;

    [SerializeField] public bool targetMode;

    public AudioSource sceneDialogue;
    float fadeSpeed = 1f;

    private bool next = true;
    int currentScene;
    

    private void Update()
    {

        if (!sceneDialogue.isPlaying && next)
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

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex + 1;
        fadeScreenRenderer = fadeScreen.GetComponent<SpriteRenderer>();
    }

    private IEnumerator NextScene()
    {
        next = false;
        while(fadeScreenRenderer.color.a < 100)
        {
            Color temporary = fadeScreenRenderer.GetComponent<SpriteRenderer>().color;
            temporary.a += Time.deltaTime * fadeSpeed;
            fadeScreenRenderer.color = temporary;
            Debug.Log("screen alpha is:" + fadeScreenRenderer.color);
        }
        if(fadeScreenRenderer.color.a >= 100)
        {
            Debug.Log("SceneManager.LoadScene()");
            SceneManager.LoadScene(currentScene);
        }
        yield break;
    }
}
