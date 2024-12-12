using OpenTK.Mathematics;

namespace Chime.Engine.Core
{
    public class Transform : Component
    {
        public Transform(GameObject gameObject) : base(gameObject)
        {
            Position = Vector3.Zero;
            Rotation = Quaternion.Identity;
            Scale = Vector3.One;
        }

        public Transform(Vector3 position, Quaternion rotation, Vector3 scale, GameObject gameObject) : base(gameObject)
        {
            Position = position;
            Rotation = rotation;
            Scale = scale;
        }

        public Vector3 Position;
        public Quaternion Rotation;
        public Vector3 Scale;

        List<Transform> _children;

        public int ChildCount => _children.Count;
        //TODO: public eulerAngles =>;

    }
}
