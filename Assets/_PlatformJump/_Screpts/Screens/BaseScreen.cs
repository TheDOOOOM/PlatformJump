using Services;
using UnityEngine;

namespace Screens
{
    public abstract class BaseScreen : MonoBehaviour
    {
        protected DialogLauncher Dialog;
        //  protected AudioManager _audioManager;

        public virtual void Init()
        {
            Dialog = ServiceLocator.Instance.GetService<DialogLauncher>();
            //     _audioManager = ServiceLocator.Instance.GetService<AudioManager>();
        }

        public virtual void Сlose() => Destroy(gameObject);
    }
}