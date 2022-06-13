using UnityEngine;

namespace Mushrooms.Extensions.Ecs
{
    public class EntityProvider : MonoBehaviour
    {
        private int _entity = 1;

        public int Entity
        {
            get
            {
                if (_entity == -1) Debug.LogWarning("Enity is not assigned!");
                return _entity;
            }

            set
            {
                _entity = value;
            }
        }
    }
}
