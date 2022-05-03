using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishJudge : MonoBehaviour
{
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        gameManager.sceneFlag = GameManager.SceneFlag.Finish;

    }


}
