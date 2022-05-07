using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{

    public  List<PlayerAnimals> playerAnimals;
    public  List<EnemyAnimals> enemyAnimals;
    private GameObject[] playerAnimalNames;
    private GameObject[] enemyAnimalNames;
    private PlayerAnimals registerPlayerAnimals;
    private EnemyAnimals registerEnemyAnimals;
    private float incrementCount;
    
    // Start is called before the first frame update
    void Start()
    {
        playerAnimals = new List<PlayerAnimals>();
        enemyAnimals = new List<EnemyAnimals>();
        playerAnimalNames = new GameObject[13];
        enemyAnimalNames = new GameObject[13];

        registerPlayerAnimals = new PlayerAnimals();
        registerEnemyAnimals = new EnemyAnimals();

        incrementCount = 1f;

        playerAnimalNames[0] = GameObject.Find("PlayerAnimals/PlayerRat");
        playerAnimalNames[1] = GameObject.Find("PlayerAnimals/PlayerRabbit");
        playerAnimalNames[2] = GameObject.Find("PlayerAnimals/PlayerRooster");
        playerAnimalNames[3] = GameObject.Find("PlayerAnimals/PlayerCrane");
        playerAnimalNames[4] = GameObject.Find("PlayerAnimals/PlayerSnake");
        playerAnimalNames[5] = GameObject.Find("PlayerAnimals/PlayerDog");
        playerAnimalNames[6] = GameObject.Find("PlayerAnimals/PlayerMonkey");
        playerAnimalNames[7] = GameObject.Find("PlayerAnimals/PlayerGoat");
        playerAnimalNames[8] = GameObject.Find("PlayerAnimals/PlayerPig");
        playerAnimalNames[9] = GameObject.Find("PlayerAnimals/PlayerOx");
        playerAnimalNames[10] = GameObject.Find("PlayerAnimals/PlayerHorse");
        playerAnimalNames[11] = GameObject.Find("PlayerAnimals/PlayerTiger");
        playerAnimalNames[12] = GameObject.Find("PlayerAnimals/PlayerDragon");

        enemyAnimalNames[0] = GameObject.Find("EnemyAnimals/Rat");
        enemyAnimalNames[1] = GameObject.Find("EnemyAnimals/Rabbit");
        enemyAnimalNames[2] = GameObject.Find("EnemyAnimals/Rooster");
        enemyAnimalNames[3] = GameObject.Find("EnemyAnimals/Crane");
        enemyAnimalNames[4] = GameObject.Find("EnemyAnimals/Snake");
        enemyAnimalNames[5] = GameObject.Find("EnemyAnimals/Dog");
        enemyAnimalNames[6] = GameObject.Find("EnemyAnimals/Monkey");
        enemyAnimalNames[7] = GameObject.Find("EnemyAnimals/Goat");
        enemyAnimalNames[8] = GameObject.Find("EnemyAnimals/Pig");
        enemyAnimalNames[9] = GameObject.Find("EnemyAnimals/Ox");
        enemyAnimalNames[10] = GameObject.Find("EnemyAnimals/Horse");
        enemyAnimalNames[11] = GameObject.Find("EnemyAnimals/Tiger");
        enemyAnimalNames[12] = GameObject.Find("EnemyAnimals/Dragon");


        for (int i = 0; i < 13; i++)
        {
            registerPlayerAnimals.playerId = i;
            registerPlayerAnimals.playerAnimalName = playerAnimalNames[i];
            registerPlayerAnimals.playerAnimalWeight = incrementCount;

            registerEnemyAnimals.enemyId = i;
            registerEnemyAnimals.enemyAnimalName = enemyAnimalNames[i];
            registerEnemyAnimals.enemyWeight = incrementCount;

            incrementCount += 1f;

            playerAnimals.Add(registerPlayerAnimals);
            enemyAnimals.Add(registerEnemyAnimals);

        }
        

        Debug.Log(playerAnimals[5].playerAnimalName);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public struct PlayerAnimals
    {
        public int playerId;
        public GameObject playerAnimalName;
        public float playerAnimalWeight;
    }

    public struct EnemyAnimals
    {
        public int enemyId;
        public GameObject enemyAnimalName;
        public float enemyWeight;
    }
}
