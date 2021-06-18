using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeterControl : MonoBehaviour
{
    public int P1_starting_Health;
    public int P2_starting_Health;

    private int P1_Health;
    private int P2_Health;
    private int P1_Red_Health = 0;
    private int P2_Red_Health = 0;

    // Start is called before the first frame update
    void Start()
    {
        P1_Health = P1_starting_Health;
        P2_Health = P1_starting_Health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetP1Health(int i)
    {
        P1_Health = i;
    }

    public void SetP2Health(int i)
    {
        P2_Health = i;
    }

    public void SetP1RedHealth(int i)
    {
        P1_Red_Health = i;
    }

    public void SetP2RedHealth(int i)
    {
        P2_Red_Health = i;
    }

    public int GetP1Health()
    {
        return P1_Health;
    }

    public int GetP2Health()
    {
        return P2_Health;
    }

    public int GetP1RedHealth()
    {
        return P1_Red_Health;
    }

    public int GetP2RedHealth()
    {
        return P2_Red_Health;
    }
}
