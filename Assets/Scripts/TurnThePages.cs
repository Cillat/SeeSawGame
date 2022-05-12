using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnThePages : MonoBehaviour
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

    public void ClickRightButton()
    {
        AudioManager.Instance.PlaySE("TurnThePages");
        mPageManager.pageFlag += 1;
    }

    public void ClickLeftButton()
    {
        AudioManager.Instance.PlaySE("TurnThePages");
        mPageManager.pageFlag -= 1;
    }
}
