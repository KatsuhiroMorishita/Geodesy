/**************************************************************************
 * Datum.cs
 * 測地系を表すための列挙体 for C#
 * 
 * [開発者]　：森下功啓（K.Morhista Kumamoto-University @ 2012.7）
 * 
 * [開発履歴]：
 *              2012/4/24   整備開始
 *              2012/7/20   名前空間をGNSS.GeodeticDatumからGeodesy.GeodeticDatumへ変更
 *                          GRS80を追加
 *                          現時点では測地系というより準拠楕円体の定義しかしていないので、今後、構造が少し変更になると思う。
 * ***********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geodesy.GeodeticDatum
{
    /// <summary>
    /// 測地系
    /// </summary>
    public enum Datum 
    {
        /// <summary>
        /// WGS84測地系
        /// </summary>
        WGS84,
        /// <summary>
        /// GRS80測地系
        /// </summary>
        GRS80,
        /// <summary>
        /// 未知の座標系
        /// </summary>
        Unknown
    }
}
