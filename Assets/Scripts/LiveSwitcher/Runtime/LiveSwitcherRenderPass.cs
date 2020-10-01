using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace UnityTemplateProjects.LiveSwitcher.Runtime
{
    public class LiveSwitcherRenderPass : ScriptableRenderPass
    {
        private readonly string _passName = "LiveSwitcherRenderPass";
        private readonly Material _liveSwitcherMaterial;
        public LiveSwitcherRenderPass(Material liveSwitcherMaterial)
        {
            _liveSwitcherMaterial = liveSwitcherMaterial;
            renderPassEvent = RenderPassEvent.AfterRendering;
        }

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            var camera = renderingData.cameraData.camera;

            var cmd = CommandBufferPool.Get(_passName);
            cmd.SetViewProjectionMatrices(Matrix4x4.identity, Matrix4x4.identity);
            cmd.DrawMesh(RenderingUtils.fullscreenMesh, Matrix4x4.identity, _liveSwitcherMaterial);
            cmd.SetViewProjectionMatrices(camera.worldToCameraMatrix, camera.projectionMatrix);
            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }
    }
}