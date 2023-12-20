#region

using UnityEngine;

#endregion

namespace Eos.Players.Main
{
    public class PlayerInputState
    {
        #region Public Variables

        public float Pitch      { get; private set; }
        public float Yaw        { get; private set; }
        public float Dolly      { get; private set; }
        public float Horizontal { get; private set; }
        public float Vertical   { get; private set; }
        public bool  Dodge      { get; private set; }
        public bool  TurnAround { get; private set; }
        public bool  LockTarget { get; private set; }

        #endregion

        #region Public Methods

        public void SetPitch(float pitch) => Pitch = pitch;

        public void SetYaw(float yaw) => Yaw = yaw;

        public void SetDolly(float dolly) => Dolly = dolly;

        public void SetHorizontal(float horizontal) => Horizontal = horizontal;

        public void SetVertical(float vertical) => Vertical = vertical;

        public void SetDodge(bool dodge) => Dodge = dodge;

        public void SetTurnAround(bool turnAround) => TurnAround = turnAround;

        public void SetLockTarget(bool lockTarget) => LockTarget = lockTarget;

        #endregion
    }
}