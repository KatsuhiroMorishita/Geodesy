/**************************************************************************
 * GlobalDatum.cs
 * 様々な測地系を表現可能なクラス
 * 
 * 開発者　：森下功啓（K.Morhista Kumamoto-University @ 2012/8）
 * 開発履歴：
 *              2012/8/6    コード内にifをたくさん書くのが嫌になったので新設
 *              2012/8/27   コンストラクタへコメントを追加
 * ***********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geodesy.GeodeticDatum
{
    /// <summary>
    /// 様々な測地系を表現可能なクラス
    /// </summary>
    public class GlobalDatum: IDatum
    {
        /* メンバ変数・定数 *****************************************/
        /// <summary>
        /// 測地系の種類
        /// </summary>
        Datum datumKind;
        /// <summary>
        /// 測地系オブジェクト
        /// </summary>
        IDatum _datum;
        /* プロパティ ***********************************************/
        /// <summary>
        /// 円周率π
        /// </summary>
        public virtual double PI
        {
            get { return this._datum.PI; }
        }
        /// <summary>
        /// 光速[m/s]
        /// </summary>
        public virtual double c
        {
            get { return this._datum.c; }
        }
        // 地球に関するパラメータ
        /// <summary>
        /// Equatorial Radius
        /// <para>赤道半径（楕円体長半径）[m]</para>
        /// </summary>
        public virtual double a
        {
            get { return this._datum.a; }
        }
        /// <summary>
        /// Short Radius
        /// <para>短半径</para>
        /// </summary>
        public virtual double b
        {
            get { return this._datum.b; }
        }
        /// <summary>
        /// Eccentricity
        /// <para>離心率e</para>
        /// </summary>
        public virtual double e
        {
            get { return this._datum.e; }
        }
        /// <summary>
        /// Square Eccentricity
        /// <para>離心率の二乗</para>
        /// </summary>
        public virtual double e2
        {
            get { return this._datum.e2; }
        }
        /// <summary>
        /// 扁平率
        /// </summary>
        public virtual double f
        {
            get { return this._datum.f; }
        }
        /// <summary>
        /// 扁平率の逆数
        /// </summary>
        public virtual double InversOblateness
        {
            get { return this._datum.InversOblateness; }
        }
        /// <summary>
        /// 物理的定数その1
        /// <para>ω^2a^2b/(GM)またはω^2a/NormalGravityAtEquator</para>
        /// </summary>
        public double m
        {
            get { return this._datum.m; }
        }
        /// <summary>
        /// 赤道での正規重力[m/s^2]
        /// </summary>
        public double NormalGravityAtEquator
        {
            get { return this._datum.NormalGravityAtEquator; }
        }
        /// <summary>
        /// 極での正規重力[m/s^2]
        /// </summary>
        public double NormalGravityAtPole
        {
            get { return this._datum.NormalGravityAtPole; }
        }
        /// <summary>
        /// Gravitational Constant of The Earth
        /// <para>地球の地心重力定数[m^3/s^-2]（大気を含む）</para>
        /// </summary>
        public virtual double GM
        {
            get { return this._datum.GM; }
        }
        /// <summary>
        /// Angular Velocity of The Earth
        /// <para>地球の角速度[rad/sec]</para>
        /// </summary>
        public virtual double wE
        {
            get { return this._datum.wE; }
        }
        /// <summary>
        /// 測地系の種類
        /// </summary>
        public Datum DatumKind
        {
            get { return this.datumKind; }
        }
        /* メソッド ***********************************************/
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="datum">測地系の種類</param>
        public GlobalDatum(Datum datum)
        {
            datumKind = datum;
            if (datum == Datum.WGS84)
                _datum = new Wgs84();
            else if (datum == Datum.GRS80)
                _datum = new Grs80();
            else
                throw new ArgumentException("GlobalDatumクラスのコンストラクタにてエラーがスローされました。不明な測地系が指定されています。");
        }
    }
}
