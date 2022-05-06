using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private GameManager gameManager;
    private GameObject[] mPlayerGameObjects;
    private GameObject mPlayerChoice;
    private Camera mCamera;
    private int[] mAnimalNum;
    private float mTime;
    private float mMouseWheelScroll;
    private float mMouseDepth;
    private Vector3 mMousePos;
    public int spawnFlag;
    public int selectFlag;
    public GameObject[] selectAnimals;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameStage/GameManager").GetComponent<GameManager>();
        mCamera = GameObject.Find("GameStage/PlayerView/PlayerCamera").GetComponent<Camera>();
        mPlayerChoice = null;
        mAnimalNum = new int[3];
        selectAnimals = new GameObject[3];
        mPlayerGameObjects = new GameObject[13];
        mTime = 0f;
        mMouseDepth = 16.5f;
        spawnFlag = 0;
        selectFlag = 0;

        mPlayerGameObjects[0] = GameObject.Find("PlayerSelectAnimals/PlayerRat");
        mPlayerGameObjects[1] = GameObject.Find("PlayerSelectAnimals/PlayerRabbit");
        mPlayerGameObjects[2] = GameObject.Find("PlayerSelectAnimals/PlayerRooster");
        mPlayerGameObjects[3] = GameObject.Find("PlayerSelectAnimals/PlayerCrane");
        mPlayerGameObjects[4] = GameObject.Find("PlayerSelectAnimals/PlayerSnake");
        mPlayerGameObjects[5] = GameObject.Find("PlayerSelectAnimals/PlayerDog");
        mPlayerGameObjects[6] = GameObject.Find("PlayerSelectAnimals/PlayerMonkey");
        mPlayerGameObjects[7] = GameObject.Find("PlayerSelectAnimals/PlayerGoat");
        mPlayerGameObjects[8] = GameObject.Find("PlayerSelectAnimals/PlayerPig");
        mPlayerGameObjects[9] = GameObject.Find("PlayerSelectAnimals/PlayerOx");
        mPlayerGameObjects[10] = GameObject.Find("PlayerSelectAnimals/PlayerHorse");
        mPlayerGameObjects[11] = GameObject.Find("PlayerSelectAnimals/PlayerTiger");
        mPlayerGameObjects[12] = GameObject.Find("PlayerSelectAnimals/PlayerDragon");
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnFlag == 0)
        {
            mAnimalNum[0] = Random.Range(0, 13);
            mAnimalNum[1] = Random.Range(0, 13);
            mAnimalNum[2] = Random.Range(0, 13);
            spawnFlag = 1;

            selectAnimals[0] = Instantiate(mPlayerGameObjects[mAnimalNum[0]], new Vector3(-97f, 0.7f, 5.3f) , Quaternion.identity);
            selectAnimals[1] = Instantiate(mPlayerGameObjects[mAnimalNum[1]], new Vector3(-100f, 0.7f, 5.3f), Quaternion.identity);
            selectAnimals[2] = Instantiate(mPlayerGameObjects[mAnimalNum[2]], new Vector3(-103f, 0.7f, 5.3f), Quaternion.identity);
        }

        mMousePos = Input.mousePosition;
        Debug.Log(mMousePos);
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

        Debug.Log(touchWorldPosition);

        if (selectFlag == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
        
                Ray ray = mCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit = new RaycastHit();

                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log(hit.collider.gameObject.transform.position);
                    Debug.Log(hit.collider.gameObject.tag);

                    if(hit.collider.gameObject.CompareTag("PlayerSelectAnimals"))
                    {
                        Debug.Log(hit.collider.gameObject);

                        selectFlag = 1;
                        mPlayerChoice = Instantiate(hit.collider.gameObject, new Vector3(touchWorldPosition.x, 13f, touchWorldPosition.z), Quaternion.identity);
                        mPlayerChoice.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
                        mPlayerChoice.AddComponent<Rigidbody>();
                        mPlayerChoice.AddComponent<ResetFlag>();
                        mPlayerChoice.AddComponent<DestroyAnimal>();

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


//        mTime += Time.deltaTime;
//        if (mTime > 5f)
//        {
//           mTime = 0f;
//            spawnFlag = 0;
//        }

    }
}
