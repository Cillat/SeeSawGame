using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultRanking : MonoBehaviour
{
    private GameManager mGameManager;
    private int mMinute;
    private int mSecond;
    private int mMillSecond;

    void Start()
    {
        mGameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        mMinute = (int)mGameManager.Timer / 60;
        mSecond = (int)mGameManager.Timer - mMinute * 60;
        mMillSecond = (int)(mGameManager.Timer - Mathf.Floor(mGameManager.Timer)) * 100;

        var timeScore = new System.TimeSpan(0, 0, mMinute, mSecond, mMillSecond);
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(timeScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
