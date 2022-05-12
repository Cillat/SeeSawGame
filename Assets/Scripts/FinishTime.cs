using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTime : MonoBehaviour
{
    public float resultTime;

    private GameManager mGameManager;
    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(gameObject);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (mGameManager.sceneFlag == GameManager.SceneFlag.Result && Input.GetKeyDown(KeyCode.R))
        {
            mGameManager.sceneFlag = GameManager.SceneFlag.ReTry;
            GameObject.Find("AudioManager").GetComponent<AudioManager>().StopBGM();
            SceneManager.LoadScene("Title");
           
        }
    }

    public void FindGameManager()
    {
        mGameManager = GameObject.Find("GameStage/GameManager").GetComponent<GameManager>();
    }
}
