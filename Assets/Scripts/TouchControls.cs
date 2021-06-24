using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour
{	
	float SWIPE_THRESHOLD = 20f;
	Vector2 fingerDownPos;
	Vector2 fingerUpPos;

	PlayerMovement playerMovement;

	void Start()
	{
		playerMovement = FindObjectOfType<PlayerMovement>();
	}

	void Update ()
	{
		CheckSwipe();
	}

    void CheckSwipe()
    {
        foreach (Touch touch in Input.touches)
        {
			if (touch.phase == TouchPhase.Began)
            {
				fingerUpPos = touch.position;
				fingerDownPos = touch.position;
			}

			if (touch.phase == TouchPhase.Ended)
            {
				fingerDownPos = touch.position;
				DetectSwipe();
			}
		}
    }

	void DetectSwipe()
	{		
		if (VerticalMoveValue () > SWIPE_THRESHOLD && VerticalMoveValue () > HorizontalMoveValue ())
        {
			
			if (fingerDownPos.y - fingerUpPos.y > 0)
            {
				OnSwipeUp();
			}
            else if (fingerDownPos.y - fingerUpPos.y < 0)
            {
				OnSwipeDown();
			}
			fingerUpPos = fingerDownPos;
		}

		float VerticalMoveValue()
		{
			return Mathf.Abs (fingerDownPos.y - fingerUpPos.y);
		}

		float HorizontalMoveValue()
		{
			return Mathf.Abs (fingerDownPos.x - fingerUpPos.x);
		}
	}



	void OnSwipeUp()
	{
		playerMovement.PlayerJump();
	}

	void OnSwipeDown()
	{
		playerMovement.PlayerSkewDown();
	}
}