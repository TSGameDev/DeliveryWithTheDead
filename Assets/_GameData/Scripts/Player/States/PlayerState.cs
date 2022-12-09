using TSGameDev.Core.Controls;
using UnityEngine;
using UnityEngine.InputSystem;

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
        protected CharacterController playerController;

        public PlayerState(PlayerData playerData, Player player)
        {
            this.player = player;
            this.playerData = playerData;
            playerController = player.GetComponent<CharacterController>();
        }

        public virtual void Update() { }

        public virtual void Movement() { }

        public virtual void Dash() { }

        public virtual void Aim() 
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector3 hitPos = hit.point;
                hitPos.y = player.transform.position.y;
                player.transform.LookAt(hitPos);
            }
        }

        public virtual void Attack() 
        {
            if(playerData.activeWeapon != null)
                playerData.activeWeapon.Attack();
        }

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
