using Cinemachine;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pop : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private CinemachineDollyCart docart;
    private bool played = false;
    private void Start()
    {
        docart = GetComponent<CinemachineDollyCart>();
    }
    private void Update()
    {
        if (docart.m_Position > 272 && !played)
        {
            animator.SetTrigger("ivy");
            played = true;
        }
    }
}
