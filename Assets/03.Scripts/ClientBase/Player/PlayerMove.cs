using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private PlayerInfo pInfo;
    [SerializeField]
    private bool m_IsMove = false;
    private Vector3 m_dir = Vector3.zero;
    private CharacterController m_CharacterController;
    private void Awake()
    {
        m_CharacterController = GetComponent<CharacterController>();
    }
    public void Translate()
    {
        m_CharacterController.Move(m_dir.normalized * Time.deltaTime * pInfo.Speed);
        pInfo.Move(transform.position);
    }

    private void Update()
    {
        if (m_IsMove)
        {
            Translate();
        }
    }

    public void StartMove(PlayerInfo info)
    {
        pInfo = info;
        m_dir = info.InputDir;
        m_IsMove = true;
    }

    public void EndMove(PlayerInfo info)
    {
        m_dir = info.InputDir;
        m_IsMove = false;
    }
}
