/*************************************
 * IGravity
 * 重力関係を取り扱うクラスのインターフェイス
 * 
 * 　開発者：K.Morishita Kumamoto-University Japan
 * 　
 * 　開発履歴：
 * 　            2012/7/18   重力モデルクラスのインターフェイスとして新設
 * 　            2012/7/19   楕円体高を効力するメソッドを追加
 * ************************************/
using System;
namespace Geodesy.GravitationalModel
{
    /// <summary>
    /// 重力モデルクラスインターフェイス
    /// </summary>
    public interface IGravity
    {
        /// <summary>
        /// 正規重力値を返します
        /// </summary>
        /// <param name="latitude">緯度[°]<para>単位に注意</para><para>化成緯度でも地心緯度でもない普通の緯度です。</para></param>
        /// <returns>重力値[m/s2]<para>単位がGalではないことに注意</para></returns>
        double GetGravity(double latitude);
        /// <summary>
        /// 重力加速度を返します
        /// </summary>
        /// <param name="latitude">緯度[°]　単位に注意</param>
        /// <param name="ellipsoidHeight">楕円体高[m]</param>
        /// <returns>重力値[m/s2]<para>単位がGalではないことに注意</para></returns>
        double GetGravity(double latitude, double ellipsoidHeight);
    }
}
