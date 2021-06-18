using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp_bar : MonoBehaviour
{
    public Image p1_green;
    public Image p2_green;
    public Image p1_red;
    public Image p2_red;

    public GameObject meterControl;
    private MeterControl meters;

    // Start is called before the first frame update
    void Start()
    {
        meters = meterControl.GetComponent<MeterControl>();
    }

    // Update is called once per frame
    void Update()
    {
        SetRedHealthBar();
    }

    public void Hit_P2()
    {
            meters.SetP2Health(meters.GetP2Health() - 5);
            Debug.Log(meters.GetP2Health());
            SetHealthBar();
    }

    //PreCondition: Call when dmg is done to either character
    void SetHealthBar()
    {
        float dmg = 0.05f; //get dmg done in frame
        p2_green.fillAmount -= dmg;
        Debug.Log(dmg);

        p2_green.transform.localPosition = new Vector3(p2_green.transform.localPosition.x - dmg * 100f * 4.35f, p2_green.transform.localPosition.y, p2_green.transform.localPosition.z);
    }

    void SetRedHealthBar()
    {
        if(p2_red.fillAmount > p2_green.fillAmount)
        {
            p2_red.fillAmount -= 0.01f / 0.1f * Time.deltaTime;
            p2_red.transform.localPosition = new Vector3(p2_red.transform.localPosition.x - 0.01f / 0.1f * Time.deltaTime * 100f * 4.35f, p2_red.transform.localPosition.y, p2_red.transform.localPosition.z);
        }
    }
}
