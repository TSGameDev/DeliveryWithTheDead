using System.Runtime.CompilerServices;
using TSGameDev.Core.State;
using UnityEngine;

namespace TSGameDev.Core.Controls
{
    public class Player : MonoBehaviour
    {
        #region Serialize Varibales

        [SerializeField] PlayerData playerData;
        [SerializeField] GameObject weaponHolder;

        #endregion

        #region Private Variables

        private PlayerControls playerControls;
        private GameObject activeWeaponCache;

        #endregion

        #region Pirvate Functions

        private void Awake()
        {
            playerControls = new();
            playerData.playerState = new PlayerStateIdle(playerData, this);
            playerData.activeWeapon = null;
        }

        private void OnEnable()
        {
            playerControls.Enable();
            playerControls.Game.Enable();

            playerControls.Game.WASDMovement.performed += ctx => playerData.movement = ctx.ReadValue<Vector2>();
            playerControls.Game.WASDMovement.canceled += ctx => playerData.movement = Vector2.zero;

            playerControls.Game.Attack.performed += ctx => playerData.playerState.Attack();

        }

        private void OnDisable()
        {
            playerControls.Disable();
            playerControls.Game.Disable();
        }

        private void Update()
        {
            playerData.playerState.Update();
        }

        #endregion

        public PlayerData GetPlayerData() => playerData;

        public void SetWeapon(GameObject weapon)
        {
            if(activeWeaponCache != null)
            {
                Destroy(activeWeaponCache);
                activeWeaponCache = null;
                playerData.activeWeapon = null;
            }

            activeWeaponCache = Instantiate(weapon, weaponHolder.transform);
            playerData.activeWeapon = weapon.GetComponent<IWeapon>();
            Debug.Log(activeWeaponCache);
        }
    }
}
