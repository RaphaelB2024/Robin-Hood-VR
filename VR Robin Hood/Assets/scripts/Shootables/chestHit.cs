using UnityEngine;

public class chestHit : MonoBehaviour
{
    pointManager pointManager;
    sceneController sceneManager;
    private bool claimable = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ArrowTip") && claimable)
        {
            pointManager.points += 100;
            sceneManager.targetsShot++;
            claimable = false;
            gameObject.SetActive(false);
        }
    }
}
