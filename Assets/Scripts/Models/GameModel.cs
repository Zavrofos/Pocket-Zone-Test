using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public class GameModel 
    {
        public readonly InputModel Input;
        public GameModel()
        {
            Input = new InputModel();
        }
    }
}