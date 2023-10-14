using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Data
{
    public interface IData 
    {
        void Save();
        void Load();
    }
}