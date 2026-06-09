using System.Diagnostics;
using TMPro;
using UnityEngine;

public class UpdateTMPText : MonoBehaviour
{
    public TextMeshProUGUI tmpText; 


    public void UpdateText(string newText)
    {
        if (tmpText != null)
        {
            tmpText.text = newText;
        }
        else
        {
            UnityEngine.Debug.LogWarning("TMP Text is not assigned in the Inspector!");
        }
    }
}
