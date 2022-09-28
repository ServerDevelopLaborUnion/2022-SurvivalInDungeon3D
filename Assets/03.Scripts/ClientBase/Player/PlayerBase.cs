using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : UnitBase
{
    public override void Init()
    {
        m_PInfo = new UnitInfo("", "0", transform.position, transform.eulerAngles, 5);
        //
        PlayerManager.CONTROLLING_CHARACTER = this;
    }
}
