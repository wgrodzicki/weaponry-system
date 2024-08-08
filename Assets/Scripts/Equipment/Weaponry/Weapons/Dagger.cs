using UnityEngine;

namespace Equipment.Weaponry
{
    public class Dagger : MeleeWeapon
    {
        [SerializeField]
        private int _backStabAttackModifier;

        public override void Attack()
        {
            base.Attack();

            AttackDebug(typeof(Dagger).ToString());
        }

        public void BackStabAttack()
        {
            Damage *= _backStabAttackModifier;
            Attack();
        }
    }
}
