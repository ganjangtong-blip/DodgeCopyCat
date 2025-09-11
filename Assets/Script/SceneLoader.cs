// 씬을 관리하는 기능(SceneManager)을 사용하기 위해 꼭 추가해야 합니다.
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    // Update 함수는 매 프레임마다 호출됩니다.
    void Update()
    {
        // 만약 스페이스바 키가 눌리는 '순간'이라면
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // "GameScene"이라는 이름의 씬을 불러옵니다.
            // 따옴표 안의 이름은 반드시 불러올 씬 파일의 이름과 정확히 같아야 합니다!
            SceneManager.LoadScene("SampleScene");
        }
    }
}