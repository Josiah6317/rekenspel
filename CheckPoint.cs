using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheckPoint : MonoBehaviour
{
    public GameObject uiText; // Assign this in the Inspector
    public UnityEngine.UI.Button checkpointButton;
    public UnityEngine.UI.Button checkpointButton2;
    public TextMeshProUGUI answerText;
    public TextMeshProUGUI answerText2;

    void OnCollisionEnter2D(Collision2D collision)
    {
  /*      if (collision.gameObject.CompareTag("Player"))
        {
            uiText.SetActive(true);
            *//*checkpointButton.interactable = true;
            checkpointButton2.interactable = true;*//*

            UnityEngine.Debug.Log("Collided with: " + collision.gameObject.name);
        }*/
    }


    void OnCollisionExit2D(Collision2D collision)
    {
     /*   if (collision.gameObject.CompareTag("Player"))
        {
            uiText.SetActive(false);
            checkpointButton.interactable = false;
            checkpointButton2.interactable = false;
        }*/
    }
    private void ClearButtonText()
    {
        if (answerText != null) answerText.text = "";
        if (answerText2 != null) answerText2.text = "";
        UnityEngine.Debug.Log("Button text cleared");
    }
}

