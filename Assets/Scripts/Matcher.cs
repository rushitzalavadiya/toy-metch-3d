using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Matcher : MonoBehaviour
{
	public Animator anim;

	public Transform pointOne;

	public Transform pointTwo;

	public Transform center;

	public Transform toyOne;

	public Transform toyTwo;

	public int inMatch;

	public Collider detectCollider;

	public Collider barrierCollider;

	public GameManager manager;

	public AudioManager audioManager;

	private void Start()
	{
		detectCollider.enabled = false;
		barrierCollider.enabled = true;
	}

	public void StartMatching()
	{
		detectCollider.enabled = true;
		barrierCollider.enabled = false;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 8)
		{
			anim.SetBool("Detecting", value: true);
			anim.SetTrigger("Detect");
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.layer == 8)
		{
			anim.SetBool("Detecting", value: false);
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.layer == 8 && !other.GetComponentInParent<ToyScript>().picking && other.transform != toyOne && other.transform != toyTwo)
		{
			MatchToy(other.transform);
			anim.SetBool("Detecting", value: false);
		}
	}

	public void MatchToy(Transform toy)
	{
		if (inMatch == 1)
		{
			inMatch = 2;
			toy.parent.DOMoveX(pointTwo.position.x, 0.2f);
			toy.parent.DOMoveZ(pointTwo.position.z, 0.2f);
			toy.parent.DORotate(Vector3.zero, 0.2f);
			toy.GetComponentInParent<ToyScript>().FreezAtPos();
			toyTwo = toy;
			MatchCheck();
			audioManager.PlayToyToMatcher();
			Vibration.Vibrate(40L);
		}
		if (inMatch == 0)
		{
			inMatch = 1;
			toy.parent.DOMoveX(pointOne.position.x, 0.2f);
			toy.parent.DOMoveZ(pointOne.position.z, 0.2f);
			toy.parent.DORotate(Vector3.zero, 0.2f);
			toy.GetComponentInParent<ToyScript>().FreezAtPos();
			toyOne = toy;
			audioManager.PlayToyToMatcher();
			Vibration.Vibrate(40L);
		}
	}

	public void RemoveToy(Transform toy)
	{
		if (toy == toyOne)
		{
			toyOne = null;
			inMatch--;
		}
		if (toy == toyTwo)
		{
			toyTwo = null;
			inMatch--;
		}
	}

	public void MatchCheck()
	{
		if (toyOne.GetComponent<MeshFilter>().sharedMesh == toyTwo.GetComponent<MeshFilter>().sharedMesh)
		{
			StartCoroutine(Matched());
		}
		else
		{
			StartCoroutine(ThrowSecondToy());
		}
	}

	public IEnumerator ThrowSecondToy()
	{
		yield return new WaitForSeconds(0.25f);
		toyTwo.parent.DOKill();
		Rigidbody componentInParent = toyTwo.GetComponentInParent<Rigidbody>();
		anim.SetTrigger("Throw");
		toyTwo.GetComponentInParent<ToyScript>().SetUpForThrowing();
		RemoveToy(toyTwo);
		componentInParent.AddForce(new Vector3(0f, 1f, 1f) * 500f, ForceMode.Force);
		Vibration.Vibrate(120L);
	}

	public IEnumerator Matched()
	{
		yield return new WaitForSeconds(0.2f);
		toyTwo.gameObject.layer = 9;
		toyOne.gameObject.layer = 9;
		anim.SetTrigger("Open");
		toyTwo.parent.DOMove(center.position, 0.25f);
		toyOne.parent.DOMove(center.position, 0.25f);
		toyOne.parent.DOPunchScale(Vector3.one * 0.75f, 0.25f);
		toyTwo.parent.DOPunchScale(Vector3.one * 0.75f, 0.25f);
		yield return new WaitForSeconds(0.3f);
		toyTwo.parent.DOMove(center.position + new Vector3(0f, -2f, 0f), 0.2f);
		toyOne.parent.DOMove(center.position + new Vector3(0f, -2f, 0f), 0.2f);
		toyOne.GetComponentInParent<ToyScript>().DestroyToy();
		toyTwo.GetComponentInParent<ToyScript>().DestroyToy();
		RemoveToy(toyOne);
		RemoveToy(toyTwo);
		manager.PeerToysMatched();
	}

	public void CleanToysMatch()
	{
		toyOne = null;
		toyTwo = null;
		inMatch = 0;
	}

	public void PlayGateSound()
	{
		audioManager.PlayGateSound();
	}
}
