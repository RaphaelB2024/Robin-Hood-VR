using UnityEngine;

public class bagHit : MonoBehaviour
{
    pointManager pointManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("ArrowTip"))
        {
            pointManager.points += 50;
            gameObject.SetActive(false);
        }
    }
}
