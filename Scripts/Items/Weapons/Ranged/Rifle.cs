using UnityEngine;

namespace WeaponrySystem.Items.Weapons
{
    /// <summary>
    /// A class that represents a heavy, two-handed ranged weapon.
    /// </summary>
    public class Rifle : RangedWeapon
    {
        [Tooltip("How much should the range of the rifle be increased when its enhanced with a scope.")]
        [Range(0.1f, 2.0f)]
        [SerializeField]
        private float _scopeRangeModifier;

        private bool _hasScope;

        public bool HasScope
        {
            get { return _hasScope; }
            set
            {
                _hasScope = value;

                if (value)
                    Range *= _scopeRangeModifier;
            }
        }

        /// <summary>
        /// Uses the rifle for its standard attack.
        /// </summary>
        public override void Use()
        {
            base.Use();

            WeaponUseDebug(typeof(Rifle).ToString());
        }
    }
}
