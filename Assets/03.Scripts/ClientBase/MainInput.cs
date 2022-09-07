using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainInput : MonoBehaviour
{
    private PlayerBase m_MyCharacter = null;
    private KeyCode m_MForKey = KeyCode.W;
    private KeyCode m_MBackKey = KeyCode.S;
    private KeyCode m_MRightKey = KeyCode.D;
    private KeyCode m_MLeftKey = KeyCode.A;

    private void Start()
    {
        m_MyCharacter = PlayerManager.CONTROLLING_CHARACTER;
    }

    private void Update()
    {

        if (Input.GetKeyDown(m_MForKey))
        {
            m_MyCharacter.PLAYER_INFO.SetDir(Vector3.forward);
            m_MyCharacter.AddMessage(Message.PLAYER_MOVE);
        }
        if (Input.GetKeyUp(m_MForKey))
        {
            m_MyCharacter.PLAYER_INFO.SetDir(-Vector3.forward);
            m_MyCharacter.AddMessage(Message.PLAYER_MOVE);
        }

        if (Input.GetKeyDown(m_MBackKey))
        {
            m_MyCharacter.PLAYER_INFO.SetDir(Vector3.back);
            m_MyCharacter.AddMessage(Message.PLAYER_MOVE);
        }
        if (Input.GetKeyUp(m_MBackKey))
        {
            m_MyCharacter.PLAYER_INFO.SetDir(-Vector3.back);
            m_MyCharacter.AddMessage(Message.PLAYER_MOVE);
        }

        if (Input.GetKeyDown(m_MLeftKey))
        {
            m_MyCharacter.PLAYER_INFO.SetDir(Vector3.left);
            m_MyCharacter.AddMessage(Message.PLAYER_MOVE);
        }
        if (Input.GetKeyUp(m_MLeftKey))
        {
            m_MyCharacter.PLAYER_INFO.SetDir(-Vector3.left);
            m_MyCharacter.AddMessage(Message.PLAYER_MOVE);
        }

        if (Input.GetKeyDown(m_MRightKey))
        {
            m_MyCharacter.PLAYER_INFO.SetDir(Vector3.right);
            m_MyCharacter.AddMessage(Message.PLAYER_MOVE);
        }
        if (Input.GetKeyUp(m_MRightKey))
        {
            m_MyCharacter.PLAYER_INFO.SetDir(-Vector3.right);
            m_MyCharacter.AddMessage(Message.PLAYER_MOVE);
        }

        if (!Input.anyKey)
        {
            m_MyCharacter.AddMessage(Message.CANCEL);
        }

        RaycastHit hit;
        Ray ray = Define.MainCam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("GROUND")))
        {
            m_MyCharacter.PLAYER_INFO.Rotation(Quaternion.Slerp
                (
                    m_MyCharacter.transform.rotation,
                    Quaternion.LookRotation((hit.point - m_MyCharacter.transform.position).normalized),
                    0.2f).eulerAngles
                );
            m_MyCharacter.AddMessage(Message.PLAYER_TURN);
        }
    }
}
