using System;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace UnityEngine.XR.Interaction.Toolkit.Interactables
{
    public class XRPullInteractable : XRBaseInteractable
    {
        public event Action<float> PullActionReleased;
        public event Action<float> PullUpdated;
        public event Action<float> PullStarted;
        public event Action<float> PullEnded;

        [Header("Pull Settings")]
        [SerializeField] private Transform _startPoint;
        [SerializeField] private Transform _endPoint;
        [SerializeField] private GameObject _notchPoint;

        public float pullAmount { get; private set; } = 0.0f;

        private LineRenderer _lineRenderer;
        


    }
}