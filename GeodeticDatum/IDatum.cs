/**************************************************************************
 * IDatum.cs
 * 測地系パラメータクラスのためのインターフェイス for C#
 * 
 * 開発者　：森下功啓（K.Morhista Kumamoto-University）
 * 開発履歴：
 *          2012/7/3    測地系の拡張に備えて、新設した。
 *          2012/7/20   名前空間をGNSS.GeodeticDatumからGeodesy.GeodeticDatumへ変更
 * ***********************************************************************/
using System;

namespace Geodesy.GeodeticDatum
{
    /// <summary>
    /// 準拠楕円体クラスのインターフェイス
    /// </summary>
    public interface IDatum
    {
        /// <summary>
        /// Equatorial Radius
        /// <para>赤道半径（楕円体長半径）[m]</para>
        /// </summary>
        double a { get; }
        /// <summary>
        /// Short Radius
        /// <para>短半径</para>
        /// </summary>
        double b { get; }
        /// <summary>
        /// 光速[m/s]
        /// </summary>
        double c { get; }
        /// <summary>
        /// Eccentricity
        /// <para>離心率e</para>
        /// </summary>
        double e { get; }
        /// <summary>
        /// Square Eccentricity
        /// <para>離心率の二乗</para>
        /// </summary>
        double e2 { get; }
        /// <summary>
        /// 扁平率
        /// </summary>
        double f { get; }
        /// <summary>
        /// 扁平率の逆数
        /// </summary>
        double InversOblateness { get; }
        /// <summary>
        /// 物理的定数その1
        /// <para>ω^2a^2b/(GM)またはω^2a/NormalGravityAtEquator</para>
        /// </summary>
        double m { get; }
        /// <summary>
        /// 赤道での正規重力[m/s^2]
        /// </summary>
        double NormalGravityAtEquator { get; }
        /// <summary>
        /// 極での正規重力[m/s^2]
        /// </summary>
        double NormalGravityAtPole { get; }
        /// <summary>
        /// 円周率π
        /// </summary>
        double PI { get; }
        /// <summary>
        /// Gravitational Constant of The Earth
        /// <para>地球の地心重力定数[m^3/s^-2]</para>
        /// </summary>
        double GM { get; }
        /// <summary>
        /// Angular Velocity of The Earth
        /// <para>地球の角速度[rad/sec]</para>
        /// </summary>
        double wE { get; }
    }
}
