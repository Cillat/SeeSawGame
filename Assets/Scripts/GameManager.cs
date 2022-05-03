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
    static float mPlayTime = 0f;
    private float finishTime;

    // Start is called before the first frame update
    void Start()
    {
        sceneFlag = SceneFlag.Playing;
    }

    // Update is called once per frame
    void Update()
    {
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

        //Debug.Log(Timer);
    }


    public float Timer
    {
        get { return mPlayTime; }
        set { mPlayTime = value; }
    }



}
