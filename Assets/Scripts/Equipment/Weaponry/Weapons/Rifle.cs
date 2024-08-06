using UnityEngine;

namespace WeaponrySystem
{
    public class Rifle : RangedWeapon
    {
        [SerializeField]
        private float _scopeRangeModifier;
        private bool _hasScope;

        public bool HasScope
        {
            get { return _hasScope; }
            set
            {
                _hasScope = value;
                Range *= _scopeRangeModifier;
            }
        }

        public override void Attack()
        {
            base.Attack();

            AttackDebug(typeof(Rifle).ToString());
        }
    }
}
