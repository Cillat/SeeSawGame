using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum SceneFlag
    {
        BeforeStart,
        PreStart,
        Start,
        Playing,
        Finish,
        Result
    }

    public SceneFlag sceneFlag;
    public float playerWeight;
    public float enemyWeight;
    static float mPlayTime = 0f;
    private GameObject mSeeSaw;
    private float mDifferenceWeight;
    private float mLeanGain;
    private float finishTime;
    private float mTime;

    // Start is called before the first frame update
    void Start()
    {
        sceneFlag = SceneFlag.Playing;
        playerWeight = 0f;
        enemyWeight = 0f;
        mSeeSaw = GameObject.Find("GameStage/SeeSawView/WholeSeeSaw/SeeSaw");
        mTime = 0;
        mDifferenceWeight = 0f;
        mLeanGain = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        mTime += Time.deltaTime;
        mDifferenceWeight = (playerWeight - enemyWeight) * 1000;
        mLeanGain = mDifferenceWeight / 10000000f;

        mSeeSaw.transform.Rotate(new Vector3(0f, 0f, mLeanGain));


        if (mTime > 5f)
        {
            mTime = 0f;
            Debug.Log("PlayerWeightSum = " + playerWeight);
            Debug.Log("EnemyWeightSum = " + enemyWeight);
        }

        if (sceneFlag == SceneFlag.PreStart)
        {
            Timer = 0f;
        }
        else if (sceneFlag == SceneFlag.Playing)
        {
            Timer += Time.deltaTime;
        }
        else if(sceneFlag == SceneFlag.Finish)
        {
            finishTime = Timer;
            Debug.Log("Finish!!");
        }

        
    }


    public float Timer
    {
        get { return mPlayTime; }
        set { mPlayTime = value; }
    }



}
