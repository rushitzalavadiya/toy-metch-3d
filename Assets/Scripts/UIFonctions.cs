using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIFonctions : MonoBehaviour
{
	public TextMeshProUGUI level;

	public TextMeshProUGUI level_2;

	public TextMeshProUGUI timer;

	public Image progressBar;

	public Animator anim;

	public Button playBtn;

	public TextMeshProUGUI stars;

	public int timerSeconds;

	public GameManager gameManager;

	public LevelsManager levelsManager;

	public AudioManager audioManager;

	private void Awake()
	{
		if (PlayerPrefs.GetInt("Level") < 1)
		{
			PlayerPrefs.SetInt("Level", 1);
		}
	}

	private void Start()
	{
		level.text = "Lvl " + PlayerPrefs.GetInt("Level").ToString("00");
		level_2.text = PlayerPrefs.GetInt("Level").ToString("00");
		UpdateStars();
	}

	public void SetLevel(int num)
	{
		level.text = "Lvl " + num;
	}

	private IEnumerator CalculateTime()
	{
		timerSeconds = 0;
		while (true)
		{
			timer.text = $"{timerSeconds / 60:00}:{timerSeconds % 60:00}";
			yield return new WaitForSeconds(1f);
			timerSeconds++;
		}
	}

	public void UpdateProgressBar(float matched, float total)
	{
		progressBar.DOFillAmount(matched / total, 1f);
	}

	public void ShowLevels()
	{
		anim.SetBool("DisplayLevels", !anim.GetBool("DisplayLevels"));
	}

	public void StartPlaying()
	{
		playBtn.interactable = false;
		anim.SetBool("StartScreen", value: false);
		levelsManager.LoadCurrentLevel();
		gameManager.StartPlay();
		anim.SetBool("FinishScreen", value: false);
		UpdateLevelTxt(levelsManager.currentLevel);
		StartCoroutine("CalculateTime");
	}

	public void ShowStarFlying()
	{
		anim.SetTrigger("AddStar");
	}

	public void AddStar()
	{
		PlayerPrefs.SetInt("Stars", PlayerPrefs.GetInt("Stars") + 1);
		UpdateStars();
		audioManager.PlayCollectStar();
	}

	public void UpdateStars()
	{
		stars.text = PlayerPrefs.GetInt("Stars").ToString("000");
	}

	public void FinishScreen()
	{
		StopCoroutine("CalculateTime");
		anim.SetBool("FinishScreen", value: true);
	}

	public void UpdateLevelTxt(int currentLevel)
	{
		level.text = "Lvl " + currentLevel.ToString("00");
		level_2.text = currentLevel.ToString("00");
	}

	public void HomeButton()
	{
		StopCoroutine("CalculateTime");
		anim.SetBool("StartScreen", value: true);
		gameManager.DestroyAllToys();
	}
}
