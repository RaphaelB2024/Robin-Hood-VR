using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class sceneController : MonoBehaviour
{
    public GameObject[] targets;

    public AudioClip[] dialogues;
    private AudioClip activeDialogue;
    private int DialogueNumber = -1;

    public fadeScript fadeObject;

    [SerializeField] public bool targetMode;
    public int targetsShot = 0;

    public AudioSource sceneDialogue;
    public float fadeSpeed = 1f;

    private bool nextScene = false;
    int currentScene;
    

    private void Update()
    {
        if (!sceneDialogue.isPlaying && nextScene && !targetMode)
        {
            Debug.Log("dialogue ended, swap scene");
            StartCoroutine(NextScene());
        }
        else if(!sceneDialogue.isPlaying && !nextScene)
        {
            if(DialogueNumber < dialogues.Length -1) 
            {
                DialogueNumber++;
            }

            activeDialogue = dialogues[DialogueNumber];
            sceneDialogue.clip = activeDialogue;
            sceneDialogue.Play();

            if(DialogueNumber == dialogues.Length -1)
            {
                nextScene = true;
                Debug.Log("next is true");
            }
        }

        else if(targetsShot == targets.Length && targetMode && nextScene)
        {
            Debug.Log("Target mode next scene");
            StartCoroutine(NextScene());
        }
    }

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex + 1;
    }


    private IEnumerator NextScene()
    {
        nextScene = false;
        Debug.Log("start fade in");
        fadeObject.FadeIn();

        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(currentScene);
        yield break;
    }
}
