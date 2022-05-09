using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetFinishTime : MonoBehaviour
{
    public Text resultTime;

    private float mFinishTime;
    private FinishTime mGetFinishTime;

    // Start is called before the first frame update
    void Start()
    {
        resultTime = this.gameObject.GetComponent<Text>();
        mGetFinishTime = GameObject.Find("AudioManager").GetComponent<FinishTime>();
        mFinishTime = mGetFinishTime.resultTime;
        Debug.Log(mFinishTime);
        resultTime.text = "Result :" + mFinishTime.ToString("F4");
    }

    // Update is called once per frame
    void Update()
    {
        if (mFinishTime == 0f)
        {
            mGetFinishTime = GameObject.Find("AudioManager").GetComponent<FinishTime>();
            mFinishTime = mGetFinishTime.resultTime;
            Debug.Log(mFinishTime);
            resultTime.text = "Result :" + mFinishTime.ToString("F2");
        }
    }
}
