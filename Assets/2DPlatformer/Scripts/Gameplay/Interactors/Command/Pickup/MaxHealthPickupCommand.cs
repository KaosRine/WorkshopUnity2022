namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(menuName = "GameSup/MaxHealthPickupCommand", fileName = "MaxHealthPickupCommand")]
    public class MaxHealthPickupCommand : PickupCommand
    {
        [SerializeField]
        private int _healthToAdd = 1;

        protected override bool ApplyPickup(ICommandSender from)
        {
            if (LevelReferences.Instance.PlayerReferences.TryGetPlayerDamageable(out PlayerDamageable playerDamageable) == true)
            {
                playerDamageable.AddMaxHealth(_healthToAdd);
                return true;
            }
            return false;
        }
    }
}