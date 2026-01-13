using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ArrowSpawner : MonoBehaviour
{
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private GameObject notchPoint;
    [SerializeField] private float spawnDelay = 1f;

    private XRGrabInteractable bow;
    private XRPullInteractable pullInteractable;
    private bool arrowNotched = false;
    private GameObject currentArrow = null;

    private void Start()
    {
        bow = GetComponent<XRGrabInteractable>();
        pullInteractable = GetComponentInChildren<XRPullInteractable>();

        if(pullInteractable != null)
        {
            pullInteractable.PullActionReleased += NotchEmpty;
        }
    }

    private void OnDestroy()
    {
        if(pullInteractable != null)
        {
            pullInteractable.PullActionReleased -= NotchEmpty;
        }
    }

    private void Update()
    {
        if(bow.isSelected && !arrowNotched)
        {
            arrowNotched = true;
            StartCoroutine(DelayedSpawn());
        }

        if(!bow.isSelected && currentArrow != null)
        {
            Destroy(currentArrow);
            NotchEmpty(1f);
        }
    }

    private void NotchEmpty(float value)
    {
        arrowNotched = false;
        currentArrow = null;
    }

    private IEnumerator DelayedSpawn()
    {
        yield return new WaitForSeconds(spawnDelay);

        currentArrow = Instantiate(arrowPrefab, notchPoint.transform);

        ArrowLauncher launcher = currentArrow.GetComponent<ArrowLauncher>();
        if(launcher != null && pullInteractable != null)
        {
            launcher.Initialise(pullInteractable);
        }
    }
}
