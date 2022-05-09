using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTime : MonoBehaviour
{
    public float resultTime;

    private GameManager mGameManager;
    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(gameObject);
        mGameManager = GameObject.Find("GameStage/GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(mGameManager.sceneFlag == GameManager.SceneFlag.Result)
        {
            resultTime = mGameManager.finishTime;
        }
    }
}
