using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Data
{
    public interface IDataWriter 
    {
        void WriteInt(int value);
        void WriteString(string str);
    }
}