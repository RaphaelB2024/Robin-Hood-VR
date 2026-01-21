using UnityEngine;

public class bagHit : MonoBehaviour
{
    pointManager pointManager;
    private bool claimable = true;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            pointManager.points += 50;
            claimable = false;
            gameObject.SetActive(false);
        }
    }
}
