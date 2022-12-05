using TSGameDev.Core.State;
using UnityEngine;

namespace TSGameDev.Core.Controls
{
    public class Player : MonoBehaviour
    {
        #region Serialize Varibales

        [SerializeField] PlayerData playerData;

        #endregion

        #region Private Variables

        private PlayerControls playerControls;

        #endregion

        #region Pirvate Functions

        private void Awake()
        {
            playerControls = new();
            playerData.playerState = new PlayerStateIdle(playerData, this);
        }

        private void OnEnable()
        {
            playerControls.Enable();
            playerControls.Game.Enable();

            playerControls.Game.WASDMovement.performed += ctx => playerData.movement = ctx.ReadValue<Vector2>();
            playerControls.Game.WASDMovement.canceled += ctx => playerData.movement = Vector2.zero;

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
    }
}
