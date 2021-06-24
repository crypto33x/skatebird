using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsMove : MonoBehaviour
{
    void Update()
    {
        transform.Translate(-Vector3.right * 20f * Time.deltaTime);   
    }
}
