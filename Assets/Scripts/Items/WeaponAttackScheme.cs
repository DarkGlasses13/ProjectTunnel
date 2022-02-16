namespace Assets.Scripts
{
    public abstract class WeaponAttackScheme<W> where W: Weapon
    {
        protected W _weaponData;

        public WeaponAttackScheme(W weaponData) => _weaponData = weaponData;
    }
}