using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private UnitInfo pInfo;
    [SerializeField]
    private bool m_IsMove = false;
    private bool m_IsRotate = false;
    private Vector3 m_dir = Vector3.zero;
    private Vector3 m_MouseDir = Vector3.zero;
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

    public void Rotate()
    {
        transform.eulerAngles = pInfo.EulerRotation.ToVector3();
        pInfo.Rotation(transform.eulerAngles);
    }

    private void Update()
    {
        if (m_IsMove)
        {
            Translate();
        }
        if (m_IsRotate)
        {
            Rotate();
        }
    }

    public void StartMove(UnitInfo info)
    {
        pInfo = info;
        m_dir = info.InputDir;
        m_IsMove = true;
    }

    public void EndMove(UnitInfo info)
    {
        m_dir = info.InputDir;
        m_IsMove = false;
    }

    public void StartTurn(UnitInfo info)
    {
        pInfo = info;
        m_MouseDir = info.InputDir;
        m_IsRotate = true;
    }

    public void EndTurn(UnitInfo info)
    {
        m_MouseDir = info.InputDir;
        m_IsRotate = false;
    }
}
