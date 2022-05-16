using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultRanking : MonoBehaviour
{
    private GameManager mGameManager;

    void Start()
    {
        mGameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        var timeScore = new System.TimeSpan(0, 0, mGameManager.minute, mGameManager.second, mGameManager.millSecond);
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(timeScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
