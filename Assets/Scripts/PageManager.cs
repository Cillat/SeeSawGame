using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageManager : MonoBehaviour
{
    public int pageFlag;

    private GameObject mStopHowToPlay;
    private GameObject mRightButton_obj;
    private GameObject mLeftButton_obj;
    private Button mRightButton;
    private Button mLeftButton;
    private Image mHowToPlay1;
    private Image mHowToPlay2;
    private Image mHowToPlay3;
    private Image mHeavyRank;
    private int anyPageOpenFlag;


    // Start is called before the first frame update
    void Start()
    {
        pageFlag = 0;
        anyPageOpenFlag = 0;

        mStopHowToPlay = GameObject.Find("Title/Canvas/StopHowToPlay");

        mRightButton_obj = GameObject.Find("Title/Canvas/RightButton");
        mLeftButton_obj = GameObject.Find("Title/Canvas/LeftButton");
        mRightButton = mRightButton_obj.GetComponent<Button>();
        mLeftButton = mLeftButton_obj.GetComponent<Button>();

        mHowToPlay1 = GameObject.Find("Title/Canvas/HowToPlay1").GetComponent<Image>();
        mHowToPlay2 = GameObject.Find("Title/Canvas/HowToPlay2").GetComponent<Image>();
        mHowToPlay3 = GameObject.Find("Title/Canvas/HowToPlay3").GetComponent<Image>();
        mHeavyRank =  GameObject.Find("Title/Canvas/HeavyRank").GetComponent<Image>();

        mStopHowToPlay.SetActive(false);

        mRightButton_obj.SetActive(false);
        mLeftButton_obj.SetActive(false);
        mRightButton.enabled = false;
        mLeftButton.enabled = false;
        
        mHowToPlay1.enabled = false;
        mHowToPlay2.enabled = false;
        mHowToPlay3.enabled = false;
        mHeavyRank.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (mStopHowToPlay.activeSelf == false && pageFlag != 0)
        {
            mStopHowToPlay.SetActive(true);
        }

        if (pageFlag == 1 && (mRightButton.enabled != true || mLeftButton.enabled != false))
        {
            mRightButton_obj.SetActive(true);
            mLeftButton_obj.SetActive(false);
            mRightButton.enabled = true;
            mLeftButton.enabled = false;
            
        }
        else if (pageFlag == 4 && (mRightButton.enabled != false || mLeftButton.enabled != true))
        {
            mRightButton_obj.SetActive(false);
            mLeftButton_obj.SetActive(true);
            mRightButton.enabled = false;
            mLeftButton.enabled = true;
        }
        else if ((pageFlag == 2 || pageFlag == 3) && ( mRightButton.enabled != true || mLeftButton.enabled != true))
        {
            mRightButton_obj.SetActive(true);
            mLeftButton_obj.SetActive(true);
            mRightButton.enabled = true;
            mLeftButton.enabled = true;
        }



        if (pageFlag == 1 && mHowToPlay1.enabled == false)
        {
            mHowToPlay1.enabled = true;
            mHowToPlay2.enabled = false;
            mHowToPlay3.enabled = false;
            mHeavyRank.enabled = false;

            anyPageOpenFlag = 1;
        }
        else if (pageFlag == 2 && mHowToPlay2.enabled == false)
        {
            mHowToPlay2.enabled = true;
            mHowToPlay1.enabled = false;
            mHowToPlay3.enabled = false;
            mHeavyRank.enabled = false;

            anyPageOpenFlag = 1;
        }
        else if (pageFlag == 3 && mHowToPlay3.enabled == false)
        {
            mHowToPlay3.enabled = true;
            mHowToPlay1.enabled = false;
            mHowToPlay2.enabled = false;
            mHeavyRank.enabled = false;

            anyPageOpenFlag = 1;
        }
        else if (pageFlag == 4 && mHeavyRank.enabled == false)
        {
            mHeavyRank.enabled = true;
            mHowToPlay1.enabled = false;
            mHowToPlay2.enabled = false;
            mHowToPlay3.enabled = false;

            anyPageOpenFlag = 1;
        }
        else if (pageFlag == 0 && anyPageOpenFlag == 1)
        {
            anyPageOpenFlag = 0;

            mStopHowToPlay.SetActive(false);

            mRightButton_obj.SetActive(false);
            mLeftButton_obj.SetActive(false);
            mRightButton.enabled = false;
            mLeftButton.enabled = false;

            mHowToPlay1.enabled = false;
            mHowToPlay2.enabled = false;
            mHowToPlay3.enabled = false;
            mHeavyRank.enabled = false;
        }
    }
}
