using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHit : MonoBehaviour
{
    private bool blocking = false;
    private int hitStun = 0;
    public Animator ani;
    public Hp_bar bars;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hitStun > 0)
            hitStun--;
        if(hitStun <= 0)
            ani.Play("Idle");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Mid_Hit")
        get_Hit_Mid(22, 22);
    }

    public void get_Hit_Mid(int hit_Stun, int block_Stun)
    {
        Debug.Log("Hit_Mid");
        if(blocking)
        {

        }
        else
        {
            ani.Play("Hit_Mid", 0, 0);//35 - hit_Stun
            hitStun = hit_Stun;
            bars.Hit_P2();

        }
    }

    public void get_Hit_Low(int hit_Stun, int block_Stun)
    {
        if (blocking)
        {

        }
        else
            ani.Play("Hit_Low", 0, 35 - hit_Stun);
    }
}
