using UnityEngine;

namespace WeaponrySystem.Items.Weapons
{
    /// <summary>
    /// A base class that represents traits and functionalities common for all melee weapons.
    /// </summary>
    public abstract class MeleeWeapon : Weapon
    {
        [Tooltip("What kind of melee attack can be performed with this weapon.")]
        [field: SerializeField]
        public AttackType WeaponAttack { get; protected set; }

        public enum AttackType
        {
            Chop,
            Slash,
            Thrust
        }
    }
}
