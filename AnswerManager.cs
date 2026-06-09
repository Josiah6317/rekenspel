using TMPro;
using UnityEngine;

public class AnswerManager : MonoBehaviour
{
	public static AnswerManager Instance { get; private set; }

	public TextMeshProUGUI lastAnswerText;
	public int lastAnswer;

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
			return;
		}
		Instance = this;
		// Uncomment if you want this to persist across scenes
		// DontDestroyOnLoad(gameObject);
	}

	public void SetLastAnswer(int value)
	{
		lastAnswer = value;
		if (lastAnswerText != null)
		{
			lastAnswerText.text = value.ToString();
		}
	}
}



