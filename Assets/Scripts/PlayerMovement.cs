using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed = 40f;

    Animator animator;
    Rigidbody rb;
    CloudsMove cloudsMove;
    FinishCollision finishCollision;
    SkateRotation skateRotation;

    int rotationToZeroSpeed = 20;
    float finishSpeedDown = 0.02f;

    float sineSpeed = 1.5f;
    float sineSize = 150f;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        cloudsMove = FindObjectOfType<CloudsMove>();
        finishCollision = FindObjectOfType<FinishCollision>();
        skateRotation = FindObjectOfType<SkateRotation>();
    }

    void Update()
    {
        PlayerMove();
        PlayerRotateNormalize();        
    }

    void PlayerRotateNormalize()
    {
        if (transform.rotation.x != 0 || transform.rotation.y != 0 || transform.rotation.z != 0) // rotate back to zero after rb physics changes
        {
            Quaternion deltaRotation = Quaternion.Euler(
                new Vector3(-transform.rotation.x, -transform.rotation.y, -transform.rotation.z)
                * Time.fixedDeltaTime * rotationToZeroSpeed);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
    }

    void PlayerMove()
    {
        transform.position += Vector3.right * playerSpeed * Time.deltaTime;

        // move by sine wave on Z axis
        float zPos = Mathf.Sin(Time.time * sineSpeed) * sineSize;
        transform.position = new Vector3(transform.position.x, transform.position.y, zPos * Time.deltaTime);

        if(finishCollision.ReachedFinish)
        {
            playerSpeed = Mathf.Lerp(playerSpeed, 0, finishSpeedDown);
            sineSpeed = 0f;
            Destroy(skateRotation);
        }
    }

    public void PlayerJump()
    {
        animator.Play("Jump");
        rb.AddForce(new Vector3(0, 20, 0), ForceMode.Impulse);
    }

    public void PlayerSkewDown()
    {
        animator.Play("SkewDown");
    }

    public void PlayerDie()
    {
        animator.Play("Die");
        playerSpeed = 0f;
        sineSpeed = 0f;

        Destroy(cloudsMove);        
        Destroy(skateRotation);
    }

    public void PlayerPlatformDown()
    {
        animator.Play("PlatfromDown");
        rb.AddForce(new Vector3(0, -40, 0), ForceMode.Impulse);
    }

    public void PlayerReachedFinish()
    {
        animator.Play("GetSunglasses");
    }

}
