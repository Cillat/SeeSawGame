using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAnimal : MonoBehaviour
{
    private GameObject mDeathFloor;
    public int destroyFlag;
    // Start is called before the first frame update
    void Start()
    {
        mDeathFloor = GameObject.Find("GameStage/DeathFloor");
        destroyFlag = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == mDeathFloor)
        {
            if (destroyFlag == 0)
            {
                Destroy(gameObject);
                Debug.Log("Destroy");

                destroyFlag = 1;
            }

        }
    }
}
