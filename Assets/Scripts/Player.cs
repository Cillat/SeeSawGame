using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private GameManager gameManager;
    private int mSelectFlag;
    private int[] mAnimalNum;
    public GameObject[] playerGameObjects;
    private float mTime;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameStage/GameManager").GetComponent<GameManager>();
        mSelectFlag = 0;
        mAnimalNum = new int[3];
        playerGameObjects = new GameObject[13];
        mTime = 0f;

        playerGameObjects[0] = GameObject.Find("PlayerSelectAnimals/PlayerRat");
        playerGameObjects[1] = GameObject.Find("PlayerSelectAnimals/PlayerRabbit");
        playerGameObjects[2] = GameObject.Find("PlayerSelectAnimals/PlayerRooster");
        playerGameObjects[3] = GameObject.Find("PlayerSelectAnimals/PlayerCrane");
        playerGameObjects[4] = GameObject.Find("PlayerSelectAnimals/PlayerSnake");
        playerGameObjects[5] = GameObject.Find("PlayerSelectAnimals/PlayerDog");
        playerGameObjects[6] = GameObject.Find("PlayerSelectAnimals/PlayerMonkey");
        playerGameObjects[7] = GameObject.Find("PlayerSelectAnimals/PlayerGoat");
        playerGameObjects[8] = GameObject.Find("PlayerSelectAnimals/PlayerPig");
        playerGameObjects[9] = GameObject.Find("PlayerSelectAnimals/PlayerOx");
        playerGameObjects[10] = GameObject.Find("PlayerSelectAnimals/PlayerHorse");
        playerGameObjects[11] = GameObject.Find("PlayerSelectAnimals/PlayerTiger");
        playerGameObjects[12] = GameObject.Find("PlayerSelectAnimals/PlayerDragon");
    }

    // Update is called once per frame
    void Update()
    {
        if(mSelectFlag == 0)
        {
            mAnimalNum[0] = Random.Range(0, 13);
            mAnimalNum[1] = Random.Range(0, 13);
            mAnimalNum[2] = Random.Range(0, 13);
            mSelectFlag = 1;

            Debug.Log(mAnimalNum[0] + "and" + mAnimalNum[1] + "and"  + mAnimalNum[2]);
            Debug.Log(playerGameObjects[mAnimalNum[0]] + "and" + playerGameObjects[mAnimalNum[1]] + "and" + playerGameObjects[mAnimalNum[2]]);

            Instantiate(playerGameObjects[mAnimalNum[0]], new Vector3(-97f, 0.7f, 5.3f) , Quaternion.identity);
            Instantiate(playerGameObjects[mAnimalNum[1]], new Vector3(-100f, 0.7f, 5.3f), Quaternion.identity);
            Instantiate(playerGameObjects[mAnimalNum[2]], new Vector3(-103f, 0.7f, 5.3f), Quaternion.identity);
        }

        mTime += Time.deltaTime;
        if (mTime > 5f)
        {
            mTime = 0f;
            mSelectFlag = 0;
        }

    }
}
