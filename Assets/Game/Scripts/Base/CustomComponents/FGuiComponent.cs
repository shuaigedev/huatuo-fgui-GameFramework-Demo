using System.Collections.Generic;
using FairyGUI;
using GameFramework;
using UnityEngine;
using UnityGameFramework.Runtime;
using static FairyGUI.UIPackage;

namespace Game
{
     /// <summary>
    /// FGUI 管理
    /// </summary>
    public class FGuiComponent : GameFrameworkComponent
    {
        [SerializeField]
        private Camera m_UICamera = null;

        private Dictionary<string, int> m_FguiRef = null;

        private int FGuiPackageCount
        {
            get { return UIPackage.GetPackages().Count; }
        }

        public Dictionary<string, int> FguiRef
        {
            get { return m_FguiRef; }
        }

        public Vector2 CurrentScreenSize
        {
            get
            {
                if (m_UICamera != null)
                {
                    return new Vector2(m_UICamera.pixelWidth, m_UICamera.pixelHeight);
                }

                return new Vector2(Screen.width, Screen.height);
            }
        }

        protected override void Awake()
        {
            base.Awake();
            m_FguiRef = new Dictionary<string, int>();
        }

        public void AddPackage(FGuiForm hotfixFGuiForm)
        {
            //先加载依赖资源
            for (int i = 0; i < hotfixFGuiForm.FGuiDependencies.Length; i++)
            {
                AddPackage(hotfixFGuiForm.FGuiDependencies[i]);
            }

            //再加载主资源
            AddPackage(hotfixFGuiForm.PackageName);
        }

        public void AddPackage(string packageName)
        {
            if (string.IsNullOrEmpty(packageName))
            {
                throw new GameFrameworkException("packageName is null");
            }

            UIPackage uiPackage = UIPackage.GetByName(packageName);

            if (uiPackage == null)
            {
                if (GameEntry.Base.EditorResourceMode)
                {
                    string packagePath =
                        Utility.Text.Format("Assets/Game/Res/FGuiResource/{0}", packageName);

                    uiPackage = UIPackage.AddPackage(packagePath);
                }
                else
                {
                    AssetBundle ab = AssetBundle.LoadFromFile(Utility.Text.Format("{0}/Res/FGuiResource/{1}_fui.dat",
                        Application.persistentDataPath, packageName));
                    AssetBundle abRes = AssetBundle.LoadFromFile(Utility.Text.Format("{0}/Res/FGuiResource/{1}_atlas0.dat",
                        Application.persistentDataPath, packageName));

                    UIPackage.AddPackage(ab, abRes);
                }
            }

            AddRef(packageName);
        }

        /// <summary>
        /// 增加FGUIPackage的引用
        /// </summary>
        public void AddRef(string packageName)
        {
            int refCout;

            if (!m_FguiRef.TryGetValue(packageName, out refCout))
            {
                refCout = 0;
                m_FguiRef.Add(packageName, refCout);
            }

            refCout++;
            m_FguiRef[packageName] = refCout;
        }

        public void RemoveRef(FGuiForm hotfixFGuiForm)
        {
            for (int i = 0; i < hotfixFGuiForm.FGuiDependencies.Length; i++)
            {
                RemoveRef(hotfixFGuiForm.FGuiDependencies[i]);
            }

            RemoveRef(hotfixFGuiForm.PackageName);
        }

        /// <summary>
        /// 删除FGUIPackage的引用
        /// </summary>
        public void RemoveRef(string packageName)
        {
            int refCout;

            if (!m_FguiRef.TryGetValue(packageName, out refCout))
            {
                throw new GameFrameworkException(Utility.Text.Format("{0} is not exit", packageName));
            }

            m_FguiRef[packageName]--;

            if (m_FguiRef[packageName] <= 0 && UIPackage.GetPackages().Count != 0)
            {
                m_FguiRef.Remove(packageName);
                UIPackage.RemovePackage(packageName);
            }
        }
    }
    
}