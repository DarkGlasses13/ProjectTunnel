namespace Assets.Scripts
{
    public interface IStartUp
    {
        void Construct(PlayerView player, WeaponView weapon);
        void Init();
    }
}
