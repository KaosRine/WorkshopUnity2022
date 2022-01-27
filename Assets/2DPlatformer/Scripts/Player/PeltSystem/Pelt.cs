namespace GSGD2.Player
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Gameplay;
    using GSGD2.UI;

    [CreateAssetMenu(menuName = "GameSup/Pelts", fileName = "Pelts")]
    public class Pelt : PickupCommand
    {
        public enum PeltType
        {
            None,
            Wolf,
            Squirrel
        }

        [SerializeField]
        private PeltType _pelt = 0;

        private CubeController _cubeController = null;
        private PeltInventory _peltInventory = null;
        private PeltInventoryMenu _peltInventoryMenu = null;

        public PeltType GetPeltType => _pelt;

        protected override bool ApplyPickup(ICommandSender from)
        {
            //var player = LevelReferences.Instance.Player;
            LevelReferences.Instance.PlayerReferences.TryGetPeltInventory(out _peltInventory);
            /*_peltInventoryMenu = LevelReferences.Instance.UIManager.PeltInventoryMenu;

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
                        _peltInventoryMenu.WolfIcon.enabled = true;
                    }
                    break;
                case PeltType.Squirrel:
                    {
                        player.EnableWallGrab(false);
                        player.EnableGlide(true);

                        _peltInventory.AddPelt(this);
                        _peltInventoryMenu.SquirrelIcon.enabled = true;
                    }
                    break;
                default:
                    break;
            }*/
            _peltInventory.AddPelt(this);
            return true;
        }



        public void Apply()
        {
            var player = LevelReferences.Instance.Player;
            var glider = player.GetComponentInParent<ExampleGlider>();
            LevelReferences.Instance.PlayerReferences.TryGetCubeController(out _cubeController);

            switch (_pelt)
            {
                case PeltType.None:
                    {
                        player.EnableWallGrab(false);
                        player.EnableGlide(false);
                    }
                    break;
                case PeltType.Wolf:
                    {
                        player.EnableWallGrab(true);
                        player.EnableGlide(false);

                        _cubeController.ChangeState(CubeController.State.Falling);
                        glider.SetIsGliding(false);
                        _cubeController.EnableJump(true);
                        _cubeController.ForceCheckGround();
                    }
                    break;
                case PeltType.Squirrel:
                    {
                        player.EnableWallGrab(false);
                        player.EnableGlide(true);

                        _cubeController.ChangeState(CubeController.State.Falling);
                        _cubeController.ForceCheckGround();
                    }
                    break;
                default:
                    break;
            }
        }

        public void ResetMovementAbilities()
        {
            var player = LevelReferences.Instance.Player;

            player.EnableWallGrab(false);
            player.EnableGlide(false);
        }
    }
}