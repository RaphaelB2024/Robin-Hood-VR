using UnityEngine;

public class chestHit : MonoBehaviour
{
    pointManager pointManager;
    private bool claimable = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ArrowTip") && claimable)
        {
            pointManager.points += 100;
            claimable = false;
            gameObject.SetActive(false);
        }
    }
}
