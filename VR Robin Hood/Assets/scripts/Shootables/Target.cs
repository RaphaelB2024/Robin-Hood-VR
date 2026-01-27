using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    public sceneController controller;

    private void OnColliderEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ArrowTip") )
        {
            controller.targetsShot++;
            Debug.Log("Target Shot");
        }
    }
}
