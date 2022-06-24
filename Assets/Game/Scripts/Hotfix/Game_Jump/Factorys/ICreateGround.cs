using System.Collections.Generic;
using GameFramework;

namespace Game.Hotfix
{
    /// <summary>
    /// 地板工厂接口
    /// </summary>
    public interface ICreateGround : IReference
    {
        GroundDataList GetCreateGroundDatas(float locationY);
    }
}