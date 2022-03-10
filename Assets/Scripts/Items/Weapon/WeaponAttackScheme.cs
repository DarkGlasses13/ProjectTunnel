namespace Assets.Scripts
{
    public abstract class WeaponAttackScheme<W> where W: Weapon
    {
        protected W _weaponData;
        protected Attacker _attacker;
        public WeaponAttackScheme(W weaponData) => _weaponData = weaponData;
    }
}