using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeChange : MonoBehaviour
{

    private AudioManager mAudioManager;
    // Start is called before the first frame update
    void Start()
    {
        mAudioManager = GameObject.Find("GameManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SoundSliderOnValueChange(float newSliderValue)
    {
        // 音楽の音量をスライドバーの値に変更
        newSliderValue = this.gameObject.GetComponent<Slider>().value;
        mAudioManager.ChangeVolume(newSliderValue, 0.3f);
    }
}
