using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{

    public  List<Animals> animals;
    private GameObject[] mAnimals;
    private Animals mRegisterAnimals;
    private float mIncrementCount;
    
    // Start is called before the first frame update
    void Start()
    {
        animals = new List<Animals>();
        mAnimals = new GameObject[13];
        mRegisterAnimals = new Animals();
        mIncrementCount = 1f;

        mAnimals[0] = GameObject.Find("GameStage/Animals/Rat");
        mAnimals[1] = GameObject.Find("GameStage/Animals/Rabbit");
        mAnimals[2] = GameObject.Find("GameStage/Animals/Rooster");
        mAnimals[3] = GameObject.Find("GameStage/Animals/Crane");
        mAnimals[4] = GameObject.Find("GameStage/Animals/Snake");
        mAnimals[5] = GameObject.Find("GameStage/Animals/Dog");
        mAnimals[6] = GameObject.Find("GameStage/Animals/Monkey");
        mAnimals[7] = GameObject.Find("GameStage/Animals/Goat");
        mAnimals[8] = GameObject.Find("GameStage/Animals/Pig");
        mAnimals[9] = GameObject.Find("GameStage/Animals/Ox");
        mAnimals[10] = GameObject.Find("GameStage/Animals/Horse");
        mAnimals[11] = GameObject.Find("GameStage/Animals/Tiger");
        mAnimals[12] = GameObject.Find("GameStage/Animals/Dragon");


        for (int i = 0; i < 13; i++)
        {
            mRegisterAnimals.id = i;
            mRegisterAnimals.name = mAnimals[i].name;
            mRegisterAnimals.weight = mIncrementCount;
            mRegisterAnimals.prefab = mAnimals[i]; 

            mIncrementCount += 1f;

            animals.Add(mRegisterAnimals);


        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public struct Animals
    {
        public int id;
        public string name;
        public float weight;
        public GameObject prefab;
    }
}
