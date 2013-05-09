/*************************************
 * GravityBase.cs
 * 重力モデルの基底クラスです
 * 
 * 　[開発者]：K.Morishita Kumamoto-University Japan @ 2012.7
 * 　
 * 　[開発履歴]
 * 　            2012/7/20   新設
 * ************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Geodesy.GeodeticDatum;

namespace Geodesy.GravitationalModel
{
    /// <summary>
    /// 重力加速度の基底演算クラス
    /// </summary>
    /// <typeparam name="T">準拠楕円体</typeparam>
    public abstract class GravityBase<T> 
        : IGravity
        where T: IDatum, new()
       
    {
        /*- メンバ変数 ---------------------------*/
        /// <summary>
        /// 測地系オブジェクト
        /// </summary>
        private T datum;
        /*- プロパティ ---------------------------*/
        /*- メソッド -----------------------------*/
        /// <summary>
        /// 緯度と楕円体高に応じた重力加速度を返します
        /// <para>
        /// 正規重力を（楕円体表面での正規化された重力（引力と遠心力の合力））のチェビシェフ近似により計算する。
        /// </para>
        /// <remarks>
        ///     高度の影響係数の計算には、（B. ホフマン-ウェレンホフ/H. モーリッツ　西修二郎訳，物理測地学，シュプリンガー・ジャパン，p.73，2006.8）を参考にしました。
        ///     
        ///     正規重力の計算式には、測地学会が編集している測地学WEB版 http://www.geod.jpn.org/web-text/part2/2-2/2-2-1-4.html を参考にしました。
        ///     誤差は0.1 μGalだそうです。
        ///     一応、国土地理院の http://vldb.gsi.go.jp/sokuchi/gravity/grv_jpn/gr_table.pl?103 と比較して正規重力値に0.01 mGal以内の誤差しかないことを確認済みです。
        /// </remarks>
        /// </summary>
        /// <param name="latitude">緯度[°]<para>単位に注意</para><para>化成緯度でも地心緯度でもない普通の緯度です。</para></param>
        /// <param name="ellipsoidHeight">楕円体高[m]</param>
        /// <returns>重力値[m/s2]<para>単位がGalではないことに注意</para></returns>
        public double GetGravity(double latitude, double ellipsoidHeight)
        {
            double lat = latitude * Math.PI / 180.0;
            double oblateness = this.datum.f;
            double m = this.datum.m;
            double a = this.datum.a;
            double ga = this.datum.NormalGravityAtEquator;

            double factor = 1 - 2 / a * (1 + oblateness + m - 2 * oblateness * Math.Pow(Math.Sin(lat), 2.0)) * ellipsoidHeight + 3 / Math.Pow(a, 2.0) * Math.Pow(ellipsoidHeight, 2.0);
            double normalGravity = ga * (1 + 0.0052790414 * Math.Pow(Math.Sin(lat), 2.0) + 0.0000232718 * Math.Pow(Math.Sin(lat), 4.0) + 0.0000001262 * Math.Pow(Math.Sin(lat), 6.0) + 0.0000000007 * Math.Pow(Math.Sin(lat), 8.0));
            return factor * normalGravity;
        }
        /// <summary>
        /// 正規重力値を返します
        /// <para>
        /// アルゴリズムはGetGravity(double latitude, double ellipsoidHeight)のXML解説をご参照ください。
        /// </para>
        /// </summary>
        /// <param name="latitude">緯度[°]　単位に注意</param>
        /// <returns>重力値[m/s2]<para>単位がGalではないことに注意</para></returns>
        public double GetGravity(double latitude)
        {
            return this.GetGravity(latitude, 0.0);
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public GravityBase()
        {
            this.datum = new T();
        }
        //protected i
    }
}
