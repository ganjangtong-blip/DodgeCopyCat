// ���� �����ϴ� ���(SceneManager)�� ����ϱ� ���� �� �߰��ؾ� �մϴ�.
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    // Update �Լ��� �� �����Ӹ��� ȣ��˴ϴ�.
    void Update()
    {
        // ���� �����̽��� Ű�� ������ '����'�̶��
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // "GameScene"�̶�� �̸��� ���� �ҷ��ɴϴ�.
            // ����ǥ ���� �̸��� �ݵ�� �ҷ��� �� ������ �̸��� ��Ȯ�� ���ƾ� �մϴ�!
            SceneManager.LoadScene("SampleScene");
        }
    }
}