using TSGameDev.Core.Controls;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TSGameDev.Core.State
{
    public class PlayerStateIdle : PlayerState
    {
        public PlayerStateIdle(PlayerData playerData, Player player) : base(playerData, player) { }

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
