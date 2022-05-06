using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAnimalWeight : MonoBehaviour
{
    private GameObject mAnimalName;
    private Animal mAnimal;
    private Animal.PlayerAnimals mPlayerAnimals;
    private GameManager mGamemanager;
     
    
    private float weight;

    // Start is called before the first frame update
    void Start()
    {
        mAnimalName = this.gameObject;
        
        mGamemanager = GameObject.Find("GameStage/GameManager").GetComponent<GameManager>();
        mAnimal = GameObject.Find("GameStage/GameManager").GetComponent<Animal>();
        mPlayerAnimals = mAnimal.playerAnimals.Find(animal => mAnimalName == animal.playerAnimalName);

        mGamemanager.playerWeight += mPlayerAnimals.playerAnimalWeight;
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(mPlayerAnimals.playerAnimalWeight);
        //Debug.Log(mPlayerAnimals.playerAnimalWeight);
        if (this.gameObject.GetComponent<DestroyAnimal>().destroyFlag == 1)
        {
            mGamemanager.playerWeight -= mPlayerAnimals.playerAnimalWeight; 
        }
    }
}
