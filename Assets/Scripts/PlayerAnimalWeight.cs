using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAnimalWeight : MonoBehaviour
{
    private GameObject mAnimalName;
    private Animal mAnimal;
    private GameManager mGamemanager;
    private float mWeight;
    private int mPlusFlag;

    // Start is called before the first frame update
    void Start()
    {
        mPlusFlag = 0;
        mAnimalName = this.gameObject;
        mAnimalName.name.Replace("(Clone)(Clone)", " ");
        
        mGamemanager = GameObject.Find("GameStage/GameManager").GetComponent<GameManager>();
        mAnimal = GameObject.Find("GameStage/GameManager").GetComponent<Animal>();
        mWeight = mAnimal.playerAnimals.Find(animal => mAnimalName == animal.playerAnimalName).playerAnimalWeight;

        mGamemanager.playerWeight += mWeight;

        Debug.Log("GameObject = " + mAnimalName);
        Debug.Log("Name =" + mAnimalName.name);
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(mPlayerAnimals.playerAnimalWeight);
        //Debug.Log(mPlayerAnimals.playerAnimalWeight);
        if (this.gameObject.GetComponent<DestroyAnimal>().destroyFlag == 1)
        {
            mGamemanager.playerWeight -= mWeight; 
        }
    }
}
