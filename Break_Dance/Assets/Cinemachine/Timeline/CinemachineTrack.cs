using System;
using UnityEngine;
using UnityEngine.Playables;
#pragma warning disable CS0234 // The type or namespace name 'Timeline' does not exist in the namespace 'UnityEngine' (are you missing an assembly reference?)
using UnityEngine.Timeline;
#pragma warning restore CS0234 // The type or namespace name 'Timeline' does not exist in the namespace 'UnityEngine' (are you missing an assembly reference?)

namespace Cinemachine.Timeline
{
    [Serializable]
#pragma warning disable CS0246 // The type or namespace name 'TrackClipTypeAttribute' could not be found (are you missing a using directive or an assembly reference?)
#pragma warning disable CS0246 // The type or namespace name 'TrackClipType' could not be found (are you missing a using directive or an assembly reference?)
    [TrackClipType(typeof(CinemachineShot))]
#pragma warning restore CS0246 // The type or namespace name 'TrackClipType' could not be found (are you missing a using directive or an assembly reference?)
#pragma warning restore CS0246 // The type or namespace name 'TrackClipTypeAttribute' could not be found (are you missing a using directive or an assembly reference?)
#pragma warning disable CS0246 // The type or namespace name 'TrackMediaTypeAttribute' could not be found (are you missing a using directive or an assembly reference?)
#pragma warning disable CS0246 // The type or namespace name 'TrackMediaType' could not be found (are you missing a using directive or an assembly reference?)
#pragma warning disable CS0103 // The name 'TimelineAsset' does not exist in the current context
    [TrackMediaType(TimelineAsset.MediaType.Script)]
#pragma warning restore CS0103 // The name 'TimelineAsset' does not exist in the current context
#pragma warning restore CS0246 // The type or namespace name 'TrackMediaType' could not be found (are you missing a using directive or an assembly reference?)
#pragma warning restore CS0246 // The type or namespace name 'TrackMediaTypeAttribute' could not be found (are you missing a using directive or an assembly reference?)
#pragma warning disable CS0246 // The type or namespace name 'TrackBindingTypeAttribute' could not be found (are you missing a using directive or an assembly reference?)
#pragma warning disable CS0246 // The type or namespace name 'TrackBindingType' could not be found (are you missing a using directive or an assembly reference?)
    [TrackBindingType(typeof(CinemachineBrain))]
#pragma warning restore CS0246 // The type or namespace name 'TrackBindingType' could not be found (are you missing a using directive or an assembly reference?)
#pragma warning restore CS0246 // The type or namespace name 'TrackBindingTypeAttribute' could not be found (are you missing a using directive or an assembly reference?)
#pragma warning disable CS0246 // The type or namespace name 'TrackColorAttribute' could not be found (are you missing a using directive or an assembly reference?)
#pragma warning disable CS0246 // The type or namespace name 'TrackColor' could not be found (are you missing a using directive or an assembly reference?)
    [TrackColor(0.53f, 0.0f, 0.08f)]
#pragma warning restore CS0246 // The type or namespace name 'TrackColor' could not be found (are you missing a using directive or an assembly reference?)
#pragma warning restore CS0246 // The type or namespace name 'TrackColorAttribute' could not be found (are you missing a using directive or an assembly reference?)
#pragma warning disable CS0246 // The type or namespace name 'TrackAsset' could not be found (are you missing a using directive or an assembly reference?)
    public class CinemachineTrack : TrackAsset
#pragma warning restore CS0246 // The type or namespace name 'TrackAsset' could not be found (are you missing a using directive or an assembly reference?)
    {
#pragma warning disable CS0115 // 'CinemachineTrack.CreateTrackMixer(PlayableGraph, GameObject, int)': no suitable method found to override
        public override Playable CreateTrackMixer(
#pragma warning restore CS0115 // 'CinemachineTrack.CreateTrackMixer(PlayableGraph, GameObject, int)': no suitable method found to override
            PlayableGraph graph, GameObject go, int inputCount)
        {
            // Hack to set the display name of the clip to match the vcam
            foreach (var c in GetClips())
            {
                CinemachineShot shot = (CinemachineShot)c.asset;
                CinemachineVirtualCameraBase vcam = shot.VirtualCamera.Resolve(graph.GetResolver());
                if (vcam != null)
                    c.displayName = vcam.Name;
            }

            var mixer = ScriptPlayable<CinemachineMixer>.Create(graph);
            mixer.SetInputCount(inputCount);
            return mixer;
        }
    }
}
