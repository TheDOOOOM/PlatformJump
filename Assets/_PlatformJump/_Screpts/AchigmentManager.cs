using System.Collections.Generic;
using _PlatformJump._Screpts.SO;
using UnityEngine;

public class AchigmentManager : MonoBehaviour, IService
{
    [SerializeField] private List<Achigment> _achigments;

    public void FirsLevelComplite()
    {
        _achigments[0].Complited();
    }

    public void GravityMasterComplited()
    {
        _achigments[1].Complited();
    }

    public void TopGunComplited()
    {
        _achigments[8].Complited();
    }

    public void CollectionAllStars()
    {
        _achigments[7].Complited();
    }

    public void PerfectPathComplited()
    {
        _achigments[3].Complited();
    }

    public void PlatformAssasin()
    {
        _achigments[4].Complited();
    }

    public void ZeroGravityHero()
    {
        _achigments[9].Complited();
    }

    public void OnTheEdge()
    {
        _achigments[2].Complited();
    }
}