using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultRanking : MonoBehaviour
{
    private GameManager mGameManager;
    // Start is called before the first frame update
    void Start()
    {
        mGameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //var millsec = mGameManager.Timer;
        //var timeScore = new System.TimeSpan(0, 0, 0, 0, millsec);
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(1555555555555);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
