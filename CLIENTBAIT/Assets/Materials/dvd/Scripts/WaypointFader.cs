using System.Collections;
using DG.Tweening;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Libre.WaypointSystem
{
    /// <summary>
    /// FadesIn/Out a waypoint
    /// </summary>
    public class WaypointFader : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField] FloatVariable waypointFadeDuration;
         
#pragma warning restore 0649
        Transform _transform;
        Collider __collider;
        Collider _collider
        {
            get
            {
                if (__collider == null)
                    __collider = GetComponent<Collider>();
                return __collider;
            }
        }

        void Awake()
        {
            _transform = GetComponent<Transform>();
        }

        public void FadeOut()
        {
            if (!_collider.enabled)
            {
                return;
            }
            _transform.DOScale(Vector3.zero, waypointFadeDuration.Value).SetEase(Ease.InOutCubic);
            _collider.enabled = false;
        }
        
        public void FadeIn()
        {
            if (_collider.enabled)
            {
                return;
            }

            _transform.DOScale(Vector3.one, waypointFadeDuration.Value).SetEase(Ease.InOutCubic);

            _collider.enabled = true;
        }
        
    }
}