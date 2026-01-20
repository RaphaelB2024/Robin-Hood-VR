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

    fadeScript fadeScript;
    private SpriteRenderer fadeScreenRenderer;

    [SerializeField] public bool targetMode;

    public AudioSource sceneDialogue;
    public float fadeSpeed = 1f;

    private bool next = false;
    int currentScene;
    

    private void Update()
    {
        if (!sceneDialogue.isPlaying && next)
        {
            Debug.Log("dialogue ended, swap scene");
            StartCoroutine(NextScene());
        }
        else if(!sceneDialogue.isPlaying && !next)
        {
            if(DialogueNumber < dialogues.Length -1) 
            {
                DialogueNumber++;
                Debug.Log(DialogueNumber);
            }

            activeDialogue = dialogues[DialogueNumber];
            sceneDialogue.clip = activeDialogue;
            sceneDialogue.Play();

            if(DialogueNumber == dialogues.Length -1)
            {
                next = true;
                Debug.Log("next is true");
            }
        }

        else if(targets.Length == 0 && targetMode && next)
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
        next = false;
        while(fadeScreenRenderer.color.a < 100)
        {
            fadeScript;
        }
        if(fadeScreenRenderer.color.a >= 100)
        {
            SceneManager.LoadScene(currentScene);
        }
        yield break;
    }
}
