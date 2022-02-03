using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerCameraView : View
    {
        public void UpdatePosition(Vector3 updatedPosition, int speed)
        {
            transform.position = Vector3.Lerp(transform.position, updatedPosition, speed * Time.fixedDeltaTime);
        }
    }
}