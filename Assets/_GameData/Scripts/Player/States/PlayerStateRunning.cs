using UnityEngine;
using TSGameDev.Core.Controls;

namespace TSGameDev.Core.State
{
    public class PlayerStateRunning : PlayerState
    {
        public PlayerStateRunning(PlayerData playerData, Player player) : base(playerData, player) { }

        public override void Update()
        {
            Movement();
            Aim();
        }

        public override void Movement()
        {
            float rawX = playerData.movement.x;
            float rawY = playerData.movement.y;

            Vector3 movement = (player.transform.right * rawX) + (player.transform.forward * rawY);
            movement = movement.normalized * playerData.GetSpeed * Time.deltaTime;

            if (movement.magnitude >= Mathf.Epsilon)
                playerController.Move(movement);
            else
                StateTransition(PlayerStateEnum.Idle, PlayerStateEnum.Running);
        }
    }
}
