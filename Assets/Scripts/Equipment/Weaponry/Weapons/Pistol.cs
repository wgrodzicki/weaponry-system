
namespace Equipment.Weaponry
{
    public class Pistol : RangedWeapon
    {
        public override void Attack()
        {
            base.Attack();

            AttackDebug(typeof(Pistol).ToString());
        }
    }
}
