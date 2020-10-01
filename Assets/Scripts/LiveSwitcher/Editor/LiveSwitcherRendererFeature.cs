using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityTemplateProjects.LiveSwitcher.Runtime;

namespace UnityTemplateProjects.LiveSwitcher.Editor
{
    public class LiveSwitcherRendererFeature : ScriptableRendererFeature
    {
        public Material _liveSwitcherMaterial;
        private LiveSwitcherRenderPass _pass;
        public override void Create()
        {
            _pass = new LiveSwitcherRenderPass(_liveSwitcherMaterial);
        }

        public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
        {
            renderer.EnqueuePass(_pass);
        }
    }
}