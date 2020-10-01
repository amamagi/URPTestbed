using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace UnityTemplateProjects.LiveSwitcher.Runtime
{
    [RequireComponent(typeof(UniversalAdditionalCameraData))]
    public class LiveSwitcherRendererSetter : MonoBehaviour
    {
        [SerializeField] private int _liveSwitcherRendererIndex = 1;
        private void Start()
        {
            var cameraData = GetComponent<UniversalAdditionalCameraData>();
            cameraData.SetRenderer(_liveSwitcherRendererIndex);
        }
    }
}