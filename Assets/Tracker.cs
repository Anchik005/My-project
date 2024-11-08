using UnityEngine;
using Cinemachine;

public class DollyCartPositionChecker : MonoBehaviour
{
    public CinemachineDollyCart dollyCart;
    public float targetPosition = 278;
    public GameObject button1;
    public GameObject button2;
    private bool _once = true;


    private void Update()
    {
        if (dollyCart.m_Position >= targetPosition && _once)
        {
            button1.gameObject.SetActive(true);
            button2.gameObject.SetActive(true);
            _once = false;
        }
    }
}