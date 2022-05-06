using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private GameManager gameManager;
    private GameObject mPlayerChoice;
    private Camera mCamera;
    private Animal mAnimal;
    private int[] mAnimalNum;
    private float mMouseWheelScroll;
    private float mMouseDepth;
    private Vector3 mMousePos;

    public int spawnFlag;
    public int selectFlag;
    public Dictionary<int, Dictionary<GameObject,float>> dicPlayerGameObjects;
    public GameObject[] selectAnimals;
    public GameObject[] mDicAnimalKeys;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameStage/GameManager").GetComponent<GameManager>();
        mAnimal = GameObject.Find("GameStage/GameManager").GetComponent<Animal>();
        mCamera = GameObject.Find("GameStage/PlayerView/PlayerCamera").GetComponent<Camera>();
        mPlayerChoice = null;
        mAnimalNum = new int[3];
        selectAnimals = new GameObject[3];
        mMouseDepth = 16.5f;
        spawnFlag = 0;
        selectFlag = 0;


        //dicPlayerGameObjects = new Dictionary<int, Dictionary<GameObject, float>>()
        //{
            //{ 0, new Dictionary<GameObject, float>{ { GameObject.Find("PlayerSelectAnimals/PlayerRat"), 1f } } },
            //{ 1, new Dictionary<GameObject, float>{ { GameObject.Find("PlayerSelectAnimals/PlayerRabbit"), 2f } } },
            //{ 2, new Dictionary<GameObject, float>{ { GameObject.Find("PlayerSelectAnimals/PlayerRooster"), 3f } } },
            //{ 3, new Dictionary<GameObject, float>{ { GameObject.Find("PlayerSelectAnimals/PlayerCrane"), 4f } } },
            //{ 4, new Dictionary<GameObject, float>{ { GameObject.Find("PlayerSelectAnimals/PlayerSnake"), 5f } } },
            //{ 5, new Dictionary<GameObject, float>{ { GameObject.Find("PlayerSelectAnimals/PlayerDog"), 6f } } },
            //{ 6, new Dictionary<GameObject, float>{ { GameObject.Find("PlayerSelectAnimals/PlayerMonkey"), 7f } } },
            //{ 7, new Dictionary<GameObject, float>{ { GameObject.Find("PlayerSelectAnimals/PlayerGoat"), 8f } } },
            //{ 8, new Dictionary<GameObject, float>{ { GameObject.Find("PlayerSelectAnimals/PlayerPig"), 9f } } },
            //{ 9, new Dictionary<GameObject, float>{ { GameObject.Find("PlayerSelectAnimals/PlayerOx"), 10f } } },
            //{ 10,new Dictionary<GameObject, float>{ { GameObject.Find("PlayerSelectAnimals/PlayerHorse"), 11f } } },
            //{ 11,new Dictionary<GameObject, float>{ { GameObject.Find("PlayerSelectAnimals/PlayerTiger"), 12f } } },
            //{ 12,new Dictionary<GameObject, float>{ { GameObject.Find("PlayerSelectAnimals/PlayerDragon"), 13f } } },

        //};
    }

        //mDicAnimalKeys = new GameObject[dicPlayerGameObjects.Count];

        //foreach (var kv in dicPlayerGameObjects)
        //{
         //   dicPlayerGameObjects.Keys.CopyTo(mDicAnimalKeys, kv.Value);
        //}

    // Update is called once per frame
    void Update()
    {

        if (spawnFlag == 0)
        {
            mAnimalNum[0] = Random.Range(0, 13);
            mAnimalNum[1] = Random.Range(0, 13);
            mAnimalNum[2] = Random.Range(0, 13);

            selectAnimals[0] = Instantiate(mAnimal.playerAnimals[mAnimalNum[0]].playerAnimalName, new Vector3(-97f, 0.7f, 5.3f) , Quaternion.identity);
            selectAnimals[1] = Instantiate(mAnimal.playerAnimals[mAnimalNum[1]].playerAnimalName, new Vector3(-100f, 0.7f, 5.3f), Quaternion.identity);
            selectAnimals[2] = Instantiate(mAnimal.playerAnimals[mAnimalNum[2]].playerAnimalName, new Vector3(-103f, 0.7f, 5.3f), Quaternion.identity);

            spawnFlag = 1;
        }

        mMousePos = Input.mousePosition;
        //Debug.Log(mMousePos);
        mMouseWheelScroll = Input.GetAxis("Mouse ScrollWheel");

        if (mMouseWheelScroll > 0f)
        {
            if (mMouseDepth > 12.5f)
            {
                mMouseDepth -= 0.5f;
            }
        }
        else if (mMouseWheelScroll < 0f)
        {
            if (mMouseDepth < 19.5f)
            {
                mMouseDepth += 0.5f;
            }
        }


        mMousePos.z = mMouseDepth;
        Vector3 touchWorldPosition = mCamera.ScreenToWorldPoint(mMousePos);

        if (touchWorldPosition.x < -103f)
        {
            touchWorldPosition.x = -103f;
        }
        else if (touchWorldPosition.x > -96f)
        {
            touchWorldPosition.x = -96f;
        }

        //Debug.Log(touchWorldPosition);

        if (selectFlag == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
        
                Ray ray = mCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit = new RaycastHit();

                if (Physics.Raycast(ray, out hit))
                {
                    //Debug.Log(hit.collider.gameObject.transform.position);
                    //Debug.Log(hit.collider.gameObject.tag);

                    if(hit.collider.gameObject.CompareTag("PlayerSelectAnimals"))
                    {
                        //Debug.Log(hit.collider.gameObject);

                        selectFlag = 1;
                        mPlayerChoice = Instantiate(hit.collider.gameObject, new Vector3(touchWorldPosition.x, 13f, touchWorldPosition.z), Quaternion.identity);
                        mPlayerChoice.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
                        mPlayerChoice.AddComponent<Rigidbody>();
                        mPlayerChoice.AddComponent<ResetFlag>();
                        mPlayerChoice.AddComponent<DestroyAnimal>();
                        mPlayerChoice.AddComponent<PlayerAnimalWeight>();

                        Destroy(hit.collider.gameObject);
                    }
                }
            }
        }

        else if (selectFlag == 1)
        {
            mPlayerChoice.transform.position = new Vector3(touchWorldPosition.x, 13f, touchWorldPosition.z);
            if (Input.GetMouseButtonDown(0))
            {
                selectFlag = 2;
            }
        }
    }
}
