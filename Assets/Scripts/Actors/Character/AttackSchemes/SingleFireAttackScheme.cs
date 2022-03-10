namespace Assets.Scripts
{
    public class SingleFireAttackScheme : FirearmAttackSceme<Single>, IWeaponAttackScheme
    {
        public SingleFireAttackScheme(Single weaponData) : base(weaponData) { }

        void IWeaponAttackScheme.Apply(Attacker attacker)
        {
            _attacker = attacker;
            _attacker.Controls.Character.Aim.canceled += callbackContext => Attack();
            _attacker.BulletDealer.InitPool(_weaponData.Bullet, attacker.transform);
        }

        public void Attack()
        {
            _attacker.CharacterControl.RotateFast();
            _attacker.BulletDealer.GetBullet();
        }

        void IWeaponAttackScheme.Cancel() => _attacker.Controls.Character.Aim.canceled -= callbackContext => Attack();
    }
}