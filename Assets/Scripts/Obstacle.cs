using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] int distanceEnter = 40;
    [SerializeField] string AnimationName;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (transform.position.x - player.transform.position.x < distanceEnter && AnimationName != null)
        {
            animator.Play(AnimationName);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
        playerMovement.PlayerDie();
    }
}
