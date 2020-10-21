using System;
using Libre.UI;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Libre.InteractiveElements
{
    /// <summary>
    /// Sets the video to show and show the video UI panel OnClick
    /// </summary>
    [RequireComponent(typeof(InteractiveElement))]
    public class OnClickShowVideoInteractiveElement : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField] bool instanceShowPrePanel;
        [SerializeField] IntGameEvent showUIPanel;
        [SerializeField] StringVariable videoToShow;
        [SerializeField] string videoFilename;
        [SerializeField] BoolVariable showPreVideoPanel;
#pragma warning restore 0649
        InteractiveElement _interactiveElement;


        void Awake()
        {
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
                PlayVideo();
            }
        }

        void PlayVideo()
        {
            showPreVideoPanel.Value = instanceShowPrePanel;
            videoToShow.Value = videoFilename;
            showUIPanel.Raise((int) UIPanelType.VideoPlayer);
        }

        
    }
}