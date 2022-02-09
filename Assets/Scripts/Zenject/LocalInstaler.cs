using Zenject;
using UnityEngine;

namespace Assets.Scripts
{
    public class LocalInstaler : MonoInstaller
    {
        [Header("Player")]
        [SerializeField] PlayerView _playerPref;
        [SerializeField] Transform _startPos;
        [SerializeField] Transform _playerParent;

        private WeaponView _weaponView;
        public override void InstallBindings()
        {
            BindPlayer();
        }
        public void BindPlayer()
        {
            PlayerView player = Container
                .InstantiatePrefabForComponent<PlayerView>(_playerPref, _startPos.position, Quaternion.identity, _playerParent);

            _weaponView = player.GetComponentInChildren<WeaponView>();

            Container.Bind<WeaponView>().FromInstance(_weaponView).AsSingle();
            Container.Bind<PlayerView>().FromInstance(player).AsSingle();
        }
    }
}
