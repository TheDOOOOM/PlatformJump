using UnityEngine;

namespace _PlatformJump._Screpts
{
    public class MenuScreen : MonoBehaviour
    {
        [SerializeField] private MoveComponent _moveCloudOne;
        [SerializeField] private MoveComponent _moveCloudTwo;

        private void Start()
        {
            Init();
        }

        public void Init()
        {
            _moveCloudOne.MovePosition();
            _moveCloudTwo.MovePosition();
        }
    }
}