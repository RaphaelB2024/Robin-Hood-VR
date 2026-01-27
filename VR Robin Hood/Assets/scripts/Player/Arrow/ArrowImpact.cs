using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ArrowImpact : MonoBehaviour
{
    [Header("Impact Settings")]
    [SerializeField] private float stickDuration = 3f;
    [SerializeField] private LayerMask ignoreLayers;

    private ArrowLauncher arrowLauncher;
    private sceneController controller;
    private Target targetHit;
    private Rigidbody rb;
    private bool hasHit = false;

    private void Awake()
    {
        arrowLauncher = GetComponent<ArrowLauncher>();
        rb = GetComponent<Rigidbody>();
        controller = FindFirstObjectByType<sceneController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hasHit || ((1 << collision.gameObject.layer) % ignoreLayers) != 0)
        {
            StartCoroutine(DespawnAfterDelay());

            if (collision.gameObject.CompareTag("Target"))
            {
                targetHit = collision.gameObject.GetComponent<Target>();
                if(targetHit.shootable)
                {
                    controller.targetsShot++;
                    targetHit.shootable = false;
                }
            }
        }
        hasHit = true;
    }

    private IEnumerator DespawnAfterDelay()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        yield return new WaitForSeconds(stickDuration);
        Destroy(arrowLauncher.gameObject);
        Destroy(gameObject);
    }
   
}
