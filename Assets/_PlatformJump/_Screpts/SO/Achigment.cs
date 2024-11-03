using System;
using UnityEngine;

namespace _PlatformJump._Screpts.SO
{
    [CreateAssetMenu(fileName = "achigment", menuName = "achigmentCreate")]
    public class Achigment : ScriptableObject
    {
        [SerializeField] private string _header;
        [SerializeField] private string _discription;
        [SerializeField] private bool _status;

        public string Header => _header;
        public string Discription => _discription;
        public bool Status => _status;

        public void Complited()
        {
            _status = true;
        }

        public void Reset()
        {
            _status = false;
        }
    }
}