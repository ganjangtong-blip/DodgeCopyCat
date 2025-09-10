using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // �� �� �߰�

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public TextMeshProUGUI scoreText;   // TextMeshPro UGUI Ÿ��
    public TextMeshProUGUI recordText;

    private bool isGameover;
    private int score;

    void Start()
    {
        isGameover = false;
        score = 0;

        // �����ϰ� null üũ �� �ʱ�ȭ
        if (scoreText != null) scoreText.text = "Score: 0";
        else
        {
            Debug.LogError("GameManager: scoreText�� �Ҵ���� �ʾҽ��ϴ�. Inspector���� �Ҵ��ϼ���.");
            // �ɼ�: �̸����� ã�Ƽ� �ڵ� �Ҵ� �õ� (��ü �̸��� ScoreText �� ��)
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

