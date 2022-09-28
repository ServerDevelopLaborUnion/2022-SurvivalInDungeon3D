using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class AttackBase : MonoBehaviour, IAttackAble
{
    [SerializeField]
    private LayerMask _hitLayer;

    private Collider _attackCol;
    private UnitInfo _unitInfo;

    // TODO: Atk가 UnitInfo의 Atk를 getter하게 바꾸기
    public int Atk{ get; set; }


    public bool IsAttack { get; private set; }

    /// <summary>
    /// 애니메이터에서 공격 시작할 때 호출해주는 함수
    /// </summary>
    public void AttackStart()
    {
        IsAttack = true;

        _attackCol.enabled = true;
    }

    /// <summary>
    /// 애니메이터에서 공격이 끝날 때 호출해주는 함수
    /// </summary>
    public void AttackEnd()
    {
        IsAttack = false;

        _attackCol.enabled = false;
    }


    private void OnTriggerEnter(Collider other) {
        if((other.gameObject.layer & _hitLayer) > 0)
        {
            IDamageAble iDamageAble = other.GetComponent<IDamageAble>();

            iDamageAble?.Damage(Atk);
        }
    }
}
