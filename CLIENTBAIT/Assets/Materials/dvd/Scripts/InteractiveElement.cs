using System;
using Libre.UI;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Libre.InteractiveElements
{
    /// <summary>
    /// Change the state of the element depending on the mouse
    /// </summary>
    
    public class InteractiveElement : MonoBehaviour
    {
#pragma warning disable 0649
        [Header("Broadcasting")]
        [SerializeField] InteractiveElementGameEvent interactiveElementClicked;
        [SerializeField] UIPanelTypeVariable currentUIPanel;
        [SerializeField] WaypointVariable standingWaypoint;
#pragma warning restore 0649
        public enum State {unhovered, hovered}
        public Action<State> OnStateChange;
        public Action<InteractiveElement> OnClick;
        bool _listeningToMouse = false;
        
        State currentState = State.unhovered;
        

        void OnEnable()
        {
            currentUIPanel.AddListener(OnValueChangeCurrentUIPanel);   
            standingWaypoint.AddListener(OnValueChangeStandingWaypoint);
            OnValueChangeCurrentUIPanel();
            OnValueChangeStandingWaypoint();
        }

        void OnDisable()
        {
            currentUIPanel.RemoveListener(OnValueChangeCurrentUIPanel);
            standingWaypoint.RemoveListener(OnValueChangeStandingWaypoint);
        }

        void OnValueChangeStandingWaypoint()
        {
            if (standingWaypoint.Value == null)
            {
                SetState(State.unhovered);
            }
        }

        void OnValueChangeCurrentUIPanel()
        {
            _listeningToMouse = currentUIPanel.Value == UIPanelType.InGame;
            if (!_listeningToMouse)
                SetState(State.unhovered);
        }

        void OnMouseOver()
        {
            if (!_listeningToMouse || standingWaypoint.Value == null)
                return;
            
            SetState(State.hovered);
        }
        void OnMouseExit()
        {
            if (!_listeningToMouse || standingWaypoint.Value == null)
                return;
            
            SetState(State.unhovered);
        }

        void OnMouseUp()
        {
            if (!_listeningToMouse || standingWaypoint.Value == null)
                return;
            
            if (currentState == State.hovered)
            {
                Debug.Log($"OnClick {gameObject.name}");
                OnClick?.Invoke(this);
                interactiveElementClicked.Raise(this);
            }
        }

        void SetState(State newState)
        {
            if (currentState == newState)
                return;
            currentState = newState;
            OnStateChange?.Invoke(currentState);
        }
    }
}