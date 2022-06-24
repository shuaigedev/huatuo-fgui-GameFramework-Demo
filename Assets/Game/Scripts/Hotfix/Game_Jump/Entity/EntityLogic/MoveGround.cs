using DG.Tweening;
using GameFramework;
using UnityEngine;

namespace Game.Hotfix
{
    public class MoveGround : Ground
    {
        private bool m_IsLeft;
        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            m_IsLeft = CachedTransform.position.y < 0;

            if (m_IsLeft)
            {
                MoveToRight();
            }
            else
            {
                MoveToLeft();
            }
        }

        private void MoveToRight()
        {
            float moveTime = Random.Range(1f, 2f);
            CachedTransform.DOLocalMoveX(-2f, moveTime).OnComplete(MoveToLeft);
        }

        private void MoveToLeft()
        {
            float moveTime = Random.Range(1f, 2f);
            CachedTransform.DOLocalMoveX(2f, moveTime).OnComplete(MoveToRight);
        }
    }
}