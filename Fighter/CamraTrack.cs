using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamraTrack : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject Player1;
    public GameObject Player2;

    public float minZ = -4.24f;
    public float mmX = 10;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 ((Player1.transform.position.x + Player2.transform.position.x) / 2, (Player1.transform.position.y + Player2.transform.position.y) / 2, transform.position.z);
        transform.position = new Vector3( Mathf.Clamp(transform.position.x, -mmX, mmX), Mathf.Clamp(transform.position.y, 1.16f, 10), Mathf.Clamp(transform.position.z, minZ, 1));
    }
}
