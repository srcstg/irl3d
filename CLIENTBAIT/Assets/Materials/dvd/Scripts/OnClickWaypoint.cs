using Libre.WaypointSystem;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Libre.InteractiveElements
{
    /// <summary>
    /// Trigger a transition when a waypoint is clicked
    /// </summary>
    public class OnClickWaypoint : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField] TransitionGameEvent transition;
        [SerializeField] WaypointVariable standingWaypoint;
#pragma warning restore 0649
        Waypoint _waypoint; 
        InteractiveElement _interactiveElement;

        void Awake()
        {
            _waypoint = GetComponent<Waypoint>();
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
            if (clickedInteractiveElement.gameObject == gameObject && standingWaypoint.Value != null)
            {
                transition.Raise(new Transition(standingWaypoint.Value, _waypoint));
            }
        }

        
    }
}