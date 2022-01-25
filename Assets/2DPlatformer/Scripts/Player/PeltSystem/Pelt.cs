namespace GSGD2.Player
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;


    [CreateAssetMenu(menuName = "GameSup/Pelts", fileName = "Pelt")]
    public class Pelt : ScriptableObject
    {
        [SerializeField]
        private bool _enableWallGrab = false;

        [SerializeField]
        private bool _enableGlide = false;

        protected virtual bool ApplyPelt()
        {
            var player = LevelReferences.Instance.Player;

            if (_enableWallGrab == true)
            {
                player.EnableWallGrab(true);
            }
            else
            {
                player.EnableWallGrab(false);
            }

            if (_enableGlide == true)
            {
                player.EnableGlide(true);
            }
            else
            {
                player.EnableGlide(false);
            }
            return true;
        }
    }
}