using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChimeEngine.Core
{
    public class GameObject
    {
        Transform transform { get; set; }
        private List<Component> components = new List<Component>();
        public Guid Id { get; private set; }

        public GameObject()
        {
            transform = new(this);
        }


        //TODO: Get component 
        //TODO: Add component
        //TODO: remove component 

        public static bool operator ==(GameObject lhs, GameObject rhs) { return lhs.Id == rhs.Id; }
        public static bool operator !=(GameObject lhs, GameObject rhs) { return lhs.Id != rhs.Id; }
    }
}
