using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Timer : MonoBehaviour
{
    public GameObject timer;
    private TextMeshProUGUI timer_Text;

    private float display_Time;
    public float max_Time = 99;

    // Start is called before the first frame update
    void Start()
    {
        timer_Text = timer.GetComponent<TextMeshProUGUI>();
        display_Time = Time.fixedTime;
        display_Time = max_Time;
    }

    // Update is called once per frame
    void Update()
    {
        timer_Text.text = Mathf.RoundToInt(display_Time).ToString();
    }

    void FixedUpdate()
    {
        display_Time -= Time.fixedDeltaTime;
    }
}
