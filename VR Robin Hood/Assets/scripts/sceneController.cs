using System.Runtime.InteropServices;
using UnityEngine;

public class sceneController : MonoBehaviour
{
    [SerializeField] public float timer;
    public GameObject[] targets;


    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer == 0f)
        {

        }
    }
}
