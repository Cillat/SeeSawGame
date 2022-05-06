using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimalWeight : MonoBehaviour
{
    private GameObject mAnimalName;
    private Player mPlayer;
    private GameManager mGamemanager;
    private float mAnimalWeight;

    // Start is called before the first frame update
    void Start()
    {
        mAnimalName = this.gameObject;
        mPlayer = GameObject.Find("GameStage/GameManager").GetComponent<Player>();
        mGamemanager = GameObject.Find("GameStage/GameManager").GetComponent<GameManager>();
        mAnimalWeight = mPlayer.dicPlayerGameObjects[mAnimalName];

        mGamemanager.playerWeight += mAnimalWeight;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<DestroyAnimal>().destroyFlag == 1)
        {
            mGamemanager.playerWeight -= mAnimalWeight; 
        }
    }
}
