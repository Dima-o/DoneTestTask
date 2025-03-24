using System;
using UnityEngine;

namespace Assets.Scripts.Conservation
{
    [Serializable]
    public class GameData
    {
        public Vector3 position;
        public Quaternion rotation;

        public GameData() 
        {
            position = Vector3.up;
            rotation = Quaternion.identity;
        }
    }
}
