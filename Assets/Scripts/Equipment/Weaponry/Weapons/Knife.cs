using UnityEngine;

namespace WeaponrySystem.Equipment.Weaponry
{
    public class Knife : MeleeWeapon
    {
        [SerializeField]
        private int _backStabAttackModifier;

        public override void Attack()
        {
            base.Attack();

            AttackDebug(typeof(Knife).ToString());
        }

        public void BackStabAttack()
        {
            Damage *= _backStabAttackModifier;
            Attack();
        }
    }
}
