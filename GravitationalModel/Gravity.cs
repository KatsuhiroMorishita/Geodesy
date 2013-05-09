/*************************************
 * Gravity
 * 重力関係を取り扱うデフォルトクラス
 * 
 * 　開発者：K.Morishita Kumamoto-University Japan
 * 　
 * 　開発履歴：
 * 　            2012/7/18   重力モデルクラスのデフォルトとして新設
 * ************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geodesy.GravitationalModel
{
    /// <summary>
    /// 重力モデルクラス
    /// <para>デフォルトではGRS80モデルを継承しています。</para>
    /// </summary>
    public class Gravity: GravityGrs80
    {
    }
}
