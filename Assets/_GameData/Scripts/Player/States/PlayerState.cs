using TSGameDev.Core.Controls;
using UnityEngine;

namespace TSGameDev.Core.State
{
    public enum PlayerStateEnum
    {
        Idle,
        Running,
        Dashing,
        Roading,
        Dead,
    }

    public abstract class PlayerState
    {
        protected Player player;
        protected PlayerData playerData;
        protected Animator playerAnimator;
        protected CharacterController playerController;

        public PlayerState(PlayerData playerData, Player player)
        {
            this.player = player;
            this.playerData = playerData;
            playerAnimator = player.GetComponent<Animator>();
            playerController = player.GetComponent<CharacterController>();
        }

        public virtual void Update() { }

        public virtual void Movement() { }

        public virtual void Dash() { }

        public virtual void Aim() { }

        public virtual void Attack() { }

        public virtual void StateTransition(PlayerStateEnum toState, PlayerStateEnum viaState)
        {
            playerData.previousState = viaState;

            switch(toState)
            {
                case PlayerStateEnum.Idle:
                    playerData.playerState = new PlayerStateIdle(playerData, player);
                    break;
                case PlayerStateEnum.Running:
                    playerData.playerState = new PlayerStateRunning(playerData, player);
                    break;
            }
        }
    }
}
