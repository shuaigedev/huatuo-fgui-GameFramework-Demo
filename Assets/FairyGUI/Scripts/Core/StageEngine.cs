using UnityEngine;
using UnityEngine.Profiling;

namespace FairyGUI
{
    /// <summary>
    /// 
    /// </summary>
    public class StageEngine : MonoBehaviour
    {
        public int ObjectsOnStage;
        public int GraphicsOnStage;

        public static bool beingQuit;

        void Start()
        {
            useGUILayout = false;
        }

        void LateUpdate()
        {
            Profiler.BeginSample("StageEngine.LateUpdate");
            Stage.inst.InternalUpdate();

            ObjectsOnStage = Stats.ObjectCount;
            GraphicsOnStage = Stats.GraphicsCount;
            Profiler.EndSample();
        }

        void OnGUI()
        {
            Stage.inst.HandleGUIEvents(Event.current);
        }

#if !UNITY_5_4_OR_NEWER
        void OnLevelWasLoaded()
        {
            StageCamera.CheckMainCamera();
        }
#endif

        void OnApplicationQuit()
        {
            if (Application.isEditor)
            {
                beingQuit = true;
                UIPackage.RemoveAllPackages();
            }
        }
    }
}