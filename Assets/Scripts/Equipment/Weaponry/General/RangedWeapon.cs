using UnityEngine;

namespace WeaponrySystem
{
    public abstract class RangedWeapon : Weapon
    {
        [SerializeField]
        protected int _maxAmunitionCount;
        protected int _currentAmunitionCount;

        public int AmmunitionCount
        {
            get
            { return _currentAmunitionCount; }
            set
            {
                _currentAmunitionCount = value < _maxAmunitionCount ? value : _maxAmunitionCount;
            }
        }

        public override void Attack()
        {
            base.Attack();

            if (_currentAmunitionCount > 0)
            {
                _currentAmunitionCount--;
                _currentAmunitionCount = _currentAmunitionCount >= 0 ? _currentAmunitionCount : 0;
            }
        }

        public virtual void Reload(int ammunitionToRestore)
        {
            AmmunitionCount = ammunitionToRestore;
        }

        private void Awake()
        {
            _maxAmunitionCount = AmmunitionCount;
            _currentAmunitionCount = AmmunitionCount;
        }
    }
}
