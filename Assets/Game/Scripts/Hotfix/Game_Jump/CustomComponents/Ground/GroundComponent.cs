using GameFramework;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace Game.Hotfix
{
    
    /// <summary>
    /// 地板组件  用于生成不同类型的地板 策略开发者模式
    /// </summary>
    public class GroundComponent :GameFrameworkComponent
    {
        /// <summary>
        /// 难度等级
        /// </summary>
        private int m_Level;
        
        /// <summary>
        /// 创建地板类
        /// </summary>
        private ICreateGround m_CreateGround;
  
        /// <summary>
        /// 初始地板生成位置
        /// </summary>
        [SerializeField]private float m_GroundStartLocationY = -3f;

        /// <summary>
        /// 地板之间的距离
        /// </summary>
        [SerializeField]private float m_GroundLocationAddY = 2f;

        private CreateGroundManager m_CreateGroundManager;

        protected override void Awake()
        {
            base.Awake();
            m_CreateGroundManager = new CreateGroundManager();
        }

        private void Start()
        {
            SetLevel(0);
        }

        /// <summary>
        /// 设置具体创建工厂类
        /// </summary>
        /// <param name="createGround"></param>
        /// <exception cref="GameFrameworkException"></exception>
        public void SetCreateGround(ICreateGround createGround)
        {
            if (createGround == null)
            {
                throw new GameFrameworkException("ICreateGround is valid");
            }

            m_CreateGround = createGround;
        }

        /// <summary>
        /// 根据分数计算难度等级
        /// </summary>
        /// <param name="Score"></param>
        public void SetLevel(int Score)
        {
            //todo 计算分数
            m_Level = 1;
            ICreateGround createGround = null;
            switch (m_Level)
            {
                case 0 : createGround = ReferencePool.Acquire<CreateNormalGround>();
                    break;
                case 1 : createGround = ReferencePool.Acquire<CreateMoveGround>();
                    break;
                case 2 : createGround = ReferencePool.Acquire<CreateNormalGround>();
                    break;
                case 3 : createGround = ReferencePool.Acquire<CreateNormalGround>();
                    break;
                default: createGround = ReferencePool.Acquire<CreateNormalGround>();
                    break;
            }
            SetCreateGround(createGround);
        }

        /// <summary>
        /// 利用工厂类 生成地板
        /// </summary>
        /// <exception cref="GameFrameworkException"></exception>
        public void CreateGround()
        {
            if (m_CreateGround == null)
            {
                throw new GameFrameworkException("ICreateGround is valid");
            }

            //todo 生成数量
            int createNum = 1;
            GroundDataList groundDatas = m_CreateGround.GetCreateGroundDatas(GetGroundNextLocation());
            for (int i = 0; i < createNum; i++)
            {
                foreach (CreateGroundData data in groundDatas)
                {
                    m_CreateGroundManager.LoadGround(data.GroundLocation, data.GroundType);
                }
            }
        }
        /// <summary>
        /// 获取到下一个地板生成位置
        /// </summary>
        /// <returns></returns>
        public float GetGroundNextLocation()
        {
            m_GroundStartLocationY += m_GroundLocationAddY;
            return m_GroundStartLocationY;
        }
        
        /// <summary>
        /// 加载地板
        /// </summary>
        /// <param name="position">地板生成位置</param>
        /// <param name="type">地板类型</param>
        public void LoadGround(Vector3 position, GroundType type)
        {
            m_CreateGroundManager.LoadGround(position, (int) type);
        }

        public void Reset()
        {
            m_GroundStartLocationY = -3f;
        }

        public void Clear()
        {
            //清空数据
            m_Level = 0;
            m_CreateGround = null;
        }
        
    }
}