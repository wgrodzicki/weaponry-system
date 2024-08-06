using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponrySystem
{
    public abstract class MeleeWeapon : Weapon
    {
        public enum AttackType
        {
            Chop,
            Slash,
            Thrust
        }
    }
}
