namespace WeaponrySystem
{
    public interface IEquippable
    {
        bool IsEquipped { get; }

        void Equip(bool equip);
    }
}
