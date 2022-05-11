using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimalWeight : MonoBehaviour
{
    private Animal mAnimal;
    private GameManager mGamemanager;
    private float mWeight;
    private string mAnimalName;
    private int mPlusFlag;

    // Start is called before the first frame update
    void Start()
    {
        mAnimalName = this.gameObject.name.Replace("(Clone)", "");
        mPlusFlag = 0;

        mGamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        mAnimal = GameObject.Find("GameStage/GameController").GetComponent<Animal>();
        mWeight = mAnimal.animals.Find(animal => mAnimalName == animal.name).weight;


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void minus()
    {
        mGamemanager.enemyWeight -= mWeight;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (mPlusFlag == 0)
        {
            mPlusFlag = 1;
            mGamemanager.enemyWeight += mWeight;
        }
    }
}
