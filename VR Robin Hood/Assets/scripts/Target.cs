using UnityEngine;

public class Target : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ArrowTip"))
        {
            gameObject.SetActive(false);
        }
    }
}
