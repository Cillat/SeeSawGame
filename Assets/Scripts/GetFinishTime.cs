using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetFinishTime : MonoBehaviour
{
    public Text resultTime;
    public float finishTime;

    private FinishTime mGetFinishTime;

    // Start is called before the first frame update
    void Start()
    {
        resultTime = this.gameObject.GetComponent<Text>();
        mGetFinishTime = GameObject.Find("AudioManager").GetComponent<FinishTime>();
        finishTime = mGetFinishTime.resultTime;
        resultTime.text = "Result : " + finishTime.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        if (finishTime == 0f)
        {
            resultTime = this.gameObject.GetComponent<Text>();
            mGetFinishTime = GameObject.Find("AudioManager").GetComponent<FinishTime>();
            finishTime = mGetFinishTime.resultTime;
            resultTime.text = "Result : " + finishTime.ToString("F2");
        }
    }
}
