using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{



    public float timeSpan;

    private Animal mAnimal;
    private GameObject mRandomSpawn;
    private float mTime;
    private int mCount;
    private int mRandomNumber;
    private Vector3 mRandomPosition;
    private Vector3 mRandomAngle;
    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);

        mAnimal = GameObject.Find("GameStage/GameController").GetComponent<Animal>();
        timeSpan = 5f;
        mTime = 0f;
        mCount = 0;

    }

    // Update is called once per frame
    void Update()
    {
        mTime += Time.deltaTime;

        if(mTime > timeSpan)
        {
            mTime = 0f;
            mRandomNumber = Random.Range(0, 13);
            mRandomPosition = new Vector3(Random.Range(97f, 102f), 13f, Random.Range(0f, 6.5f)-2.5f);
            mRandomAngle = new Vector3(Random.Range(0f, 180f), Random.Range(0f, 180f), Random.Range(0f, 180f));
            mRandomSpawn =  Instantiate(mAnimal.animals[mRandomNumber].prefab, mRandomPosition, Quaternion.Euler(mRandomAngle));

            mRandomSpawn.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
            mRandomSpawn.AddComponent<Rigidbody>();
            mRandomSpawn.AddComponent<DestroyEnemyAnimal>();
            mRandomSpawn.AddComponent<EnemyAnimalWeight>();

            mCount += 1;

            if (mCount > 4)
            {
                if(timeSpan > 1f)
                {
                    timeSpan -= 0.5f;
                    mCount = 0;
                }
            }

        }

    }
}
