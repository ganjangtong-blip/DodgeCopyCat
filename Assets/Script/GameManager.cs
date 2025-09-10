using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // ← 꼭 추가

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public TextMeshProUGUI scoreText;   // TextMeshPro UGUI 타입
    public TextMeshProUGUI recordText;

    private bool isGameover;
    private int score;

    void Start()
    {
        isGameover = false;
        score = 0;

        // 안전하게 null 체크 후 초기화
        if (scoreText != null) scoreText.text = "Score: 0";
        else
        {
            Debug.LogError("GameManager: scoreText가 할당되지 않았습니다. Inspector에서 할당하세요.");
            // 옵션: 이름으로 찾아서 자동 할당 시도 (객체 이름이 ScoreText 일 때)
            GameObject go = GameObject.Find("ScoreText");
            if (go != null) scoreText = go.GetComponent<TextMeshProUGUI>();
            if (scoreText != null) scoreText.text = "Score: 0";
        }

        float bestScore = PlayerPrefs.GetFloat("BestScore", 0f);
        if (recordText != null) recordText.text = "Best Score: " + (int)bestScore;
    }

    void Update()
    {
        if (isGameover && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("sampleScene");
        }
    }

    public void AddScore(int amount)
    {
        if (isGameover) return;
        score += amount;
        if (scoreText != null) scoreText.text = "Score: " + score;
    }

    public void EndGame()
    {
        isGameover = true;
        if (gameoverText != null) gameoverText.SetActive(true);

        float bestScore = PlayerPrefs.GetFloat("BestScore", 0f);
        if (score > bestScore)
        {
            PlayerPrefs.SetFloat("BestScore", score);
            bestScore = score;
        }
        if (recordText != null) recordText.text = "Best Score: " + (int)bestScore;
    }
}

