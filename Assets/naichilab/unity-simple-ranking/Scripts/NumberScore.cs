using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace naichilab
{
    /// <summary>
    /// 数値型スコア
    /// </summary>
    public class NumberScore : IScore
    {
        //double →　floatに変更
        private double score;
        private string format;


        public NumberScore(double score, string format = "")
        {
            this.score = score;
            this.format = format;
        }

        public ScoreType Type
        {
            get { return ScoreType.Number; }
        }

        public string TextForDisplay
        {
            get
            {
                if (!string.IsNullOrEmpty(format))
                {
                    return score.ToString(format);
                }
                else
                {   //変更点
                    return score.ToString("F2");
                    //F2を追加
                }
            }
        }

        public string TextForSave
        {
            get { return score.ToString(); }
        }

        public double Value
        {
            get { return score; }
        }
    }
}