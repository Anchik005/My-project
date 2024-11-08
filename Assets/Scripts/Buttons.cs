using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button button1; // Кнопка для загрузки сцены
    public Button button2; // Кнопка для выхода из игры
    public string sceneName; // Имя сцены, которую нужно загрузить

    void Start()
    {
        button1.onClick.AddListener(HandleButtonClick);
        button2.onClick.AddListener(HandleButtonClick);
    }

    public void HandleButtonClick()
    {
        // Проверяем, какая кнопка была нажата
        if (EventSystem.current.currentSelectedGameObject == button1.gameObject)
        {
            // Загружаем сцену
            SceneManager.LoadScene(sceneName);
        }
        else if (EventSystem.current.currentSelectedGameObject == button2.gameObject)
        {
            // Выходим из игры
            Application.Quit();
        }
    }
}