using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponrySystem
{
    public abstract class RangedWeapon : MonoBehaviour, IWeapon
    {
        public string Name { get; protected set; }
        public int Damage { get; protected set; }
        public float Range { get; protected set; }
        public int AmmunitionCount { get; protected set; }

        public virtual void Attack()
        {

        }
    }
}
