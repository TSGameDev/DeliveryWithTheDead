using UnityEngine;
using UnityEngine.Events;
using TSGameDev.Core.State;
using Sirenix.OdinInspector;

namespace TSGameDev.Core.Controls
{
    [CreateAssetMenu(fileName = "New Player Data", menuName = "New Player Data")]
    public class PlayerData : ScriptableObject
    {
        #region Serialized Variables

        [SerializeField] int health;
        [SerializeField] float speed;
        [SerializeField] float dodgeCooldown;

        #endregion

        #region Private Variables

        private float currentDodgeTimer;

        #endregion

        #region Public Varibales

        public PlayerState playerState;
        public PlayerStateEnum previousState;

        public Vector2 movement;

        public IWeapon activeWeapon;

        #endregion

        #region Animation Hashes

        public readonly int idleHash = Animator.StringToHash("isIdle");
        public readonly int movementXHash = Animator.StringToHash("MovementX");
        public readonly int movementYHash = Animator.StringToHash("MovementY");

        #endregion

        #region Events

        public UnityAction OnHealthUpdate;
        public UnityAction OnDodgeUpdate;

        #endregion

        #region Getters

        public int GetHealth => health;
        public float GetSpeed => speed;
        public float GetDodgeCooldown => dodgeCooldown;

        #endregion

        #region Public functions

        /// <summary>
        /// Function to reduce or increase the players health value. Values of negative will reduce the health while positive will increase.
        /// </summary>
        /// <param name="healthChange">Positive value to increase health by, negative value to decrease health by.</param>
        public void HealthUpdate(int healthChange)
        {
            health += healthChange;
            OnHealthUpdate.Invoke();
        }

        /// <summary>
        /// Function to reduce the dodge timer after the player dodges.
        /// </summary>
        /// <param name="dodgeChange">value to reduce the dodge timer by</param>
        public void DodgeUpdate(float dodgeChange)
        {
            currentDodgeTimer -= dodgeChange;
            OnDodgeUpdate.Invoke();
        }

        #endregion

    }
}
