using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class Swipe : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler {

	public GameObject signUp;
	Vector2 _lastPosition = Vector2.zero;
	Vector2 startDragPosition = Vector2.zero;


	private float speed = Screen.width/7;
	private bool signUpToTheRight;

	public Events.Vector2 OnSwipeStart = new Events.Vector2();
	public Events.Vector2 OnSwipeEnd = new Events.Vector2();
	public Events.Vector2 OnSwipe = new Events.Vector2();
	Vector2 direction;

	public void OnBeginDrag(PointerEventData eventData) {
		_lastPosition = eventData.position;
		startDragPosition = eventData.position;
		OnSwipeStart.Invoke(eventData.position);
	}

	public void OnEndDrag(PointerEventData eventData) {
		OnSwipeEnd.Invoke(eventData.position);

		if (eventData.position.x - startDragPosition.x > Screen.width / 2) {
			signUpToTheRight = true;
		} else {
			signUpToTheRight = false;
		}
		Debug.Log (signUpToTheRight);
		if (signUpToTheRight) {
			StartCoroutine (UpdatePathToRightSide ());
		} else  {
			StartCoroutine (UpdatePathToLeftSide ());
		}
	}

	public void OnDrag(PointerEventData eventData) {
		direction = eventData.position - _lastPosition;

		if (eventData.position.x > _lastPosition.x) {				
			signUp.transform.position += new Vector3 (direction.x, 0, 0);
		}
		_lastPosition = eventData.position;
		OnSwipe.Invoke(direction);
	}

	private IEnumerator UpdatePathToRightSide()
	{
		while (signUp.transform.position.x  < Screen.width + Screen.width / 2) {
			if (signUp.transform.position.x + speed < Screen.width + Screen.width / 2) {
				signUp.transform.position += new Vector3 (speed, 0, 0);
			} else {
				signUp.transform.position += new Vector3 (Screen.width + Screen.width / 2 - signUp.transform.position.x, 0, 0);

			}
			yield return null;
		}
	}

	private IEnumerator UpdatePathToLeftSide()
	{
		while (signUp.transform.position.x  > Screen.width / 2) {
			
			if (signUp.transform.position.x - speed >Screen.width / 2) {
				signUp.transform.position -= new Vector3 (speed, 0, 0);
			} else {
				signUp.transform.position -= new Vector3 (signUp.transform.position.x - Screen.width / 2, 0, 0);

			}

			yield return null;
		}
	}


}