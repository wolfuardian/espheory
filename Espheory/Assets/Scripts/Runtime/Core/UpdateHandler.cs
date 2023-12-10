using UnityEngine;
using System.Collections.Generic;
using Eos.Runtime.Interface;

namespace Eos.Runtime.Core
{
    public class UpdateHandler : MonoBehaviour
    {
        public static UpdateHandler instance { get; private set; }

        private readonly List<ITick> _handlers = new List<ITick>();

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
            DontDestroyOnLoad(gameObject);
        }


        public void Register(ITick tick)
        {
            _handlers.Add(tick);
        }

        public void Unregister(ITick tick)
        {
            _handlers.Remove(tick);
        }

        private void Update()
        {
            foreach (var handler in _handlers)
            {
                handler.Tick();
            }
        }
    }
}