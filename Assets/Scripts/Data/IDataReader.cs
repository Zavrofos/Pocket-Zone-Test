using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Data
{
    public interface IDataReader 
    {
        int Readint();
        string ReadString();
    }
}