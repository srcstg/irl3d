using UnityEngine;

namespace Libre.InteractiveElements
{
    /// <summary>
    /// Listen to state change and highlight the element
    /// </summary>
    [RequireComponent(typeof(InteractiveElement))]
    public class ShaderChangeHighlighter : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField] Material hoverMaterial;
#pragma warning restore 0649
        MeshRenderer[] _meshRenderers;
        MeshCache[] _meshCaches;
        InteractiveElement _interactiveElement;
        
        void Awake()
        {
            _meshRenderers = GetComponentsInChildren<MeshRenderer>();
            _meshCaches = new MeshCache[_meshRenderers.Length];
            _interactiveElement = GetComponent<InteractiveElement>();
            CacheOriginalMaterials();
        }

        void CacheOriginalMaterials()
        {
            for (int i = 0; i < _meshRenderers.Length; i++)
            {
                _meshCaches[i] = new MeshCache(_meshRenderers[i], _meshRenderers[i].sharedMaterials);
            }
        }

        void OnEnable()
        {
            _interactiveElement.OnStateChange += OnStateChange;
        }

        void OnDisable()
        {
            _interactiveElement.OnStateChange -= OnStateChange;
        }

        void OnStateChange(InteractiveElement.State newState)
        {
            if (newState == InteractiveElement.State.hovered)
            {
                ChangeAllMaterialsToHover();
            }
            else
            {
                ChangeAllMaterialsToOriginal();
            }
        }

        void ChangeAllMaterialsToHover()
        {
            for (int i = 0; i < _meshRenderers.Length; i++)
            {
                // int materialsLength = _meshRenderers[i].sharedMaterials.Length;
                _meshRenderers[i].sharedMaterials = new[] {hoverMaterial, hoverMaterial, hoverMaterial, hoverMaterial, hoverMaterial, hoverMaterial, hoverMaterial};
                // for (int j = 0; j < _meshRenderers[i].sharedMaterials.Length; j++)
                // {
                //     _meshRenderers[i].sharedMaterials[j] = hoverMaterial;
                // }
            }
        }
        
        void ChangeAllMaterialsToOriginal()
        {
            for (int i = 0; i < _meshRenderers.Length; i++)
            {
                _meshRenderers[i].sharedMaterials = _meshCaches[i].SharedMaterials;
            }
        }
    }

    public class MeshCache
    {
        MeshRenderer _meshRenderer;
        public Material[] SharedMaterials { get; private set; }

        public MeshCache(MeshRenderer meshRenderer, Material[] sharedMaterials)
        {
            _meshRenderer = meshRenderer;
            SharedMaterials = sharedMaterials;
        }
        
    }
}
