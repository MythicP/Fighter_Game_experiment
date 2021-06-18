using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrameRateCounter : MonoBehaviour
{
    public TMPro.TextMeshProUGUI frames;
    private void Start()
    {
       frames = GetComponent<TMPro.TextMeshProUGUI>();
    }
    void Update()
    {
        float frameCount = 1 / Time.deltaTime;
        if(Time.frameCount%5 == 0)
            frames.SetText(frameCount.ToString());
    }
}
