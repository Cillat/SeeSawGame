using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{

    private GameManager gameManager;


    public float timeSpan;

    private float mTime;
    private int mRandomNumber;
    private Vector3 mRandomPosition;
    private Vector3 mRandomAngle;
    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);

        gameManager = GameObject.Find("GameStage/GameManager").GetComponent<GameManager>();
        mTime = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        mTime += Time.deltaTime;

        if(mTime > timeSpan)
        {
            mTime = 0f;
            mRandomNumber = Random.Range(0, 13);
            mRandomPosition = new Vector3(Random.Range(96f, 102f), 13f, Random.Range(0f, 6.5f)-3f);
            mRandomAngle = new Vector3(Random.Range(0f, 180f), Random.Range(0f, 180f), Random.Range(0f, 180f));
            Instantiate(gameManager.gameObjects[mRandomNumber], mRandomPosition, Quaternion.Euler(mRandomAngle));

        }

    }
}
