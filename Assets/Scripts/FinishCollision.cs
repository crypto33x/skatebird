using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCollision : MonoBehaviour
{
    bool reachedFinish = false;
    public bool ReachedFinish { get { return reachedFinish; } }

    void OnTriggerEnter(Collider other)
    {
        reachedFinish = true;
        PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
        playerMovement.PlayerReachedFinish();
    }
}
