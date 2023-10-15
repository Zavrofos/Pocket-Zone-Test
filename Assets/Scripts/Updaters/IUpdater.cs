using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Updaters
{
    public interface IUpdater 
    {
        void Update(float deltaTime);
    }
}