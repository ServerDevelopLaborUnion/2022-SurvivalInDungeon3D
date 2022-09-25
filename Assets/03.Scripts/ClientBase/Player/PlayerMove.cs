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
        if (!IsGround())
        {
            Debug.Log(1);
            m_dir += Vector3.down;
            Translate();
        }
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
        private void OnDrawGizmos()
    {
        try
        {
            Gizmos.color = Color.red;
            Vector3 pos2 = transform.position + m_CharacterController.center;
            float value = m_CharacterController.height * 0.5f - m_CharacterController.radius;

            pos2.y -= value + m_CharacterController.skinWidth + 0.001f;
            Gizmos.DrawSphere(pos2, m_CharacterController.radius);
        }
        catch { }
    }
    Vector3 pos2;

    private void OnGUI() {
        GUIStyle label = new GUIStyle();
        label.normal.textColor = Color.red;
        label.fontSize = 40;

        GUILayout.Label($"IsGround : {IsGround()}", label);
        GUILayout.Label($"IsGround : {pos2}", label);

    }

    public bool IsGround()
    {
        Vector3 pos2 = transform.position + m_CharacterController.center;
        float value = m_CharacterController.height * 0.5f - m_CharacterController.radius;

        pos2.y -= value + m_CharacterController.skinWidth + 0.001f;

        return Physics.CheckSphere(pos2, m_CharacterController.radius, LayerMask.GetMask("GROUND"));
    }

}
