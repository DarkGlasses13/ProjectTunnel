using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class HubStartUp : MonoBehaviour
    {
        [Header("CONFIGURATION")]
        [SerializeField] CharacterConfig _characterConfig;

        [Header("PARENTS")]
        [SerializeField] Transform _playerHand;
        [SerializeField] Transform _actopParent;
        [SerializeField] Transform _iconParent;

        [Header("ACTOR PREFABS")]
        [SerializeField] Icon _iconPrefab;
        [SerializeField] IconDealer _iconDealerPref;

        [Inject]
        private void Construct(ShopFactory shop, ItemDatabase database)
        {
            shop.Create(_iconDealerPref, _iconPrefab, database, _playerHand, _iconParent, _actopParent);
        }
    }
}
