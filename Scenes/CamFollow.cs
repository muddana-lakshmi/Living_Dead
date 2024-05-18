using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Vector3 distance;
    public float clampy;
    void Start()
    {
        distance=transform.position-player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=new Vector3(player.transform.position.x,Mathf.Clamp(clampy,clampy,0),player.transform.position.z)+distance;
    }
}
