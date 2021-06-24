using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeMove : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] int distanceEnter = 100;

    float sineSpeed = 3f;
    float sineSize = 150f;

    void Update()
    {
        if (transform.position.x - player.transform.position.x < distanceEnter)
        {
            transform.Translate(-Vector3.right * 30f * Time.deltaTime);
            float zPos = Mathf.Sin(Time.time * sineSpeed) * sineSize;
            transform.position = new Vector3(transform.position.x, transform.position.y, zPos * Time.deltaTime);
        }        
    }
}
