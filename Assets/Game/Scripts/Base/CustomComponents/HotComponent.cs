using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace Game
{
    public class HotComponent : GameFrameworkComponent
    {
        private Dictionary<string, GameFrameworkComponent> m_hotComRef = null;

        public Dictionary<string, GameFrameworkComponent> FguiRef
        {
            get { return m_hotComRef; }
        }

        protected override void Awake()
        {
            base.Awake();
            m_hotComRef = new Dictionary<string, GameFrameworkComponent>();
        }

        public void AddHotCom(GameFrameworkComponent com)
        {
            if (!m_hotComRef.ContainsKey("m_hotComRef"))
            {
                m_hotComRef.Add(com.name, com);
                com.transform.parent = transform;
            }
        }

        public void RemoveHotCom(string name)
        {
            if (m_hotComRef.ContainsKey(name))
            {
                Destroy(m_hotComRef[name].gameObject);
                m_hotComRef.Remove(name);
            }
            
        }

        protected override void OnDestroy()
        {
            //该组件不销毁
            //base.OnDestroy();
        }
    }
}
