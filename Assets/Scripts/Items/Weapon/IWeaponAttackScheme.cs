namespace Assets.Scripts
{
    public interface IWeaponAttackScheme
    {
        public void Apply(Attacker attacker);
        public void Attack();
        public void Cancel();
    }
}