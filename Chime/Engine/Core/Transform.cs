using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Chime.Engine.Core
{
    public class Transform : Component
    {
        public Transform(GameObject gameObject) : base(gameObject)
        {

        }

        public Vector3 Position; 
        public Quaternion Rotation;
        public Vector3 Scale;

        List<GameObject> _children;

        public int ChildCount => _children.Count;
        //TODO: public eulerAngles =>;

    }
}
