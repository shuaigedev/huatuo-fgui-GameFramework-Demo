using GameFramework;
using GameFramework.Fsm;
using GameFramework.Procedure;
using GameFramework.Resource;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace Game.Hotfix
{
    public class GameHotfixEntry
    {

        public static void Start()
        {
            InitCustomComponents();

            // 删除原生对话框。
            GameEntry.BuiltinData.DestroyDialog();

            // 重置流程组件，初始化热更新流程。
            GameEntry.Fsm.DestroyFsm<IProcedureManager>();
            var procedureManager = GameFrameworkEntry.GetModule<IProcedureManager>();
            ProcedureBase[] procedures =
            {
                new ProcedureChangeScene(),
                new ProcedureMenu(),
                new ProcedureMain(),
                new ProcedureLobby(),
                new ProcedurePreload(),
            };
            procedureManager.Initialize(GameFrameworkEntry.GetModule<IFsmManager>(), procedures);
            procedureManager.StartProcedure<ProcedurePreload>();
        }

        private static void OnLoadAssetSuccess(string assetName, object asset, float duration, object userdata)
        {
            GameObject game = Object.Instantiate((GameObject)asset);
            game.name = "Game";
        }

        private static void OnLoadAssetFail(string assetName, LoadResourceStatus status, string errormessage, object userdata)
        {
            Log.Error("Load game failed. {0}", errormessage);
        }

        public static CameraComponent Camera
        {
            get;
            private set;
        }

        public static GroundComponent Ground
        {
            get;
            private set;
        }

        public static void InitCustomComponents()
        {
            GameObject cround = new GameObject("GroundComponent");
            var croundCom = cround.GetOrAddComponent<GroundComponent>();
            GameEntry.HotCom.AddHotCom(croundCom);

            Camera = UnityGameFramework.Runtime.GameEntry.GetComponent<CameraComponent>();
            Ground = UnityGameFramework.Runtime.GameEntry.GetComponent<GroundComponent>();
        }

        public static void OpenApp(string packName)
        {
#if !UNITY_EDITOR
#if UNITY_ANDROID
                        AndroidJavaClass javaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                        AndroidJavaObject javaObject= javaClass.GetStatic<AndroidJavaObject>("currentActivity");

                        using (AndroidJavaObject obj=javaObject.Call<AndroidJavaObject>("getPackageManager"))
                        {
                            using (AndroidJavaObject initAPK = obj.Call<AndroidJavaObject>("getLaunchIntentForPackage",packName))
                            {
                                if (initAPK!=null)
                                {
                                    javaObject.Call("startActivity", initAPK);
                                }
                                else
                                {
                                    Debug.Log("未安装软件"+packName);
                                }
                            }
                        }
#endif
#else
            Log.Info("未实现");
#endif
        }
    }
}
