using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBase : MonoBehaviour
{
    [SerializeField]
    protected UnitInfo m_PInfo;

    public UnitInfo PLAYER_INFO { get { return m_PInfo; } }

    private PlayerMove m_PMOVE;
    private Queue<Message> m_MQueue;

    public Action<UnitInfo> OnMove = null;
    public Action<UnitInfo> OutMove = null;
    public Action<UnitInfo> OnMoveMouse = null;

    private void Awake()
    {
        m_MQueue = new Queue<Message>();
        m_PMOVE = GetComponent<PlayerMove>();

        OnMove += m_PMOVE.StartMove;
        OutMove += m_PMOVE.EndMove;
        OnMoveMouse += m_PMOVE.StartTurn;

        Init();
    }

    public virtual void Init()
    {

    }

    private void Start()
    {
        Connection.Send(m_PInfo);
    }

    private void Update()
    {
        CheckMessage();
        if(Input.GetKeyUp(KeyCode.Escape))
            Connection.Send(m_PInfo);
    }

    private void CheckMessage()
    {
        while (m_MQueue.Count > 0)
        {
            Message msg = m_MQueue.Dequeue();
            switch (msg)
            {
                case Message.UNIT_MOVE:
                    {
                        OnMove?.Invoke(m_PInfo);
                        break;
                    }
                case Message.CANCEL:
                    {
                        OutMove?.Invoke(m_PInfo);
                        break;
                    }
                case Message.UNIT_TURN:
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
