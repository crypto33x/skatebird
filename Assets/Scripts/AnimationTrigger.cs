using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    public void OnCollisionEnter(Collision other)
    {
        PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
        playerMovement.PlayerPlatformDown();
    }
}
