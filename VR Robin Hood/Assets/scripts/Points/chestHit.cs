using UnityEngine;

public class chestHit : MonoBehaviour
{
    pointManager pointManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ArrowTip"))
        {
            pointManager.points += 100;
            gameObject.SetActive(false);
        }
    }
}
