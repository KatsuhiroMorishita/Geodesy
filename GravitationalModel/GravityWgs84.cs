/*************************************
 * GravityWgs84.cs
 * WGS84における重力モデルクラスです
 * 
 * 　開発者：K.Morishita Kumamoto-University Japan @ 2012.7
 * 　
 * 　開発履歴：
 * 　            2012/7/20   GRS80用のモデルを定義したので、せっかくなので作ってみました。
 * 　                        実質的な差は出ないと思いますが、その辺の実感を持つのに役立つかな？
 * ************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Geodesy.GeodeticDatum;

namespace Geodesy.GravitationalModel
{
    /// <summary>
    /// WGS84における重力モデルクラス
    /// <para>使用するパラメータはGeodesy.GeodeticDatum.Wgs84が継承しているパラメータになります。</para>
    /// </summary>
    public class GravityWgs84 : GravityBase<Wgs84>
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public GravityWgs84()
            :base()
        { 
        
        }
    }
}
