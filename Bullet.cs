using UnityEngine;
using TMPro;
using System.Collections;
using System.Diagnostics;
using System;

public class Bullet : MonoBehaviour
{
    public TextMeshProUGUI answerText;
    public TextMeshProUGUI answerText2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy")) return;

        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy == null) return;

        // Update answer manager and UI
        if (AnswerManager.Instance != null)
            AnswerManager.Instance.SetLastAnswer(enemy.answerValue);

        string answer = enemy.answerValue.ToString();
        if (answerText != null) answerText.text = answer;
        if (answerText2 != null) answerText2.text = answer;

        UnityEngine.Debug.Log("Collided with: " + collision.gameObject.name);

        // Hide enemy and start respawn
        enemy.gameObject.SetActive(false);
        StartCoroutine(RespawnEnemy(enemy));
    }

    private IEnumerator RespawnEnemy(Enemy enemy)
    {
        yield return new WaitForSeconds(2f);

        // Optional: random X spawn within -5 to 5
        Vector3 spawnPos = new Vector3(UnityEngine.Random.Range(-5f, 5f), enemy.transform.position.y, 0f);

        enemy.Respawn(spawnPos); // Respawn enemy with new question
    }
}
