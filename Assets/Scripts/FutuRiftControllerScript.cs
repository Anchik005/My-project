using UnityEngine;
using ChairControl.ChairWork;
using ChairControl.ChairWork.Options;

public class FutuRiftControllerScript : MonoBehaviour
{
    private FutuRiftController controller;
    // Настройки для UDP-соединения
    public string ipAddress = "127.0.0.1";
    public int ports = 6065;
    // Настройки для углов
    public float initialPitch = 0.0f;
    public float initialRoll = 0.0f;
    // Настройки интервала передачи данных
    public int interval = 100;
    void Start()
    {
        // Создаем экземпляр UdpOptions
        var udpOptions = new UdpOptions
        {
            ip = ipAddress,
            port = ports
        };
        // Создаем экземпляр FutuRiftOptions
        var futuRiftOptions = new FutuRiftOptions
        {
            interval = interval
        };
        // Создаем экземпляр FutuRiftController
        controller = new FutuRiftController(
            udpOptions: udpOptions,
            futuRiftOptions: futuRiftOptions
        );
        // Настраиваем начальные значения углов
        controller.Pitch = initialPitch;
        controller.Roll = initialRoll;
        // Запускаем контроллер
        controller.Start();
    }
    void OnDisable()
    {
        // Останавливаем контроллер, когда скрипт отключается
        if (controller != null)
        {
            controller.Stop();
        }
    }
    void Update()
    {
        var euler = transform.eulerAngles;
        controller.Pitch = (euler.x > 180 ? euler.x - 360 : euler.x);
        controller.Roll = (euler.z > 180 ? euler.z - 360 : euler.z);
    }
}