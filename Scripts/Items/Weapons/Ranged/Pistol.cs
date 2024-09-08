
namespace WeaponrySystem.Items.Weapons
{
    /// <summary>
    /// A class that represents a light, one-handed ranged weapon.
    /// </summary>
    public class Pistol : RangedWeapon
    {
        /// <summary>
        /// Uses the pistol for its standard attack.
        /// </summary>
        public override void Use()
        {
            base.Use();

            WeaponUseDebug(typeof(Pistol).ToString());
        }
    }
}
