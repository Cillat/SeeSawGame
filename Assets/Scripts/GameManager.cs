using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum SceneFlag
    {
        Playing,
        Finish,
        PreResult,
        Result
    }

    public SceneFlag sceneFlag;
    public float playerWeight;
    public float enemyWeight;

    private AudioManager mAudioManager;
    private GameObject mSeeSaw;
    private GameObject mPlayerBox;
    private GameObject mEnemyBox;
    private static  float mPlayTime = 0f;
    private float mDifferenceWeight;
    private float mLeanGain;
    private float finishTime;

    private int mFinishSound;

    // Start is called before the first frame update
    void Start()
    {
        Timer = 0f;
        sceneFlag = SceneFlag.Playing;
        playerWeight = 0f;
        enemyWeight = 0f;
        mAudioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        mSeeSaw = GameObject.Find("GameStage/SeeSawView/WholeSeeSaw/SeeSaw");
        mPlayerBox = GameObject.Find("GameStage/PlayerView/PlayerBoxes");
        mEnemyBox = GameObject.Find("GameStage/EnemyView/EnemyBoxes");
        mDifferenceWeight = 0f;
        mLeanGain = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneFlag == SceneFlag.Playing)
        {
            Timer += Time.deltaTime;

            mDifferenceWeight = (playerWeight - enemyWeight) * 100;
            mLeanGain = mDifferenceWeight / 150000f;

            mSeeSaw.transform.Rotate(new Vector3(0f, 0f, mLeanGain));
            mPlayerBox.transform.Rotate(new Vector3(-1 * mLeanGain, 0f, 0f));
            mEnemyBox.transform.Rotate(new Vector3(0f, 0f, mLeanGain));

        }

        else if(sceneFlag == SceneFlag.Finish)
        {
            finishTime = Timer;

            mAudioManager.FadeOutBGM();
            AudioManager.Instance.PlaySE("Finish");


            sceneFlag = SceneFlag.PreResult;
            Invoke("ResultSceneLoad", 3.0f);

        }

        
    }

    void ResultSceneLoad()
    {
        AudioManager.Instance.PlayBGM("Result");
        sceneFlag = SceneFlag.Result;
    }

    public float Timer
    {
        get { return mPlayTime; }
        set { mPlayTime = value; }
    }



}
