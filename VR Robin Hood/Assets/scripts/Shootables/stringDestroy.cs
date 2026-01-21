using UnityEngine;

public class stringDestroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ArrowTip"))
        {
            transform.DetachChildren();
            Destroy(gameObject);
        }
    }
}
