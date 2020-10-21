using DG.Tweening;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Libre.InteractiveElements
{
    [RequireComponent(typeof(InteractiveElement))]
    public class OnClickScaleToZero : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField] FloatVariable waypointFadeDuration;
#pragma warning restore 0649
        InteractiveElement _interactiveElement;
        Collider _collider;

        void Awake()
        {
            _collider = GetComponent<Collider>();
            _interactiveElement = GetComponent<InteractiveElement>();
        }

        void OnEnable()
        {
            _interactiveElement.OnClick += OnInteractiveElementClicked;
        }
        
        void OnDisable()
        {
            _interactiveElement.OnClick -= OnInteractiveElementClicked;
        }

        void OnInteractiveElementClicked(InteractiveElement clickedInteractiveElement)
        {
            if (clickedInteractiveElement.gameObject == gameObject)
            {
                _collider.enabled = false;
                transform.DOScale(Vector3.zero, waypointFadeDuration.Value).SetEase(Ease.InOutCubic);
            }
        }
    }
}