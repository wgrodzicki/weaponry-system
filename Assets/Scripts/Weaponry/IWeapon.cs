namespace WeaponrySystem
{
    public interface IWeapon
    {
        string Name { get; }
        int Damage { get; }
        float Range { get; }

        void Attack();
    }
}
