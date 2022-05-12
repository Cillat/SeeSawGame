using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStart : MonoBehaviour
{
    private GameManager mGameManager;
    // Start is called before the first frame update
    void Start()
    {
        mGameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        AudioManager.Instance.PlaySE("Clicked");
        mGameManager.sceneFlag = GameManager.SceneFlag.Playing;
        SceneManager.LoadScene("SeeSawGame");
    }

}
