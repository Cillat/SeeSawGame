using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoTitle : MonoBehaviour
{
    private GameManager mGameManager;
    private AudioManager mAudioManager;
    // Start is called before the first frame update
    void Start()
    {
        mGameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        mAudioManager = GameObject.Find("GameManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        mAudioManager.StopBGM();
        AudioManager.Instance.PlayBGM("Main");
        mGameManager.gameFlag = 0;
        mGameManager.sceneFlag = GameManager.SceneFlag.Title;
        SceneManager.LoadScene("Title");
    }
}
