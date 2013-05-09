using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geodesy.Geopotential
{
    /// <summary>
    /// 楕円体高とジオポテンシャル高度をセットする構造体
    /// <para>GeopotentialAltitudeクラスのみでの利用を想定しており、本構造体自体には矛盾の検出などの仕組みは実装されていないことにご注意ください。</para>
    /// </summary>
    internal struct EllipsoidAndGeopotentialHeight : System.IComparable, System.IComparable<EllipsoidAndGeopotentialHeight>
    {
        /* プロパティ *******************************/
        /// <summary>
        /// 楕円体高[m]
        /// </summary>
        public double EllipsoidHeight
        {
            get;
            private set;
        }
        /// <summary>
        /// ジオポテンシャル高度[m]
        /// </summary>
        public double GeopotentialHeight
        {
            get;
            private set;
        }
        /* 演算子系 *******************************/
        /// <summary>
        /// 比較メソッド
        /// <para>楕円体高の過多によって判定します。</para>
        /// </summary>
        /// <param name="other">比較対象</param>
        /// <returns>自分自身がotherより小さいときはマイナスの数、大きいときはプラスの数、同じときは0を返す</returns>
        public int CompareTo(EllipsoidAndGeopotentialHeight other)
        {
            // EllipsoidHeightを比較する
            return this.EllipsoidHeight.CompareTo(other.EllipsoidHeight);
        }
        /// <summary>
        /// 比較メソッド
        /// <para>楕円体高の過多によって判定します。</para>
        /// </summary>
        /// <param name="obj">比較対象</param>
        /// <returns>自分自身がotherより小さいときはマイナスの数、大きいときはプラスの数、同じときは0を返す</returns>
        public int CompareTo(object obj)
        {
            //nullより大きい
            if (obj == null)
            {
                return 1;
            }

            //違う型とは比較できない
            if (this.GetType() != obj.GetType())
            {
                throw new ArgumentException("別の型とは比較できません。", "obj");
            }

            return this.CompareTo((EllipsoidAndGeopotentialHeight)obj);
        }
        /* メソッド *******************************/
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="ellipsoidHeight">楕円体高[m]</param>
        /// <param name="geopotentialHeight">ジオポテンシャル高度[m]</param>
        public EllipsoidAndGeopotentialHeight(double ellipsoidHeight, double geopotentialHeight)
            :this()
        {
            this.EllipsoidHeight = ellipsoidHeight;
            this.GeopotentialHeight = geopotentialHeight;
        }
    }
}
