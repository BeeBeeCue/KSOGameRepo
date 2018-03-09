using UnityEngine;
using UnityEngine.Playables;
#pragma warning disable CS0234 // The type or namespace name 'Timeline' does not exist in the namespace 'UnityEngine' (are you missing an assembly reference?)
using UnityEngine.Timeline;
#pragma warning restore CS0234 // The type or namespace name 'Timeline' does not exist in the namespace 'UnityEngine' (are you missing an assembly reference?)

namespace Cinemachine.Timeline
{
    internal sealed class CinemachineShotPlayable : PlayableBehaviour
    {
        public CinemachineVirtualCameraBase VirtualCamera;
    }

#pragma warning disable CS0246 // The type or namespace name 'IPropertyPreview' could not be found (are you missing a using directive or an assembly reference?)
    public sealed class CinemachineShot : PlayableAsset, IPropertyPreview
#pragma warning restore CS0246 // The type or namespace name 'IPropertyPreview' could not be found (are you missing a using directive or an assembly reference?)
    {
        public ExposedReference<CinemachineVirtualCameraBase> VirtualCamera;

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<CinemachineShotPlayable>.Create(graph);
            playable.GetBehaviour().VirtualCamera = VirtualCamera.Resolve(graph.GetResolver());
            return playable;
        }

        // IPropertyPreview implementation
#pragma warning disable CS0246 // The type or namespace name 'IPropertyCollector' could not be found (are you missing a using directive or an assembly reference?)
        public void GatherProperties(PlayableDirector director, IPropertyCollector driver)
#pragma warning restore CS0246 // The type or namespace name 'IPropertyCollector' could not be found (are you missing a using directive or an assembly reference?)
        {
            driver.AddFromName<Transform>("m_LocalPosition.x");
            driver.AddFromName<Transform>("m_LocalPosition.y");
            driver.AddFromName<Transform>("m_LocalPosition.z");
            driver.AddFromName<Transform>("m_LocalRotation.x");
            driver.AddFromName<Transform>("m_LocalRotation.y");
            driver.AddFromName<Transform>("m_LocalRotation.z");

            driver.AddFromName<Camera>("field of view");
            driver.AddFromName<Camera>("near clip plane");
            driver.AddFromName<Camera>("far clip plane");
        }
    }
}
