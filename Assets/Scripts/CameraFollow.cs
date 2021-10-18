using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;

    float camSet;

    // Start is called before the first frame update
    void Start()
    {
        camSet = gameObject.transform.position.z - Player.position.z; ;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camPos = new Vector3(Player.position.x, gameObject.transform.position.y, Player.position.z + camSet);

        gameObject.transform.position = camPos;
    }
}
