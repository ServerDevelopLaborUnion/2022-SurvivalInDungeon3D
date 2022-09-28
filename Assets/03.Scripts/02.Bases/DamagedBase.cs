using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedBase : MonoBehaviour, IDamageAble
{
    // TODO: Hp가 UnitInfo의 Hp를 getter하게 바꾸기
    public int Hp{ get; private set; }
    public bool IsDead => Hp > 0;

    [SerializeField]
    private int _maxHp;
    [SerializeField]
    private LayerMask _hitLayer;

    private UnitInfo _unitInfo;

    private void Start() {
        Hp = _maxHp;
    }
    

    public void Damage(int damage)
    {
        Hp -= damage;
    }
}
