/**************************************************************************
 * WGS84.cs
 * WGS84測地系パラメータ for C#
 * 
 * 開発者　：森下功啓（K.Morhista Kumamoto-University @ 2012/8）
 * 開発履歴：2011/7/3   整備開始
 *           2011/7/6   2地点間の距離を求める、GetDistanceのデバッグ。単位長までしか計算していなかった…。
 *           2011/7/17  XYZとBLHに二項演算子を追加
 *           2011/9/19  Open(string fname)のバグを修正
 *                      GetPositions(),GetPositioningResults()において、ubloxのNMEAフォーマットに対応（現時点での要求仕様を満たすだけなので万能ではないことに注意）
 *                      PositioningInfosのToString()に高度も含まれるように変更
 *           2011/11/11 よく分かっていないが、シリアル化した方が良さそうとのことで[Serializable]を片っ端からつけてみた。今後どうなるかは・・・よく分からない。
 *           2011/11/20 BLH構造体にToString()を追加
 *           2011/12/2  XML構文エラーがある部分を訂正した
 *           2011/12/15 BLH構造体にToString()を追加
 *           2012/4/22  コメントを少しだけ付け直した。
 *                      NMEAクラスは現時点ではバイナリの処理が不可能だが、そこんとこを何とかしたい。
 *           2012/4/24  ソースコードを分割して独立させた。
 *           ---------------------------------------------------------------
 *           2012/7/3   測地系の拡張に備えて、クラスをstaticにするのをやめた。
 *                      メンバをプロパティへ移す。
 *                      インターフェイスを実装する。
 *           2012/7/20  プロパティが呼び出されるたびに計算していたのを、コンストラクタで予め計算して返すように変更した。
 *                      少し高速になったと思う。
 *                      また、パラメータへ正規重力値（計算すればいいんだけどさ）を追加した。
 *                      名前空間をGNSS.GeodeticDatumからGeodesy.GeodeticDatumへ変更
 * ***********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geodesy.GeodeticDatum
{
    /*2011/7/6 主要パラメータチェック済み*/
    /// <summary>
    /// WGS84座標系（G873）における各種パラメータ
    /// <para>参考：西修二郎訳，GNSSのすべて，p.265，2010.2．</para>
    /// </summary>
    public class Wgs84G873 : IDatum
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
            get { return 298.257223563; }
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
            get { return 3986004.418E+8; }
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
        public Wgs84G873()
        {
            this._f = 1.0d / this.InversOblateness;
            this._e2 = this._f * (2.0d - this._f);
            this._e = Math.Sqrt(this._e2);
            this._b = this.a * (1.0d - this._f);
        }
        /// <summary>
        /// 静的メンバ用コンストラクタ
        /// </summary>
        static Wgs84G873()
        {
            
        }
    }
}
