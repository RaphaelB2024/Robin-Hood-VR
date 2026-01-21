using UnityEngine;

public class pointManager : MonoBehaviour
{
    public int points = 0;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

}
