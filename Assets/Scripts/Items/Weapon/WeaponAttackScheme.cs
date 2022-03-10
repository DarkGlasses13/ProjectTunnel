namespace Assets.Scripts
{
    public abstract class WeaponAttackScheme<W> where W: Weapon
    {
        protected W _weaponData;
        protected Aimer _aimer;

        public WeaponAttackScheme(W weaponData) => _weaponData = weaponData;
    }
}