
    
using FairyGUI;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace Game
{

    public static class FGUIExtension
    {
        public static void CloseUIForm(this UIComponent uiComponent, FGuiForm fguiForm)
        {
            uiComponent.CloseUIForm(fguiForm.UIForm);
        }
    }

    public class FGuiForm: UIFormLogic
    {
        public UIPanel UIPanel { get; private set; }

        public GComponent UI { get; set; }

        public string PackageName
        {
            get
            {
                if (UIPanel == null)
                {
                    UIPanel = GetComponent<UIPanel>();
                }

                return UIPanel.packageName;
            }
        }
        

        public void Close()
        {
            GameEntry.UI.CloseUIForm(this);
        }

        /// <summary>
        /// 原始深度
        /// </summary>
        public int OriginalDepth { get; private set; }

        /// <summary>
        /// 深度
        /// </summary>
        public int Depth
        {
            get { return UIPanel.sortingOrder; }
        }

        /// <summary>
        /// 深度间隔
        /// </summary>
        public const int DepthFactor = 100;


        [SerializeField] private string[] m_FGuiDependencies = null;

        public string[] FGuiDependencies
        {
            get { return m_FGuiDependencies; }
        }


        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            UIPanel = GetComponent<UIPanel>();
            UI = UIPanel.ui;
        }

        protected override void OnDepthChanged(int uiGroupDepth, int depthInUIGroup)
        {
            int oldDepth = Depth;
            base.OnDepthChanged(uiGroupDepth, depthInUIGroup);
            int deltaDepth = FGuiGroupHelper.DepthFactor * uiGroupDepth + DepthFactor * depthInUIGroup - oldDepth +
                             OriginalDepth;
            UIPanel.sortingOrder = deltaDepth;
            OriginalDepth = UIPanel.sortingOrder;
            UIPanel.SetSortingOrder(UIPanel.sortingOrder, true);
        }
    }
}

