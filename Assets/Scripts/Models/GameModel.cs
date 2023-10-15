using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public class GameModel 
    {
        public readonly InputModel Input;
        public readonly Player Player;
        public GameModel()
        {
            Input = new InputModel();
            Player = new Player();
        }
    }
}