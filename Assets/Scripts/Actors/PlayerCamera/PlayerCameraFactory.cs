using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class PlayerCameraFactory : PlaceholderFactory<PlayerCamera, PlayerCameraConfig, Transform, Character, PlayerCamera>
    {

    }
}