using UnityEngine;

namespace LegacyMushrooms.Extensions.EntityToGameObject
{
    public class EcsUnityProvider : MonoBehaviour
    {
        public ref int Entity
        {
            get
            {
                if (_entity == -1) Debug.LogWarning("Entity is not assigned!");
                return ref _entity;
            }
        }

        private int _entity = -1;

        public void SetEntity(in int entity) => _entity = entity;
    }
}
