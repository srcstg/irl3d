using UnityEngine;

namespace Libre.InteractiveElements
{
    /// <summary>
    /// Rotates an object every frame
    /// </summary>
    public class Rotate : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField] Vector3 rotation;
#pragma warning restore 0649
        Transform _transform;

        void Awake()
        {
            _transform = GetComponent<Transform>();
        }

        void Update()
        {
            _transform.Rotate(rotation*Time.deltaTime);
        }
    }
}