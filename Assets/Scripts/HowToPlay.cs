using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    private PageManager mPageManager;
    // Start is called before the first frame update
    void Start()
    {
        mPageManager = GameObject.Find("Title/Canvas").GetComponent<PageManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        AudioManager.Instance.PlaySE("Clicked");
        mPageManager.pageFlag = 1;
    }
}
