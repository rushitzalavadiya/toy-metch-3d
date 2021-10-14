using UnityEngine;

public class LevelsManager : MonoBehaviour
{
	public int currentLevel = 1;

	public int maxUnlockedLevel = 1;

	public LevelSc[] levels;

	public Transform parentToys;

	public Transform levelContent;

	public GameObject levelUI;

	private int lastLevel;

	public GameManager manager;

	private void Start()
	{
		lastLevel = levels.Length;
		currentLevel = PlayerPrefs.GetInt("Level");
		maxUnlockedLevel = PlayerPrefs.GetInt("Level");
		LoadUILevels();
	}

	public void LoadUILevels()
	{
		for (int i = 0; i < levelContent.childCount; i++)
		{
			UnityEngine.Object.Destroy(levelContent.GetChild(i).gameObject);
		}
		int num = 1;
		LevelSc[] array = levels;
		for (int j = 0; j < array.Length; j++)
		{
			LevelSc levelSc = array[j];
			GameObject gameObject = UnityEngine.Object.Instantiate(levelUI, levelContent);
			if (num <= maxUnlockedLevel)
			{
				gameObject.GetComponent<LevelUI>().SetLevelButton(num, PlayerPrefs.GetInt("LevelTime " + num), unlocked: true);
			}
			else
			{
				gameObject.GetComponent<LevelUI>().SetLevelButton(num, PlayerPrefs.GetInt("LevelTime " + currentLevel), unlocked: false);
			}
			num++;
		}
	}

	public void SetLevel(int level)
	{
		currentLevel = level;
		Object.FindObjectOfType<UIFonctions>().UpdateLevelTxt(currentLevel);
	}

	public void LoadCurrentLevel()
	{
		manager.LoadLevel(levels[currentLevel - 1]);
	}

	public void NextLevel(int time)
	{
		if (time < PlayerPrefs.GetInt("LevelTime " + currentLevel) || PlayerPrefs.GetInt("LevelTime " + currentLevel) <= 0)
		{
			PlayerPrefs.SetInt("LevelTime " + currentLevel, time);
		}
		if (currentLevel == maxUnlockedLevel)
		{
			if (currentLevel < lastLevel)
			{
				NewLevelUnlocked();
			}
		}
		else if (currentLevel < lastLevel)
		{
			currentLevel++;
		}
	}

	public void NewLevelUnlocked()
	{
		PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
		currentLevel = PlayerPrefs.GetInt("Level");
		maxUnlockedLevel = PlayerPrefs.GetInt("Level");
	}
}
