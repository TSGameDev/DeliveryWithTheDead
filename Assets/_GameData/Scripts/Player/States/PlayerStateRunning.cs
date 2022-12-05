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
            Aim();
        }
    }
}
