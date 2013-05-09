/**************************************************************************
 * Wgs84.cs
 * WGS測地系パラメータ for C#
 * 
 * 開発者　：森下功啓（K.Morhista Kumamoto-University）
 * 開発履歴：
 *          2012/7/3    測地系の拡張に備えて、新設した。
 *                      都合に合わせて継承するクラスを変えることとする。
 *          2012/7/20   名前空間をGNSS.GeodeticDatumからGeodesy.GeodeticDatumへ変更
 * ***********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geodesy.GeodeticDatum
{
    /// <summary>
    /// WGS84測地系を表現するクラス
    /// <para>デフォルトではG873のパラメータを使用します。</para>
    /// </summary>
    public class Wgs84 : Wgs84G873
    {
        /// <summary>
        /// Wgs84クラスのコンストラクタ
        /// </summary>
        public Wgs84()
            :base()
        { 
        
        }
    }
}
