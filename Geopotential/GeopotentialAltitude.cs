/*************************************
 * GeopotentialAltitude.cs
 * ジオポテンシャル高度と楕円体高の相互変換を目的としたクラス
 * 
 * 　開発者：K.Morishita Kumamoto-University Japan @ 2012.7
 * 　
 * 　開発履歴：
 * 　            2012/7/19   整備開始。
 * ************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Geodesy.GravitationalModel;

namespace Geodesy.Geopotential
{
    /// <summary>
    /// ジオポテンシャル高度と楕円体高の相互変換クラス
    /// interconversion
    /// </summary>
    /// <typeparam name="T">重力モデル</typeparam>
    public class GeopotentialAltitude<T> 
        where T: IGravity, new()
    {
        /* メンバ変数 ********************************************/
        /// <summary>
        /// 重力モデル
        /// </summary>
        private T gravityModel;
        /// <summary>
        /// heightTableへ格納しているデータの最小楕円体高[m]
        /// </summary>
        private double minEllipsoidHeight;
        /// <summary>
        /// heightTableへ格納しているデータの最大楕円体高[m]
        /// </summary>
        private double maxEllipsoidHeight;
        /// <summary>
        /// 積分ステップ
        /// </summary>
        private double integralStep;
        /// <summary>
        /// 緯度[deg]
        /// <para>単位に注意してください。</para>
        /// </summary>
        public double latitude;
        /// <summary>
        /// ジオポテンシャル高度の計算結果を記憶しておく
        /// <para>要求値が楕円体面より下ってこともあり得るので単純な配列やListでは扱いづらい+デバッグがやりにくいので、構造体を使う。</para>
        /// </summary>
        private List<EllipsoidAndGeopotentialHeight> heightTable;
        /* プロパティ ********************************************/
        /// <summary>
        /// 緯度[deg]
        /// <para>単位に注意</para>
        /// <para>化成緯度でも地心緯度でもない普通の緯度です。</para>
        /// <para>異なる値をセットした場合、内部変数を一度リセットしますので若干時間がかかります。</para>
        /// </summary>
        public double Latitude
        {
            get
            {
                return this.latitude;
            }
            set
            {
                if (this.latitude != value) this.Init(); // 再計算を指示する
                this.latitude = value;
            }
        }
        /* メソッド ********************************************/
        /// <summary>
        /// heightTableをセットします
        /// <para>呼び出す前に、メンバ変数へのセットを済ませておいてください。</para>
        /// </summary>
        private void Init()
        {
            this.heightTable.Clear();
            double height = this.minEllipsoidHeight;
            double normalGravity = this.gravityModel.GetGravity(this.latitude);

            while (height < this.maxEllipsoidHeight)
            {

                height += integralStep;
            }
            return;
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="latitude">緯度[deg]<para>単位に注意</para><para>化成緯度でも地心緯度でもない普通の緯度です。</para></param>
        /// <param name="maxEllipsoidHeight">利用予定の最大楕円体高[m]<para>途中で拡張もされますが、予め利用予定高度をセットしておいた方が高速で動作します。</para></param>
        /// <param name="integralStep">積分ステップ</param>
        public GeopotentialAltitude(double latitude, double maxEllipsoidHeight, double integralStep = 100.0)
        {
            if (integralStep <= 0.0) throw new ArgumentException("GeopotentialAltitudeクラスのコンストラクタにおいてエラーがスローされました。積分ステップは整数として下さい。");
            
            this.gravityModel = new T();
            this.maxEllipsoidHeight = maxEllipsoidHeight;
            this.minEllipsoidHeight = 0;
            this.integralStep = integralStep;
            this.heightTable = new List<EllipsoidAndGeopotentialHeight>();
            this.Init();
        }
    }
}
