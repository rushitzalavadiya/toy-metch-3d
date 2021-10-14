using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
	private int level;

	public TextMeshProUGUI levelText;

	public TextMeshProUGUI timerText;

	public void SetLevelButton(int levelNum, int time, bool unlocked)
	{
		level = levelNum;
		levelText.text = levelNum.ToString();
		timerText.text = $"{time / 60:0}:{time % 60:00}" + "''";
		if (!unlocked)
		{
			LockLevel();
		}
	}

	public void LockLevel()
	{
		GetComponent<Button>().interactable = false;
	}

	public void UnlockLevel()
	{
		GetComponent<Button>().interactable = true;
	}

	public void LoadThisLevel()
	{
		Object.FindObjectOfType<LevelsManager>().SetLevel(level);
	}
}
