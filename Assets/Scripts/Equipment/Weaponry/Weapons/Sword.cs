
namespace WeaponrySystem.Equipment.Weaponry
{
    public class Sword : MeleeWeapon
    {
        public override void Attack()
        {
            base.Attack();

            AttackDebug(typeof(Sword).ToString());
        }
    }
}
