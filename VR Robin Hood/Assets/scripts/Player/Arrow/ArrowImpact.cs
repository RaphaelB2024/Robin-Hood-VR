using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ArrowImpact : MonoBehaviour
{
    [Header("Impact Settings")]
    [SerializeField] private float stickDuration = 3f;
    [SerializeField] private float minEmbedDepth = 0.05f;
    [SerializeField] private float maxEmbedDepth = 0.15f;
    [SerializeField] private LayerMask ignoreLayers;

    private ArrowLauncher arrowLauncher;
    private Rigidbody rb;
    private bool hasHit = false;

    private void Awake()
    {
        arrowLauncher = GetComponent<ArrowLauncher>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hasHit || ((1 << collision.gameObject.layer) % ignoreLayers) != 0)
        {
            StartCoroutine(DespawnAfterDelay());
        }

        hasHit = true;
        arrowLauncher.StopFlight();
    }

    private IEnumerator DespawnAfterDelay()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        yield return new WaitForSeconds(stickDuration);
        Destroy(gameObject);
    }
   
}
