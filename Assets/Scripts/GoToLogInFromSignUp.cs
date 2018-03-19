using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToLogInFromSignUp : MonoBehaviour {
	public enum SwipeDirection{
		Up,
		Down,
		Right,
		Left
	}

	public static event System.Action<SwipeDirection> Swipe;
	private bool swiping = false;
	private bool eventSent = false;
	private Vector2 lastPosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount == 0) 
			return;

		if (Input.GetTouch(0).deltaPosition.sqrMagnitude != 0){
			if (swiping == false){
				swiping = true;
				lastPosition = Input.GetTouch(0).position;
				return;
			}
			else{
				if (!eventSent) {
					if (Swipe != null) {
						Vector2 direction = Input.GetTouch(0).position - lastPosition;

						if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)){
							if (direction.x > 0) {
								Debug.Log ("right");
								//Swipe (SwipeDirection.Right);
							} else {
								Debug.Log ("left");
								//Swipe (SwipeDirection.Left);
							}
						}
						else{
							if (direction.y > 0) {
								Debug.Log ("up");
								//Swipe (SwipeDirection.Up);
							} else {
								Debug.Log ("down");
								//Swipe (SwipeDirection.Down);
							}
						}

						eventSent = true;
					}
				}
			}
		}
		else{
			swiping = false;
			eventSent = false;
		}
	}
		
	}

