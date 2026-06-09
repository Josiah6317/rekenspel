
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics;



public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public Transform[] points;

    public UnityEngine.UI.Text canvasText;
    public int answerValue;
    private string rekensomText;
    public UpdateTMPText uiText;

    private TMP_Text textComponent;

    private int i;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();



        int antwoord = (UnityEngine.Random.Range(2, 20));
        GenereerRekensom(antwoord);
        //canvasText = this.answerValue;
    }

    void Update()
    {
        if (points == null || points.Length == 0) return;

        if (Vector2.Distance(transform.position, points[i].position) < 0.25f)
        {
            i++;
            if (i == points.Length)
            {
                i = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        spriteRenderer.flipX = (transform.position.x - points[i].position.x) < 0f;
    }
    void GenereerRekensom(int antwoord)
    {
        string[] operators = { "+", "-", "*", "/" };
        string gekozenOperator = operators[UnityEngine.Random.Range(0, operators.Length)];

        int getal1, getal2;

        switch (gekozenOperator)
        {
            case "+":
                getal1 = UnityEngine.Random.Range(1, antwoord);
                getal2 = antwoord - getal1;
                break;
            case "-":
                getal1 = UnityEngine.Random.Range(antwoord, antwoord + 10);
                getal2 = getal1 - antwoord;
                break;
            case "*":
                getal1 = UnityEngine.Random.Range(1, antwoord);
                getal2 = antwoord / getal1;
                antwoord = getal1 * getal2;
                break;
            case "/":
                getal1 = antwoord * UnityEngine.Random.Range(1, 10);
                getal2 = getal1 / antwoord;
                break;
            default:
                getal1 = getal2 = 0;
                break;
        }
        this.answerValue = antwoord;
        if (uiText != null)
        {
            string som = $"{getal1} {gekozenOperator} {getal2} = ?";
            uiText.UpdateText(som);
           


        }
        uiText.gameObject.SetActive(false);

        if (canvasText != null)
        {
            canvasText.text = antwoord.ToString();
        }
        else
        {
            if (textComponent == null)
            {
                textComponent = GetComponentInChildren<TMPro.TMP_Text>();
            }
            if (textComponent != null)
            {
                textComponent.text = antwoord.ToString();
            }
        }
        UnityEngine.Debug.Log($"De rekensom is: {getal1} {gekozenOperator} {getal2} = {antwoord}");
    }

    public void Respawn(Vector3 spawnPosition)
    {
        transform.position = spawnPosition;           // Move enemy
        GenerateNewRekensom();                        // Generate a new question
        gameObject.SetActive(true);                   // Make it visible
    }

    // Helper to generate a random rekensom
    public void GenerateNewRekensom()
    {
        int antwoord = UnityEngine.Random.Range(2, 20);
        GenereerRekensom(antwoord);
    }


}
