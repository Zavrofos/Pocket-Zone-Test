using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class StarterCoroutines : MonoBehaviour
    {
        private List<Coroutine> _coroutines;

        public void StartCoroutineBehavior(IEnumerator coroutine)
        {
            StartCoroutine(coroutine);
        }

        public void StopCoroutineBehavior(IEnumerator coroutine)
        {
            StopCoroutine(coroutine);
        }

        public void StopAllCoroutinesBehaviour()
        {
            foreach(var coroutine in _coroutines)
            {
                StopCoroutine(coroutine);
            }
        }
    }
}