using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button button1; // ������ ��� �������� �����
    public Button button2; // ������ ��� ������ �� ����
    public string sceneName; // ��� �����, ������� ����� ���������

    void Start()
    {
        button1.onClick.AddListener(HandleButtonClick);
        button2.onClick.AddListener(HandleButtonClick);
    }

    public void HandleButtonClick()
    {
        // ���������, ����� ������ ���� ������
        if (EventSystem.current.currentSelectedGameObject == button1.gameObject)
        {
            // ��������� �����
            SceneManager.LoadScene(sceneName);
        }
        else if (EventSystem.current.currentSelectedGameObject == button2.gameObject)
        {
            // ������� �� ����
            Application.Quit();
        }
    }
}