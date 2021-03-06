namespace GSGD2.UI
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;

	/// <summary>
	/// Manager class that handle global functionnality around UI. It is a proxy to UI subsystem and can enable or disable them.
	/// </summary>
	public class UIManager : MonoBehaviour
	{
		[SerializeField]
		private Canvas _mainCanvas = null;

		[SerializeField]
		private PlayerHUDMenu _playerHUD = null;

		[SerializeField]
		private PauseMenu _pauseMenu = null;

		[SerializeField]
		private PeltInventory _peltInventory = null;

		[SerializeField]
		private Map _map = null;

		public Canvas MainCanvas => _mainCanvas;
		public PlayerHUDMenu PlayerHUD => _playerHUD;
		public PauseMenu PauseMenu => _pauseMenu;
		public PeltInventory PeltInventory => _peltInventory;
		public Map Map => _map;

		public void ShowPlayerHUD(bool isActive)
		{
			_playerHUD.SetActive(isActive);
		}

		public void ShowPauseMenu(bool isActive)
        {
			_pauseMenu.SetActive(isActive);
        }

		public void ShowPeltInventoryMenu(bool isActive)
        {
			_peltInventory.SetActive(isActive);
        }

		public void ShowMap(bool isActive)
        {
			_map.SetActive(isActive);
        }
	}
}