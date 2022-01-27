using UnityEngine;

namespace Assets.Scripts
{
    public class CameraModel : Model
    {
        public Transform Transform { get; private set; }
        public Vector3 Offset { get; private set; }
        public int MoveSpeed { get; private set; }
        public Transform Target { get; private set; }

        public void SetTransform(Transform transform)
        {
            Transform = transform;
        }

        public void SetOffset(Vector3 offset)
        {
            Offset = offset;
        }

        public void SetMoveSpeed(int moveSpeed)
        {
            MoveSpeed = moveSpeed;
        }

        public void SetTarget(Transform target)
        {
            Target = target;
        }
    }
}