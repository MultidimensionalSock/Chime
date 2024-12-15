using OpenTK.Graphics.ES20;
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

        public bool Active
        {
            get => _active;
            set
            {
                if (_active != value)
                {
                    foreach (var component in components)
                    {
                        component.Active = value;
                    }
                }
                _active = value;
            }
        }
        private bool _active;

        public GameObject()
        {
            transform = new(this);
        }

        public T? GetComponent<T>() where T : Component
        {
            foreach (Component comp in components)
            {
                if (comp is T)
                {
                    return (T)comp;
                }
            }
            return null;
        }

        //TODO: This almost definitely doersnt work 
        public T? AddComponent<T>() where T : Component
        {
            T component = (T)Activator.CreateInstance(typeof(T));
            components.Add(component);
            component.Initialize();
            return component;
        }

        public void RemoveComponent(Component component)
        {
            components.Remove(component);
        }

        public static bool operator ==(GameObject lhs, GameObject rhs) { return lhs.Id == rhs.Id; }
        public static bool operator !=(GameObject lhs, GameObject rhs) { return lhs.Id != rhs.Id; }
    }
}
