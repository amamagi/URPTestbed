using System;
using UnityEngine;

namespace UnityTemplateProjects.LiveSwitcher.Runtime
{
    public class LiveSwitcherTextureManager : MonoBehaviour
    {
        [SerializeField] private Camera _camera = null;
        [SerializeField] private Material _liveSwitcherWindowMaterial = null;
        [SerializeField] private Material _liveSwitcherPreviewMatereial = null;
        [SerializeField] private RenderTexture _liveSwitcherRT;
        private static readonly int BaseMap = Shader.PropertyToID("_BaseMap");

        private void Start()
        {
            if (_liveSwitcherRT == null)
            {
                _liveSwitcherRT = new RenderTexture(Screen.width, Screen.height, 0, RenderTextureFormat.Default);
            }

            _liveSwitcherWindowMaterial.mainTexture = _liveSwitcherRT;
            _liveSwitcherPreviewMatereial.SetTexture(BaseMap, _liveSwitcherRT);
            _camera.targetTexture = _liveSwitcherRT;
        }
    }
}