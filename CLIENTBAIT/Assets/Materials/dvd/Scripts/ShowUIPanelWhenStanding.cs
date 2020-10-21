using Libre.UI;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Libre.WaypointSystem
{
    /// <summary>
    /// Shows a UIPanel when player arrive to this waypoint
    /// </summary>
    public class ShowUIPanelWhenStanding : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField] WaypointVariable standingWaypoint;
        [SerializeField] IntGameEvent showUIPanel;
        [SerializeField] UIPanelType panelTypeToShow;
#pragma warning restore 0649
        Waypoint _waypoint;

        void Awake()
        {
            _waypoint = GetComponent<Waypoint>();
        }

        void OnEnable()
        {
            standingWaypoint.AddListener(OnValueChangeStandingWaypoint);
        }

        void OnDisable()
        {
            standingWaypoint.RemoveListener(OnValueChangeStandingWaypoint);
        }

        void OnValueChangeStandingWaypoint()
        {
            if (standingWaypoint.Value == _waypoint)
            {
                showUIPanel.Raise((int)panelTypeToShow);
            }
        }
    }
}