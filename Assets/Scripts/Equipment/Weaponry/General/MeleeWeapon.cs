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

        [field: SerializeField]
        public AttackType WeaponAttack { get; protected set; }
    }
}
