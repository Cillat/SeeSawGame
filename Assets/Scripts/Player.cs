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
    private Vector3 touchWorldPosition;

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
    }

    void Update()
    {

        if (spawnFlag == 0)
        {
            mAnimalNum[0] = Random.Range(0, 13);
            mAnimalNum[1] = Random.Range(0, 13);
            mAnimalNum[2] = Random.Range(0, 13);

            selectAnimals[0] = Instantiate(mAnimal.animals[mAnimalNum[0]].prefab, new Vector3(-97f, 0.7f, 5.3f) , Quaternion.identity);
            selectAnimals[1] = Instantiate(mAnimal.animals[mAnimalNum[1]].prefab, new Vector3(-100f, 0.7f, 5.3f), Quaternion.identity);
            selectAnimals[2] = Instantiate(mAnimal.animals[mAnimalNum[2]].prefab, new Vector3(-103f, 0.7f, 5.3f), Quaternion.identity);

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
        touchWorldPosition = mCamera.ScreenToWorldPoint(mMousePos);

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
                    if(hit.collider.gameObject.CompareTag("Animals"))
                    {
                        AudioManager.Instance.PlaySE("Selected");

                        selectFlag = 1;
                        mPlayerChoice = Instantiate(hit.collider.gameObject, new Vector3(touchWorldPosition.x, 13f, touchWorldPosition.z), Quaternion.identity);
                        mPlayerChoice.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
                        mPlayerChoice.AddComponent<ResetFlag>();
                        mPlayerChoice.AddComponent<DestroyPlayerAnimal>();
                        mPlayerChoice.AddComponent<PlayerAnimalWeight>();

                        Destroy(hit.collider.gameObject);
                    }
                }
            }
        }

        else if (selectFlag == 1)
        {
            mPlayerChoice.transform.position = new Vector3(touchWorldPosition.x, 13f, touchWorldPosition.z);

            if (Input.GetKey(KeyCode.W))
            {
                mPlayerChoice.transform.Rotate(new Vector3(3.0f, 0f, 0f));
            }

            if (Input.GetKey(KeyCode.S))
            {
                mPlayerChoice.transform.Rotate(new Vector3(-3.0f, 0f, 0f));
            }

            if (Input.GetKey(KeyCode.E))
            {
                mPlayerChoice.transform.Rotate(new Vector3(0f, 3f, 0f));
            }

            if (Input.GetKey(KeyCode.Q))
            {
                mPlayerChoice.transform.Rotate(new Vector3(0f, -3f, 0f));
            }

            if (Input.GetKey(KeyCode.D))
            {
                mPlayerChoice.transform.Rotate(new Vector3(0f, 0f, 3f));
            }

            if (Input.GetKey(KeyCode.A))
            {
                mPlayerChoice.transform.Rotate(new Vector3(0f, 0f, -3f));
            }


            if (Input.GetMouseButtonDown(0))
            {
                mPlayerChoice.AddComponent<Rigidbody>();
                selectFlag = 2;
            }
        }
    }
}
