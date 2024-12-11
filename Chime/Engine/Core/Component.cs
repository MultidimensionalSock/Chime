﻿using OpenTK.Graphics.ES20;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Chime.Engine.Core
{
    public class Component
    {
        public GameObject GameObject;
        public Component(GameObject gameObject) { GameObject = gameObject; Initialize(); }
        public bool Active
        {
            get => _active;
            set
            {
                if (_active && !value)
                {
                    OnEnable();
                }
                else if (!_active && value)
                {
                    OnDisable();
                }
                _active = value;
            }
        }
        private bool _active;

        public virtual void OnEnable() { }
        public virtual void OnDisable() { }
        public virtual void Initialize() { }

        public virtual void Update() { }
        public virtual void FixedUpdate() { }
        public virtual void LateUpdate() { }
        public virtual void OnDraw() { }
        public virtual void OnDestroy() { }
        
        public virtual void OnCollisionEnter() { }
        public virtual void OnCollisionStay() { }
        public virtual void OnCollisionExit() { }

        public virtual void OnTriggerEnter() { }
        public virtual void OnTriggerStay() { }
        public virtual void OnTriggerExit() { }
    }
}
