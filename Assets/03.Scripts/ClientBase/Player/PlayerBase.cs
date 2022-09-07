using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    [SerializeField]
    private PlayerInfo m_PInfo;

    public PlayerInfo PLAYER_INFO { get { return m_PInfo; } }

    private PlayerMove m_PMOVE;
    private Queue<Message> m_MQueue;

    public Action<PlayerInfo> OnMove = null;
    public Action<PlayerInfo> OutMove = null;
    public Action<PlayerInfo> OnMoveMouse = null;

    private void Awake()
    {
        m_MQueue = new Queue<Message>();
        m_PMOVE = GetComponent<PlayerMove>();

        OnMove += m_PMOVE.StartMove;
        OutMove += m_PMOVE.EndMove;
        OnMoveMouse += m_PMOVE.StartTurn;

        Init();
    }

    public void Init()
    {
        m_PInfo = new PlayerInfo("", 0, transform.position, transform.eulerAngles, 5);
        //
        PlayerManager.CONTROLLING_CHARACTER = this;
    }

    private void Update()
    {
        CheckMessage();
    }

    private void CheckMessage()
    {
        while (m_MQueue.Count > 0)
        {
            Message msg = m_MQueue.Dequeue();
            switch (msg)
            {
                case Message.PLAYER_MOVE:
                    {
                        OnMove?.Invoke(m_PInfo);
                        break;
                    }
                case Message.CANCEL:
                    {
                        OutMove?.Invoke(m_PInfo);
                        break;
                    }
                case Message.PLAYER_TURN:
                    {
                        OnMoveMouse?.Invoke(m_PInfo);
                        break;
                    }
            }
        }
    }

    public void AddMessage(Message msg)
    {
        m_MQueue.Enqueue(msg);
    }
}
