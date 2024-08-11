
namespace WeaponrySystem.Items.Weapons
{
    /// <summary>
    /// A class that represents a long melee weapon used for slashing.
    /// </summary>
    public class Sword : MeleeWeapon
    {
        /// <summary>
        /// Uses the sword for its standard attack.
        /// </summary>
        public override void Use()
        {
            base.Use();

            WeaponUseDebug(typeof(Sword).ToString());
        }
    }
}
