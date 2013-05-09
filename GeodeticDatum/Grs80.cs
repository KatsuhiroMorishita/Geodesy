/**************************************************************************
 * Grs80.cs
 * Grs80測地系パラメータ for C#
 * 
 * 開発者　：森下功啓（K.Morhista Kumamoto-University @ 2012.7）
 * 開発履歴：
 *              2012/7/19   新設
 *                          測地系とゆーても、ジオイド定義を含んではいないし、測地系間の相互変換も実装していない。
 *                          ジオイドを実装した段階でファイル構成の変更があると思う。
 *              2012/7/20   名前空間をGNSS.GeodeticDatumからGeodesy.GeodeticDatumへ変更
 * ***********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geodesy.GeodeticDatum
{
    /// <summary>
    /// GRS80準拠楕円体の各種パラメータ
    /// <para>参考：B. ホフマン-ウェレンホフ/H. モーリッツ　西修二郎訳，物理測地学，シュプリンガー・ジャパン，p.75-81，2006.8．</para>
    /// </summary>
    public class Grs80 : IDatum
    {
        /* メンバ変数・定数 *****************************************/
        /// <summary>
        /// 離心率
        /// </summary>
        private double _e;
        /// <summary>
        /// 離心率の二乗
        /// </summary>
        private double _e2;
        /// <summary>
        /// 短半径
        /// </summary>
        private double _b;
        /// <summary>
        /// 扁平率
        /// </summary>
        private double _f;
        /* プロパティ ***********************************************/
        /// <summary>
        /// 円周率π
        /// </summary>
        public virtual double PI
        {
            get { return 3.141592653589; }
        }
        /// <summary>
        /// 光速[m/s]
        /// </summary>
        public virtual double c
        {
            get { return 2.99792458E+08; }
        }
        // 地球に関するパラメータ
        /// <summary>
        /// Equatorial Radius
        /// <para>赤道半径（楕円体長半径）[m]</para>
        /// </summary>
        public virtual double a
        {
            get { return 6378137.0; }
        }
        /// <summary>
        /// Short Radius
        /// <para>短半径</para>
        /// </summary>
        public virtual double b
        {
            get { return this._b; }
        }
        /// <summary>
        /// Eccentricity
        /// <para>離心率e</para>
        /// </summary>
        public virtual double e
        {
            get { return this._e; }
        }
        /// <summary>
        /// Square Eccentricity
        /// <para>離心率の二乗</para>
        /// </summary>
        public virtual double e2
        {
            get { return this._e2; }
        }
        /// <summary>
        /// 扁平率
        /// </summary>
        public virtual double f
        {
            get { return this._f; }
        }
        /// <summary>
        /// 扁平率の逆数
        /// </summary>
        public virtual double InversOblateness
        {
            get { return 298.257222101; }
        }
        /// <summary>
        /// 物理的定数その1
        /// <para>ω^2a^2b/(GM)またはω^2a/NormalGravityAtEquator</para>
        /// </summary>
        public double m 
        {
            get { return 0.00344978650684; }
        }
        /// <summary>
        /// 赤道での正規重力[m/s^2]
        /// </summary>
        public double NormalGravityAtEquator 
        {
            get { return 9.7803253359; }
        }
        /// <summary>
        /// 極での正規重力[m/s^2]
        /// </summary>
        public double NormalGravityAtPole 
        {
            get { return 9.8321849378; }
        }
        /// <summary>
        /// Gravitational Constant of The Earth
        /// <para>地球の地心重力定数[m^3/s^-2]（大気を含む）</para>
        /// </summary>
        public virtual double GM
        {
            get { return 3986005.10E+8; }
        }
        /// <summary>
        /// Angular Velocity of The Earth
        /// <para>地球の角速度[rad/sec]</para>
        /// </summary>
        public virtual double wE
        {
            get { return 7292115E-11; }
        }
        /* メソッド ***********************************************/
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Grs80()
        {
            this._f = 1.0d / this.InversOblateness;
            this._e2 = this._f * (2.0d - this._f);
            this._e = Math.Sqrt(this._e2);
            this._b = this.a * (1.0d - this._f);
        }
        /// <summary>
        /// 静的メンバ用コンストラクタ
        /// </summary>
        static Grs80()
        {
            
        }
    }
}
