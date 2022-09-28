using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageAble
{
    bool IsDead { get; }
    void Damage(int damage);
}
