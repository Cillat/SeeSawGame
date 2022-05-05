using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAnimal : MonoBehaviour
{
    private GameObject mDeathFloor;
    // Start is called before the first frame update
    void Start()
    {
        mDeathFloor = GameObject.Find("GameStage/DeathFloor");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == mDeathFloor)
        {
            Destroy(gameObject);    
            Debug.Log("Destroy");
        }
    }
}
