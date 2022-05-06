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

        playerAnimalNames[0] = GameObject.Find("PlayerSelectAnimals/PlayerRat");
        playerAnimalNames[1] = GameObject.Find("PlayerSelectAnimals/PlayerRabbit");
        playerAnimalNames[2] = GameObject.Find("PlayerSelectAnimals/PlayerRooster");
        playerAnimalNames[3] = GameObject.Find("PlayerSelectAnimals/PlayerCrane");
        playerAnimalNames[4] = GameObject.Find("PlayerSelectAnimals/PlayerSnake");
        playerAnimalNames[5] = GameObject.Find("PlayerSelectAnimals/PlayerDog");
        playerAnimalNames[6] = GameObject.Find("PlayerSelectAnimals/PlayerMonkey");
        playerAnimalNames[7] = GameObject.Find("PlayerSelectAnimals/PlayerGoat");
        playerAnimalNames[8] = GameObject.Find("PlayerSelectAnimals/PlayerPig");
        playerAnimalNames[9] = GameObject.Find("PlayerSelectAnimals/PlayerOx");
        playerAnimalNames[10] = GameObject.Find("PlayerSelectAnimals/PlayerHorse");
        playerAnimalNames[11] = GameObject.Find("PlayerSelectAnimals/PlayerTiger");
        playerAnimalNames[12] = GameObject.Find("PlayerSelectAnimals/PlayerDragon");

        enemyAnimalNames[0] = GameObject.Find("Animals/Rat");
        enemyAnimalNames[1] = GameObject.Find("Animals/Rabbit");
        enemyAnimalNames[2] = GameObject.Find("Animals/Rooster");
        enemyAnimalNames[3] = GameObject.Find("Animals/Crane");
        enemyAnimalNames[4] = GameObject.Find("Animals/Snake");
        enemyAnimalNames[5] = GameObject.Find("Animals/Dog");
        enemyAnimalNames[6] = GameObject.Find("Animals/Monkey");
        enemyAnimalNames[7] = GameObject.Find("Animals/Goat");
        enemyAnimalNames[8] = GameObject.Find("Animals/Pig");
        enemyAnimalNames[9] = GameObject.Find("Animals/Ox");
        enemyAnimalNames[10] = GameObject.Find("Animals/Horse");
        enemyAnimalNames[11] = GameObject.Find("Animals/Tiger");
        enemyAnimalNames[12] = GameObject.Find("Animals/Dragon");


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
