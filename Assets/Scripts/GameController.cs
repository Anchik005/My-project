using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject[] _offGameObjects;
    private CinemachineDollyCart _CDC;
    private bool _played = false;
    public bool _gameStarted = false;
    [SerializeField] private Material _sphereMaterial;

    public void Awake()
    {
        _sphereMaterial.color = Color.clear;
        _played = false;
    }

    private void Start()
    {
        _CDC = GetComponent<CinemachineDollyCart>();
    }

    private void Update()
    {
        if (_CDC.m_Position >= 277 && !_played)
        {
            EndGame();
        }
    }

    public void StartGame()
    {
        foreach (var gObject in _offGameObjects)
        {
            gObject.SetActive(false);
        }
        
        _gameStarted = true;
        _CDC.m_Speed = 3.0f;
    }

    public void EndGame()
    {
        _sphereMaterial.color = Color.black;
        _played = true;
    }
}
