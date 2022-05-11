using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimalWeight : MonoBehaviour
{
    private Animal mAnimal;
    private GameManager mGamemanager;
    private float mWeight;
    private string mAnimalName;
    private int mPlusFlag;

    // Start is called before the first frame update
    void Start()
    {
        mAnimalName = this.gameObject.name.Replace("(Clone)(Clone)","");
        mPlusFlag = 0;

        mGamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        mAnimal = GameObject.Find("GameStage/GameController").GetComponent<Animal>();
        mWeight = mAnimal.animals.Find(animal => mAnimalName == animal.name).weight;

         
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.GetComponent<ResetFlag>().collisionFlag == 1 && mPlusFlag == 0)
        {
            mGamemanager.playerWeight += mWeight;
            mPlusFlag = 1;
        }
    }

    public void minus()
    {
        mGamemanager.playerWeight -= mWeight;
    }
}
