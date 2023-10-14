using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public interface IUpdater 
    {
        void Update(float deltaTime);
    }
}