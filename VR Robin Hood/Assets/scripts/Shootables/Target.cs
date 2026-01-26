using UnityEngine;

public class Target : MonoBehaviour
{
    public sceneController controller;

    private void OnColliderEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ArrowTip"))
        {
            controller.targetsShot++;
            gameObject.SetActive(false);
        }
    }
}
