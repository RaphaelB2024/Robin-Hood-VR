using UnityEngine;

public class Target : MonoBehaviour
{
    sceneController controller;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ArrowTip"))
        {
            controller.targetsShot++;
            gameObject.SetActive(false);
        }
    }
}
