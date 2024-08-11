using UnityEngine;

namespace WeaponrySystem.Items.Weapons
{
    /// <summary>
    /// A base class that represents traits and functionalities common for all ranged weapons.
    /// </summary>
    public abstract class RangedWeapon : Weapon
    {
        [Tooltip("Max amount of amunition this weapon can have.")]
        [SerializeField]
        protected int _maxAmmunitionCount;

        protected int _currentAmmunitionCount;

        public int AmmunitionCount
        {
            get { return _currentAmmunitionCount; }
            set
            {
                _currentAmmunitionCount = value < _maxAmmunitionCount ? value : _maxAmmunitionCount;
            }
        }

        /// <summary>
        /// Uses the weapon, decreasing its ammunition count.
        /// </summary>
        public override void Use()
        {
            if (_currentAmmunitionCount <= 0)
            {
                Debug.Log($"No more ammo to use {Name}!");
                return;
            }

            _currentAmmunitionCount--;
            _currentAmmunitionCount = _currentAmmunitionCount >= 0 ? _currentAmmunitionCount : 0;
        }

        /// <summary>
        /// Reloads the weapon, restoring its ammunition count.
        /// </summary>
        /// <param name="ammunitionToRestore"></param>
        public virtual void Reload(int ammunitionToRestore)
        {
            AmmunitionCount = ammunitionToRestore;
        }

        private void Awake()
        {
            _currentAmmunitionCount = _maxAmmunitionCount;
        }
    }
}
