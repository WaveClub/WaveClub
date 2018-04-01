using UnityEngine;
using UnityEngine.UI;

public class SwipeInput : MonoBehaviour
{
	public bool swiping;

	public float minSwipeDistance = Screen.width / 2;
	public float errorRange;

	public GameObject message;
	public Text messageText;

	public SwipeDirection direction = SwipeDirection.None;

	public enum SwipeDirection {Right, Left, Up, Down, None}

	private Touch initialTouch;

	public GameObject signUp;
	public GameObject logIn;

	void Start()
	{
		Input.multiTouchEnabled = true;
		message.SetActive (true);
	}

	void Update()
	{
		if (Input.touchCount <= 0) {
			//messageText.text = "no touches";
			return;
		}
		//messageText.text =  Input.touchCount + " touches";
		foreach (var touch in Input.touches)
		{
			if (touch.phase == TouchPhase.Began)
			{
				initialTouch = touch;
			}
			else if (touch.phase == TouchPhase.Moved)
			{
				var deltaX = touch.position.x - initialTouch.position.x; //greater than 0 is right and less than zero is left
				var deltaY = touch.position.y - initialTouch.position.y; //greater than 0 is up and less than zero is down
				var swipeDistance = Mathf.Abs(deltaX) + Mathf.Abs(deltaY);

				if (swipeDistance > minSwipeDistance && (Mathf.Abs(deltaX) > 0 || Mathf.Abs(deltaY) > 0))
				{
					swiping = true;

					CalculateSwipeDirection(deltaX, deltaY);
				}
			}
			else if (touch.phase == TouchPhase.Ended)
			{
				initialTouch = new Touch();
				swiping = false;
				direction = SwipeDirection.None;
			}
			else if (touch.phase == TouchPhase.Canceled)
			{
				initialTouch = new Touch();
				swiping = false;
				direction = SwipeDirection.None;
			}
		}
	}

	void CalculateSwipeDirection(float deltaX, float deltaY)
	{
		bool isHorizontalSwipe = Mathf.Abs(deltaX) > Mathf.Abs(deltaY);

		// horizontal swipe
		if (isHorizontalSwipe && Mathf.Abs(deltaY) <= errorRange)
		{
			//right
			if (deltaX > 0) {
				direction = SwipeDirection.Right;
				messageText.text = "right";
				if (signUp.transform.position.x < Screen.width) {
					signUp.transform.position += new Vector3 (deltaX, 0, 0);
				}
				//var active = signUp.activeSelf;
				//signUp.SetActive (!active);
				//logIn.SetActive (active);

			}
			//left
			else if (deltaX < 0) {
				direction = SwipeDirection.Left;
				messageText.text = "left";

			}
		}
		//vertical swipe
		else if (!isHorizontalSwipe && Mathf.Abs(deltaX) <= errorRange)
		{
			//up
			if (deltaY > 0) {
				messageText.text =  "up";
				direction = SwipeDirection.Up;
			}
			//down
			else if (deltaY < 0) {
				messageText.text = "down";
				direction = SwipeDirection.Down;
			}
		}
		//diagonal swipe
		else
		{
			swiping = false;
		}
	}
}