using TSGameDev.Core.Controls;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TSGameDev.Core.State
{
    public class PlayerStateIdle : PlayerState
    {
        public PlayerStateIdle(PlayerData playerData, Player player) : base(playerData, player) 
        {
            playerAnimator.SetBool(playerData.idleHash, true);
            playerAnimator.SetFloat(playerData.movementXHash, 0);
            playerAnimator.SetFloat(playerData.movementYHash, 0);
        }

        public override void Update()
        {
            Movement();
            Aim();
        }

        public override void Movement()
        {
            if(playerData.movement.magnitude > 0)
                StateTransition(PlayerStateEnum.Running, PlayerStateEnum.Idle);
        }
    }
}
