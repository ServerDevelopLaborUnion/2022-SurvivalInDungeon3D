using static Yields;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private UnitInfo pInfo;
    [SerializeField]
    private bool m_IsMove = false;
    [SerializeField]
    private float m_dustDelay = 0.5f;
    [SerializeField]
    private GameObject m_dust = null;

    private bool m_IsRotate = false;
    private Vector3 m_dir = Vector3.zero;
    private Vector3 m_MouseDir = Vector3.zero;
    private float m_gravity = 4f;
    private CharacterController m_CharacterController;
    private void Awake()
    {
        m_CharacterController = GetComponent<CharacterController>();
        
        pInfo = GetComponent<PlayerBase>().PLAYER_INFO;

        StartCoroutine(Dust());
    }
    public void Translate()
    {
        m_CharacterController.Move(m_dir.normalized * Time.deltaTime * pInfo.Speed);
        pInfo.Move(transform.position);
    }
    public void GetGravity()
    {
        m_CharacterController?.Move(Vector3.up * Physics.gravity.y * Time.deltaTime);
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
            GetGravity();
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
            Vector3 pos2 = transform.position - m_CharacterController.center;
            float value = m_CharacterController.height * 0.5f - m_CharacterController.radius;

            pos2.y -= value + m_CharacterController.skinWidth + 0.05f;
            Gizmos.DrawSphere(pos2, m_CharacterController.radius);
        }
        catch { }
    }
    Vector3 pos2;

    public bool IsGround()
    {
        Vector3 pos2 = transform.position - m_CharacterController.center;
        float value = m_CharacterController.height * 0.5f - m_CharacterController.radius;

        pos2.y -= value + m_CharacterController.skinWidth + 0.05f;

        return Physics.CheckSphere(pos2, m_CharacterController.radius, LayerMask.GetMask("GROUND"));
    }

    // TODO : 1. 풀링 안함
    //        2. 애니메이션에서 발에 닿을 때만 터지는 것으로 변경해야함 -> 이럴 경우 풀링이 필요 없을 수도 있음
    private IEnumerator Dust()
    {
        while(true)
        {
            yield return WaitUntil(() => m_IsMove);
            m_dust.SetActive(true);
            yield return WaitForSeconds(m_dustDelay);
            m_dust.SetActive(false);
            yield return WaitForSeconds(m_dustDelay);

        }
    }

}
