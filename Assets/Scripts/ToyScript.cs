using DG.Tweening;
using System.Collections;
using UnityEngine;

public class ToyScript : MonoBehaviour
{
	public bool picking;

	private bool freezed;

	public bool isMatching;

	private Rigidbody rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void Start()
	{
		base.transform.GetChild(0).gameObject.layer = 8;
		base.transform.DOPunchScale(Vector3.one, 0.5f, 0, 0f);
	}

	public void PickUp()
	{
		picking = true;
	}

	public void Release()
	{
		picking = false;
	}

	public void FreezAtPos()
	{
		isMatching = true;
		freezed = true;
		rb.constraints = (RigidbodyConstraints)122;
		base.transform.DOScale(Vector3.one * 0.85f, 0.5f);
	}

	public void ResetScale()
	{
		base.transform.DOScale(Vector3.one, 0.1f);
	}

	public void Defreeze()
	{
		ResetScale();
		if (freezed)
		{
			isMatching = false;
			Object.FindObjectOfType<Matcher>().RemoveToy(base.transform.GetChild(0));
			rb.constraints = RigidbodyConstraints.None;
			freezed = false;
		}
	}

	public void SetUpForThrowing()
	{
		isMatching = false;
		rb.constraints = RigidbodyConstraints.None;
		freezed = false;
		picking = true;
		ResetScale();
	}

	public void DestroyToy()
	{
		StartCoroutine(WaitAndDestroy());
	}

	private IEnumerator WaitAndDestroy()
	{
		yield return new WaitForSeconds(1.5f);
		UnityEngine.Object.Destroy(base.gameObject);
	}
}
