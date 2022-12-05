using UnityEngine;
using TSGameDev.Core.Controls;

namespace TSGameDev.Core.State
{
    public class PlayerStateRunning : PlayerState
    {
        public PlayerStateRunning(PlayerData playerData, Player player) : base(playerData, player) 
        {
            playerAnimator.SetBool(playerData.idleHash, false);
        }

        public override void Update()
        {
            Movement();
        }

        public override void Movement()
        {
            float rawX = playerData.movement.x;
            float rawY = playerData.movement.y;

            playerAnimator.SetFloat(playerData.movementXHash, rawX, 0.1f, Time.deltaTime);
            playerAnimator.SetFloat(playerData.movementYHash, rawY, 0.1f, Time.deltaTime);

            if(playerData.movement.magnitude <= Mathf.Epsilon)
                StateTransition(PlayerStateEnum.Idle, PlayerStateEnum.Running);
        }
    }
}
