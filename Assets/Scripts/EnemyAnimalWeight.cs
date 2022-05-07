using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimalWeight : MonoBehaviour
{
    private Animal mAnimal;
    private GameManager mGamemanager;
    private float mWeight;
    private string mAnimalName;

    // Start is called before the first frame update
    void Start()
    {
        mAnimalName = this.gameObject.name.Replace("(Clone)", "");

        mGamemanager = GameObject.Find("GameStage/GameManager").GetComponent<GameManager>();
        mAnimal = GameObject.Find("GameStage/GameManager").GetComponent<Animal>();
        mWeight = mAnimal.animals.Find(animal => mAnimalName == animal.name).weight;

        mGamemanager.playerWeight += mWeight;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void minus()
    {
        mGamemanager.playerWeight -= mWeight;
    }
}
