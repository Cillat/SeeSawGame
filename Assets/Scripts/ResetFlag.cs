using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetFlag : MonoBehaviour
{

    private Player mPlayer;
    private int mCollisionFlag;
    // Start is called before the first frame update
    void Start()
    {
        mPlayer = GameObject.Find("GameStage/GameManager").GetComponent<Player>();
        mCollisionFlag = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (mPlayer.selectFlag == 2 && mCollisionFlag == 0)
        {
            mCollisionFlag = 1;
            mPlayer.selectFlag = 0;
            mPlayer.spawnFlag = 0;

            if (mPlayer.selectAnimals[0] != null)
            {
                Destroy(mPlayer.selectAnimals[0]);
            }

            if (mPlayer.selectAnimals[1] != null)
            {
                Destroy(mPlayer.selectAnimals[1]);
            }

            if (mPlayer.selectAnimals[2] != null)
            {
                Destroy(mPlayer.selectAnimals[2]);
            }
            
        }
    }
}
