using System.Collections.Generic;
using UnityEngine;

namespace _PlatformJump._Screpts.SO
{
    [CreateAssetMenu(fileName = "Achigments", menuName = "AchigmentsColetion")]
    public class AchigmentsColection : ScriptableObject
    {
        [SerializeField] private List<Achigment> _achigments;

        public List<Achigment> GetAchigments()
        {
            return _achigments;
        }
    }
}