using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics;

public class AnswerButton : MonoBehaviour
{
    public Enemy targetEnemy; // Assign the enemy this button is linked to
    public TextMeshProUGUI buttonText;
    public Enemy Enemyscript;

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        UnityEngine.Debug.Log($"Button text is: '{buttonText.text}'");

        if (int.TryParse(buttonText.text, out int playerAnswer))
        {
            if (playerAnswer == Enemyscript.answerValue)
            {
                UnityEngine.Debug.Log("Correct!");
                buttonText.text = ""; // Clear the button text
               /* targetEnemy.ShowNextSom(); // Generate next som on enemy*/
            }
            else
            {
                UnityEngine.Debug.Log("Wrong answer.");
            }
        }
        else
        {
            UnityEngine.Debug.Log("Invalid input.");
        }
    }
}
