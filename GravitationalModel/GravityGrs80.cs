/*************************************
 * GravityGrs80.cs
 * GRS80における重力モデルクラスです
 * 
 * 　開発者：K.Morishita Kumamoto-University Japan @ 2012.7
 * 　
 * 　開発履歴：
 * 　            2011/10/14  整備開始。手始めに、 GetGravity()を整備
 * 　            2012/7/18   クラス名をGravityよりGravityGrs80へ変更し、名前空間もGeodesyからGeodesy.GravitationalModelへ変更した。
 * 　            2012/7/19   楕円体高を考慮するメソッドを追加
 * ************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Geodesy.GeodeticDatum;

namespace Geodesy.GravitationalModel
{
    /// <summary>
    /// GRS80(Geodetic Reference System 1980：GRS80)における重力モデルクラス
    /// </summary>
    public class GravityGrs80 : GravityBase<Grs80>
    {
        /*----------- メソッド -----------------*/
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public GravityGrs80()
            :base()
        { 
        
        }
    }
}
