using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	[Header("Preferences")]
	private GameObject target;
	[SerializeField] private float cameraVerticalOffset;

	private bool canFollow = true;
	private float initY;

	private void LateUpdate()
	{
		if (target != null && canFollow) Follow();
	}
	public void SetTarget(GameObject target)
	{
		this.target = target;
		initY = target.transform.position.y;
	}
	private void Follow()
	{
		Vector3 targetPosition = target.transform.position;
		transform.position = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
	}
}