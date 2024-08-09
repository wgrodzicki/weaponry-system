using UnityEngine;

namespace WeaponrySystem.Equipment.Weaponry
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
