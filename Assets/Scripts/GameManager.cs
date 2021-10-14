using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public int peerToysTotal;

	public int peerToysMatched;

	public Transform parentToys;

	public GameObject collideHelper;

	public Matcher matcher;

	public UIFonctions canvas;

	public ParticleSystem winEffect;

	public LevelsManager levelsManager;

	public AudioManager audioManager;

	private void Start()
	{
	}

	public void StartPlay()
	{
		StartCoroutine("StartLately");
	}

	private IEnumerator StartLately()
	{
		yield return new WaitForSeconds(2f);
		collideHelper.SetActive(value: false);
		matcher.StartMatching();
	}

	public void LoadLevel(LevelSc lvl)
	{
		for (int i = 0; i < parentToys.childCount; i++)
		{
			UnityEngine.Object.Destroy(parentToys.GetChild(i).gameObject);
		}
		int num = 0;
		foreach (GameObject toy in lvl.toys)
		{
			Object.Instantiate(toy, new Vector3(UnityEngine.Random.Range(-4f, 4f), UnityEngine.Random.Range(3.5f, 12.5f), UnityEngine.Random.Range(-6f, 5f)), Quaternion.identity, parentToys);
			Object.Instantiate(toy, new Vector3(UnityEngine.Random.Range(-4f, 4f), UnityEngine.Random.Range(3.5f, 12.5f), UnityEngine.Random.Range(-6f, 5f)), Quaternion.identity, parentToys);
			num++;
		}
		peerToysTotal = num;
		peerToysMatched = 0;
		canvas.UpdateProgressBar(peerToysMatched, peerToysTotal);
	}

	public void DestroyAllToys()
	{
		for (int i = 0; i < parentToys.childCount; i++)
		{
			UnityEngine.Object.Destroy(parentToys.GetChild(i).gameObject);
		}
		matcher.CleanToysMatch();
	}

	public void SetToysNum(int total)
	{
		peerToysTotal = total;
	}

	public void PeerToysMatched()
	{
		peerToysMatched++;
		canvas.UpdateProgressBar(peerToysMatched, peerToysTotal);
		canvas.ShowStarFlying();
		if (peerToysMatched == peerToysTotal)
		{
			win();
		}
	}

	public void win()
	{
		audioManager.PlayWonSound();
		winEffect.Play();
		canvas.FinishScreen();
		levelsManager.NextLevel(canvas.timerSeconds);
		//ADManager.Display_InterstitialAd();
		Vibration.Vibrate(75L);
	}
}
