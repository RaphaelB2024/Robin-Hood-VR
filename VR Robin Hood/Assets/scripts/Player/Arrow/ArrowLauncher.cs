using UnityEngine;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ArrowLauncher : MonoBehaviour
{
    [Header("Launch Settings")]
    [SerializeField] private float _speed = 10f;

    [Header("Visual Effects")]
    [SerializeField] private GameObject _trailSystem;

    private Rigidbody _rigidbody;
    private bool _inAir = false;
    private XRPullInteractable _pullInteractable;

    private void Awake()
    {
        InitialiseComponents();
        SetPhysics(false);
    }

    private void InitialiseComponents()
    {
        _rigidbody = GetComponent<Rigidbody>();
        if(_rigidbody == null)
        {
            Debug.LogError($"Rigid component not found");
        }
    }

    public void Initialise(XRPullInteractable pullInteractable)
    {
        _pullInteractable = pullInteractable;
        _pullInteractable.PullActionReleased += Release;
    }

    private void OnDestroy()
    {
        if(_pullInteractable != null)
        {
            _pullInteractable.PullActionReleased -= Release;
        }
    }

    private void Release(float value)
    {
        if (_pullInteractable != null)
        {
            _pullInteractable.PullActionReleased -= Release;
        }

        gameObject.transform.parent = null;
        _inAir = true;
        SetPhysics(true);

        Vector3 force = -transform.right * value * _speed;
        _rigidbody.AddForce(force, ForceMode.Impulse);

        _trailSystem.SetActive(true);
    }

    public void StopFlight()
    {
        _inAir = false;
        SetPhysics(false);
        _trailSystem.SetActive(false);
    }

    private void SetPhysics(bool usePhysics)
    {
        if(_rigidbody != null)
        {
            _rigidbody.useGravity = usePhysics;
            _rigidbody.isKinematic = !usePhysics;
        }
    }
}
