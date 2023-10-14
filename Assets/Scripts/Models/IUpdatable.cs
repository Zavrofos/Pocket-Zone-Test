using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public interface IUpdatable 
    {
        void Update(float deltaTime);
    }
}