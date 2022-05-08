using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishJudge : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameStage/GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        gameManager.sceneFlag = GameManager.SceneFlag.Finish;
    }


}
