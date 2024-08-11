using UnityEngine;

namespace WeaponrySystem.Items.Weapons
{
    /// <summary>
    /// A class that represents a short melee weapon used for stabbing.
    /// </summary>
    public class Knife : MeleeWeapon
    {
        [Tooltip("How much should the damage of the knife be increased when it's used for a back stab attack.")]
        [SerializeField]
        private int _backStabAttackModifier;

        /// <summary>
        /// Uses the knife for its standard attack.
        /// </summary>
        public override void Use()
        {
            base.Use();

            WeaponUseDebug(typeof(Knife).ToString());
        }

        /// <summary>
        /// Uses the knife for a powerful back stab attack.
        /// </summary>
        public void BackStabAttack()
        {
            Damage *= _backStabAttackModifier;
            Use();
        }
    }
}
