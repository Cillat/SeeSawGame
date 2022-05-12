using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayBGM("Main");
        AudioManager.Instance.ChangeVolume(0.2f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
