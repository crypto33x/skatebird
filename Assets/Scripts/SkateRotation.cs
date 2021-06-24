using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkateRotation : MonoBehaviour
{

    float sineSpeed = 2f;
    float sineSize = 150f;

    void Update()
    {
        float yRot = Mathf.Sin(Time.time * sineSpeed) * sineSize;

        transform.localRotation = Quaternion.Euler(0, yRot * Time.deltaTime, 0);
    }
}
