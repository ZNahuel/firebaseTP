using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EneemyMovement : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent enemy;
    public Transform Player;
    void Start()
    {

    }

    void Update()
    {
        enemy.SetDestination(Player.position);
    }
}
