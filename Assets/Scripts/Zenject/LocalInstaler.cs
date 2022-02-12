using Zenject;
using UnityEngine;

namespace Assets.Scripts
{
    public class LocalInstaler : MonoInstaller
    {
        [SerializeField] PlayerView _playerPref;

        private WeaponView _weaponView;
        public override void InstallBindings()
        {
            BindPlayer();
        }
        public void BindPlayer()
        {
            PlayerView player = Container
                .InstantiatePrefabForComponent<PlayerView>(_playerPref);

            player.gameObject.transform.position = Vector3.zero;
            _weaponView = player.GetComponentInChildren<WeaponView>();

            Container.Bind<WeaponView>().FromInstance(_weaponView);
            Container.Bind<PlayerView>().FromInstance(player).AsSingle();
        }
    }
}
