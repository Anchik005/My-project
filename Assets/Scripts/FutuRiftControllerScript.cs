using Futurift;
using Futurift.DataSenders;
using Futurift.Options;
using Unity.VisualScripting;
using UnityEngine;

public class FutuRiftControllerScript : MonoBehaviour
{
    private FutuRiftController _controller;

    private GameController _gameC;
    // Настройки для UDP-соединения
    public string ipAddress = "127.0.0.1";
    public int ports = 6065;

    private void Awake()
    {
        _gameC = GetComponent<GameController>();
        var udpOptions = new UdpOptions()
        {
            ip = ipAddress,
            port = ports
        };

        _controller = new FutuRiftController(new UdpPortSender(udpOptions));
    }

    private void OnEnable()
    {
        _controller?.Start();
    }

    void OnDisable()
    {
        _controller?.Stop();
    }

    void Update()
    {
        if (_gameC._gameStarted)
        {
            var euler = transform.eulerAngles;
            _controller.Pitch = (euler.x > 180 ? euler.x - 360 : euler.x);
            _controller.Roll = (euler.z > 180 ? euler.z - 360 : euler.z);
        }
    }
}
