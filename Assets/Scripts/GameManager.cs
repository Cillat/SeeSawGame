using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum SceneFlag
    {
        Title,
        Playing,
        Finish,
        PreResult,
        Result
    }

    public SceneFlag sceneFlag;
    public float playerWeight;
    public float enemyWeight;
    public int minute;
    public int second;
    public int millSecond;
    public int gameFlag;

    private AudioManager mAudioManager;
    private GameObject mSeeSaw;
    private GameObject mPlayerBox;
    private GameObject mEnemyBox;
    private Text mResultTime;
    private static  float mPlayTime = 0f;
    private float mDifferenceWeight;
    private float mLeanGain;
    string mSecondString;
    string mMillSecondString;


    // Start is called before the first frame update
    void Start()
    {
        gameFlag = 0;
        minute = 0;
        second = 0;
        millSecond = 0;
        this.gameObject.GetComponent<AudioManager>().ChangeVolume(0.3f, 0.3f);
        AudioManager.Instance.PlayBGM("Main");

    }

    // Update is called once per frame
    void Update()
    {
        if (sceneFlag == SceneFlag.Playing && gameFlag == 0)
        {
            gameFlag = 1;
            minute = 0;
            second = 0;
            millSecond = 0;

            Timer = 0f;
            playerWeight = 0f;
            enemyWeight = 0f;
            mAudioManager = this.gameObject.GetComponent<AudioManager>();
            mSeeSaw = GameObject.Find("GameStage/SeeSawView/WholeSeeSaw/SeeSaw");
            mPlayerBox = GameObject.Find("GameStage/PlayerView/PlayerBoxes");
            mEnemyBox = GameObject.Find("GameStage/EnemyView/EnemyBoxes");

            mDifferenceWeight = 0f;
            mLeanGain = 0f;
        }

        if (sceneFlag == SceneFlag.Playing)
        {
            Timer += Time.deltaTime;

            mDifferenceWeight = (playerWeight - enemyWeight) * 100;
            mLeanGain = mDifferenceWeight / 150000f;

            if (mSeeSaw == null)
            {
                mSeeSaw = GameObject.Find("GameStage/SeeSawView/WholeSeeSaw/SeeSaw");
            }
            else
            {
                mSeeSaw.transform.Rotate(new Vector3(0f, 0f, mLeanGain));
            }

            if (mPlayerBox == null)
            {
                mPlayerBox = GameObject.Find("GameStage/PlayerView/PlayerBoxes");
            }
            else
            {
                mPlayerBox.transform.Rotate(new Vector3(-1 * mLeanGain, 0f, 0f));
            }

            if (mEnemyBox == null)
            {
                mEnemyBox = GameObject.Find("GameStage/EnemyView/EnemyBoxes");
            }
            else
            {
                mEnemyBox.transform.Rotate(new Vector3(0f, 0f, mLeanGain));
            }
        }

        else if (sceneFlag == SceneFlag.Finish)
        {
            mAudioManager.FadeOutBGM();
            AudioManager.Instance.PlaySE("Finish");

            minute = (int)Timer / 60;
            second = (int)Timer - minute * 60;
            millSecond = (int)((Timer - (minute * 60) - second) * 100);

            Debug.Log(minute);
            Debug.Log(second);
            Debug.Log(millSecond);

            if ( second  < 10 )
            {
                mSecondString = "0" + second.ToString();
            }
            else
            {
                mSecondString = second.ToString();
            }

            if ( millSecond < 10)
            {
                mMillSecondString = "0" + millSecond.ToString();
            }
            else
            {
                mMillSecondString = millSecond.ToString();
            }

            sceneFlag = SceneFlag.PreResult;
            Invoke("ResultSceneLoad", 3.0f);

        }

        else if (sceneFlag == SceneFlag.Result)
        {

            if (mResultTime == null)
            {
                mResultTime = GameObject.Find("Result/Canvas/FinishTime").GetComponent<Text>();
            }
            else
            {
                mResultTime.text = "Result" + " : " + minute.ToString() + ":" + mSecondString + ":" + mMillSecondString;
            }
        }

        
    }

    void ResultSceneLoad()
    {
        AudioManager.Instance.PlayBGM("Result");
        SceneManager.LoadScene("Result");
        sceneFlag = SceneFlag.Result;
    }

    public float Timer
    {
        get { return mPlayTime; }
        set { mPlayTime = value; }
    }



}
