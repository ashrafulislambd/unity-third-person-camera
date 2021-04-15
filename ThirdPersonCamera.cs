using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour {
	[Header("Setup")]
	[SerializeField] private Transform screw;
	[SerializeField] private Transform handle;
	[SerializeField] private Transform cameraPlaceholder;
	[SerializeField] private Camera cam;

	[Space(5)]
	[Header("Customize Settings")]
	[SerializeField] private float radius = 3;
	[SerializeField] private float MouseSensitivityX = 5;
	[SerializeField] private float MouseSensitivityY = 3;
	[SerializeField] private float HorizontalClampMin = -45;
	[SerializeField] private float HorizontalClampMax = 45;


	float currentHandleRotation = 0f;

	void Update () {
		screw.Rotate (0, Input.GetAxis ("Mouse X") * MouseSensitivityX , 0);
		currentHandleRotation += Input.GetAxis("Mouse Y") * MouseSensitivityY;
		currentHandleRotation = Mathf.Clamp (currentHandleRotation, HorizontalClampMin, HorizontalClampMax);

		float yRot = handle.rotation.eulerAngles.y;
		float zRot = handle.rotation.eulerAngles.z;
		handle.eulerAngles = new Vector3 (currentHandleRotation, yRot, zRot);

		PositionCamera ();
	}

	void PositionCamera() {
		Vector3 pos = transform.position;
		Vector3 dirNorm = (cameraPlaceholder.position - pos).normalized;
		pos += dirNorm * radius;

		RaycastHit hit;
		int PlayerMask = ~(1 << 8);
		if (Physics.Raycast (transform.position, dirNorm, out hit, radius, PlayerMask)) {
			cam.transform.position = hit.point;
			cam.transform.LookAt (transform);
		} else {
			cam.transform.position = pos;
			cam.transform.LookAt (transform);
		}
	}
}
