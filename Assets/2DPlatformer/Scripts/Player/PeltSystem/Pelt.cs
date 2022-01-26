namespace GSGD2.Player
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Gameplay;

    [CreateAssetMenu(menuName = "GameSup/Pelts", fileName = "Pelts")]
    public class Pelt : PickupCommand
    {
        private enum PeltType
        {
            None,
            Wolf,
            Squirrel
        }

        [SerializeField]
        private PeltType _pelt = 0;

        private PeltInventory _peltInventory = null;

        protected override bool ApplyPickup(ICommandSender from)
        {
            var player = LevelReferences.Instance.Player;
            LevelReferences.Instance.PlayerReferences.TryGetPeltInventory(out _peltInventory);

            switch (_pelt)
            {
                case PeltType.None:
                    {
                        player.EnableWallGrab(false);
                        player.EnableGlide(false);

                        //TODO: Change current pelt enum
                    }
                    break;
                case PeltType.Wolf:
                    {
                        player.EnableWallGrab(true);
                        player.EnableGlide(false);

                        _peltInventory.AddPelt(this);
                    }
                    break;
                case PeltType.Squirrel:
                    {
                        player.EnableWallGrab(false);
                        player.EnableGlide(true);

                        _peltInventory.AddPelt(this);
                    }
                    break;
                default:
                    break;
            }

            return true;
        }
    }
}