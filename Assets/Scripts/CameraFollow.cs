using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform followObject;
    [SerializeField] Vector3 offset = new Vector3(-10, 15, -50);
    FinishCollision finishCollision;

    float rotationSpeed = 0.01f;    

    void Start()
    {
        finishCollision = FindObjectOfType<FinishCollision>();
    }

    void Update()
    {
        transform.position = followObject.position + offset;

        if(finishCollision.ReachedFinish)
        {
            offset.x = Mathf.Lerp(offset.x, -70, rotationSpeed);
        }
    }
}
