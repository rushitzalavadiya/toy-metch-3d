using DG.Tweening;
using System.Collections;
using UnityEngine;

public class TouchControllerSc : MonoBehaviour
{
	private Transform holdenObject;

	private RaycastHit hit;

	private Vector3 offset;

	private Vector3 screenPos;

	public LayerMask draggableLayer;

	private float yPicking = 2.5f;

	public bool mobileControl;

	public AudioManager audioManager;

	private void Update()
	{
		if (UnityEngine.Input.touchCount > 0)
		{
			Touch touch = UnityEngine.Input.GetTouch(0);
			if (touch.phase == TouchPhase.Began && Physics.Raycast(Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition), out hit, 100f, draggableLayer))
			{
				holdenObject = hit.transform;
				screenPos = Camera.main.WorldToScreenPoint(new Vector3(holdenObject.position.x, yPicking, holdenObject.position.z));
				offset = holdenObject.position - Camera.main.ScreenToWorldPoint(new Vector3(UnityEngine.Input.mousePosition.x, UnityEngine.Input.mousePosition.y, screenPos.z));
				StartCoroutine("PickUp");
				holdenObject.GetComponentInParent<ToyScript>().PickUp();
				holdenObject.GetComponentInParent<ToyScript>().Defreeze();
			}
			if (holdenObject != null)
			{
				Vector3 position = new Vector3(UnityEngine.Input.mousePosition.x, UnityEngine.Input.mousePosition.y, screenPos.z);
				Vector3 position2 = Camera.main.ScreenToWorldPoint(position) + offset;
				holdenObject.position = position2;
			}
			if (touch.phase == TouchPhase.Ended && holdenObject != null)
			{
				holdenObject.GetComponentInParent<ToyScript>().Release();
				holdenObject = null;
				StopCoroutine("PickUp");
				holdenObject.DOKill();
			}
		}
	}

	private IEnumerator PickUp()
	{
		audioManager.PlayPickUpToy();
		holdenObject.DOMoveY(yPicking, 0.3f);
		yield return new WaitForSeconds(0.25f);
		offset = new Vector3(holdenObject.position.x, yPicking, holdenObject.position.z) - Camera.main.ScreenToWorldPoint(new Vector3(UnityEngine.Input.mousePosition.x, UnityEngine.Input.mousePosition.y, screenPos.z));
	}
}
