using UnityEngine;

public class bagHit : MonoBehaviour
{
    pointManager pointManager;
    sceneController sceneManager;
    private bool claimable = true;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Floor") && claimable)
        {
            pointManager.points += 50;
            sceneManager.targetsShot++;
            claimable = false;
            gameObject.SetActive(false);
        }
    }
}
