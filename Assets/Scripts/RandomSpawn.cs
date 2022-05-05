using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{

    private GameManager gameManager;
    private GameObject[] gameObjects;

    public float timeSpan;

    private float mTime;
    private int mRandomNumber;
    private Vector3 mRandomPosition;
    private Vector3 mRandomAngle;
    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        mTime = 0f;
        gameObjects = new GameObject[13];

        gameObjects[0] = GameObject.Find("Animals/Rat");
        gameObjects[1] = GameObject.Find("Animals/Rabbit");
        gameObjects[2] = GameObject.Find("Animals/Rooster");
        gameObjects[3] = GameObject.Find("Animals/Crane");
        gameObjects[4] = GameObject.Find("Animals/Snake");
        gameObjects[5] = GameObject.Find("Animals/Dog");
        gameObjects[6] = GameObject.Find("Animals/Monkey");
        gameObjects[7] = GameObject.Find("Animals/Goat");
        gameObjects[8] = GameObject.Find("Animals/pig");
        gameObjects[9] = GameObject.Find("Animals/Ox");
        gameObjects[10] = GameObject.Find("Animals/Horse");
        gameObjects[11] = GameObject.Find("Animals/Tiger");
        gameObjects[12] = GameObject.Find("Animals/Dragon");
    }

    // Update is called once per frame
    void Update()
    {
        mTime += Time.deltaTime;

        if(mTime > timeSpan)
        {
            mTime = 0f;
            mRandomNumber = Random.Range(1, 13);
            mRandomPosition = new Vector3(Random.Range(96f, 102f), 13f, Random.Range(0f, 6.5f)-3f);
            mRandomAngle = new Vector3(Random.Range(0f, 180f), Random.Range(0f, 180f), Random.Range(0f, 180f));
            Instantiate(gameObjects[mRandomNumber], mRandomPosition, Quaternion.Euler(mRandomAngle));

        }

    }
}
