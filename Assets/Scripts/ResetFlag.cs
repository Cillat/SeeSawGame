using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetFlag : MonoBehaviour
{

    public int collisionFlag;
    private Player mPlayer;
    // Start is called before the first frame update
    void Start()
    {
        mPlayer = GameObject.Find("GameStage/GameManager").GetComponent<Player>();
        collisionFlag = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (mPlayer.selectFlag == 2 && collisionFlag == 0)
        {
            collisionFlag = 1;
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
