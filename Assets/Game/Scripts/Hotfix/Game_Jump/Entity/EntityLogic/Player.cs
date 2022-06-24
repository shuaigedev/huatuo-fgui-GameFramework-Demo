using DG.Tweening;
using GameFramework;
using UnityEditor;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace Game.Hotfix
{
    public class Player : Entity
    {
        [SerializeField] private PlayerData m_PlayerData = null;

        private RaycastHit2D m_Rayhit;

        private readonly float m_DefaultMoveDistance = 3f;

        private bool m_IsJump;

        private Rigidbody2D m_Rigidbody2D;
        
        private float m_MaxY;
        
        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            m_PlayerData = userData as PlayerData;
            if (m_PlayerData == null)
            {
                Log.Error("Player object data is invalid.");
                return;
            }

            transform.localPosition = m_PlayerData.StartLocation;
            transform.localScale = Vector3.one*3;
            m_IsJump = false;
            m_Rigidbody2D = transform.GetComponent<Rigidbody2D>();
            m_MaxY = transform.localPosition.y;
        }

        private void FixedUpdate()
        {
            m_Rayhit = Physics2D.Raycast(CachedTransform.localPosition, Vector2.down, 0.35f,1<<8);

            if (m_Rayhit.collider != null && !m_IsJump)
            {
                if (m_Rayhit.collider.tag == "DeathGround")
                {
                    Log.Info("GameOver");
                    GameEntry.Event.Fire(this,ReferencePool.Acquire<GameOverEventArgs>());
                    GameEntry.Entity.HideEntity(this);
                }
                else
                {
                    m_Rigidbody2D.bodyType = RigidbodyType2D.Static;
                    m_IsJump = true;
                    CachedTransform.DOLocalMoveY(transform.localPosition.y+m_DefaultMoveDistance, 0.4f).SetEase(Ease.OutCubic).OnComplete(() =>
                    {
                        m_IsJump = false;
                        m_Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
                        CheckeUpScore();
                    });
                   
                }

            }
            CameraChange();
            float Hor = Input.GetAxis("Horizontal");//当你按‘a’'d'键返回一个[-1，1]的值
            CachedTransform.localPosition += Vector3.right * Hor * Time.deltaTime * 5;
           
        }


        /// <summary>
        /// 根据跳跃的高度 加分
        /// </summary>
        private void CheckeUpScore()
        {
            if (transform.localPosition.y > m_MaxY)
            {
                //加分
                int score =Mathf.FloorToInt((transform.localPosition.y-m_MaxY)*10);
                m_MaxY = transform.localPosition.y;
                GameEntry.Event.Fire(this,ReferencePool.Acquire<UpScoreEventArgs>().Fill(score));
            }
        }

        /// <summary>
        /// 摄像机跟随移动
        /// </summary>
        private void CameraChange()
        {
            Vector3 CameraLocation = GameHotfixEntry.Camera.MainCamera.transform.localPosition;
            float cus = transform.localPosition.y-CameraLocation.y;
            //当最高点不在屏幕中央的时候 摄像机移动
            if (cus>0.5f)
            {
                GameHotfixEntry.Camera.MainCamera.transform.DOLocalMoveY(transform.localPosition.y,0.3f);
            }
        }

        private void OnDrawGizmos()
        {
            Debug.DrawRay(CachedTransform.position, Vector2.down*0.35f , Color.red);
        }
    }
}