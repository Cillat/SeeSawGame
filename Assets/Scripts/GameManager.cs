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


    public GameObject[] gameObjects;
    public SceneFlag sceneFlag;
    static float mPlayTime = 0f;
    private float finishTime;

    // Start is called before the first frame update
    void Start()
    {
        sceneFlag = SceneFlag.Playing;

        gameObjects = new GameObject[13];

        gameObjects[0] = GameObject.Find("Animals/Rat");
        gameObjects[1] = GameObject.Find("Animals/Rabbit");
        gameObjects[2] = GameObject.Find("Animals/Rooster");
        gameObjects[3] = GameObject.Find("Animals/Crane");
        gameObjects[4] = GameObject.Find("Animals/Snake");
        gameObjects[5] = GameObject.Find("Animals/Dog");
        gameObjects[6] = GameObject.Find("Animals/Monkey");
        gameObjects[7] = GameObject.Find("Animals/Goat");
        gameObjects[8] = GameObject.Find("Animals/Pig");
        gameObjects[9] = GameObject.Find("Animals/Ox");
        gameObjects[10] = GameObject.Find("Animals/Horse");
        gameObjects[11] = GameObject.Find("Animals/Tiger");
        gameObjects[12] = GameObject.Find("Animals/Dragon");
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
