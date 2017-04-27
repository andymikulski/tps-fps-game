using UnityEngine;
using System.Collections;

public class MouseOrbit : MonoBehaviour {
	public Camera camera;
	public GameObject cameraGroup;
	public Transform target;

	private float vertical;
	private float horiz;
	private float ySpeed = 4.0f;
	private float xSpeed = 4.0f;

	private Vector3 offset;

	void Start ()
	{
		offset = camera.transform.position - gameObject.transform.position;
		vertical = transform.eulerAngles.x;
		horiz = transform.eulerAngles.y;
	}

	void Update ()
	{
		Cursor.lockState = CursorLockMode.Locked;

		float mouseVertical = Input.GetAxis ("Mouse Y");
		float mouseHorizontal = Input.GetAxis ("Mouse X") * -1f;

		// horizontal axis actually rotates around character
		cameraGroup.transform.RotateAround (target.transform.position, Vector3.down, mouseHorizontal * xSpeed);

		// vert rotates the camera at its actual axis
		vertical = (vertical - ySpeed * mouseVertical) % 360f;
		vertical = Mathf.Clamp(vertical, -30, 60);
		camera.transform.localRotation = Quaternion.AngleAxis (vertical, Vector3.right);
	}
}
