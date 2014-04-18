using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	public Transform target;
	public float distance = 0.0f;

	float centerX = Screen.width / 2;
	float centerY = Screen.height / 2;

	float mouseX = Input.mousePosition.x;
	float mouseY = Input.mousePosition.y;

	public float xSpeed = 0.1f;
	public float ySpeed = 0.1f;

	public float yMinLimit = -20;
	public float yMaxLimit = 80;

	private float x = 0.0f;
	private float y = 0.0f;

	void Start (){
		var angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;

		// Make the rigid body not change rotation
		if (rigidbody)
			rigidbody.freezeRotation = true;
	}

	void Update ()
	{
		mouseX = Input.mousePosition.x;
		mouseY = Input.mousePosition.y;
		if (target)
		{
			if(Mathf.Abs(mouseX - centerX) > (centerX / 2)){
				x += (mouseX - centerX) * xSpeed * Time.deltaTime;
			}
			if(Mathf.Abs(mouseY - centerY) > (centerY / 2)){
				y -= (mouseY - centerY) * ySpeed * Time.deltaTime;
			}

			y = ClampAngle(y, yMinLimit, yMaxLimit);

			transform.rotation = Quaternion.Euler(y, x, 0);
		}
	}

	static float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360)
		{
			angle += 360;
		}
		if (angle > 360)
		{
			angle -= 360;
		}
		return Mathf.Clamp(angle, min, max);
	}
}
