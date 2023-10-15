using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Presenters
{
    public interface IPresenter
    {
        void Subscribe();
        void Unsubscribe();
    }
}
