using Eos.Events.ScriptableObjects;
using UnityEngine;
using Eos.Runtime.Core;
using Eos.Runtime.Interface;

namespace Eos.Runtime.Handler
{
    public class InputHandler : MonoBehaviour, ITick
    {
        [Header("Broadcasting on")] [SerializeField]
        private MouseEventChannelSO onMouseEventChannel;

        public Vector3 mousePosition => Input.mousePosition;
        public Vector2 mouseMoveDelta => new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        public Vector2 mouseScrollDelta => Input.mouseScrollDelta;
        
        public bool IsLeftMouseButtonHold() => Input.GetMouseButton(0);
        public bool IsLeftMouseButtonPress() => Input.GetMouseButtonDown(0);
        public bool IsLeftMouseButtonRelease() => Input.GetMouseButtonUp(0);
        public bool IsRightMouseButtonHold() => Input.GetMouseButton(1);
        public bool IsRightMouseButtonPress() => Input.GetMouseButtonDown(1);
        public bool IsRightMouseButtonRelease() => Input.GetMouseButtonUp(1);
        public bool IsMiddleMouseButtonHold() => Input.GetMouseButton(2);
        public bool IsMiddleMouseButtonPress() => Input.GetMouseButtonDown(2);
        public bool IsMiddleMouseButtonRelease() => Input.GetMouseButtonUp(2);
        public bool IsMouseMoving() => mouseMoveDelta != Vector2.zero;
        public bool IsMouseScrolling() => mouseScrollDelta.y != 0;
        [Header("Debug")]
        public int leftMouseButtonHoldFrames;
        public int middleMouseButtonHoldFrames;
        public int rightMouseButtonHoldFrames;
        public bool IsShiftKeyPressed() => Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);


        private void Start()
        {
            UpdateHandler.instance.Register(this);
        }

        private void OnDestroy()
        {
            UpdateHandler.instance.Unregister(this);
        }

        public void Tick()
        {
            if (IsLeftMouseButtonPress()) OnLeftMouseButtonPressed();

            if (IsLeftMouseButtonRelease()) OnLeftMouseButtonReleased();

            if (IsLeftMouseButtonHold()) OnLeftMouseButtonHold();

            if (IsMiddleMouseButtonPress()) OnMiddleMouseButtonPressed();

            if (IsMiddleMouseButtonRelease()) OnMiddleMouseButtonReleased();

            if (IsMiddleMouseButtonHold()) OnMiddleMouseButtonHold();

            if (IsRightMouseButtonPress()) OnRightMouseButtonPressed();

            if (IsRightMouseButtonRelease()) OnRightMouseButtonReleased();

            if (IsRightMouseButtonHold()) OnRightMouseButtonHold();

            if (IsMouseMoving()) OnMouseMoving();

            if (IsMouseScrolling()) OnMouseScrolling();
        }

        private void OnLeftMouseButtonPressed()
        {
            onMouseEventChannel.RaiseLMBPressEvent();
        }

        private void OnLeftMouseButtonReleased()
        {
            onMouseEventChannel.RaiseLMBReleaseEvent();
            leftMouseButtonHoldFrames = 0;
        }

        private void OnLeftMouseButtonHold()
        {
            onMouseEventChannel.RaiseLMBHoldEvent();
            leftMouseButtonHoldFrames++;
            onMouseEventChannel.RaiseLMBHoldFramesEvent(leftMouseButtonHoldFrames);
        }

        private void OnMiddleMouseButtonPressed()
        {
            onMouseEventChannel.RaiseMMBPressEvent();
        }

        private void OnMiddleMouseButtonReleased()
        {
            onMouseEventChannel.RaiseMMBReleaseEvent();
            middleMouseButtonHoldFrames = 0;
        }

        private void OnMiddleMouseButtonHold()
        {
            onMouseEventChannel.RaiseMMBHoldEvent();
            middleMouseButtonHoldFrames++;
            onMouseEventChannel.RaiseMMBHoldFramesEvent(middleMouseButtonHoldFrames);
        }

        private void OnRightMouseButtonPressed()
        {
            onMouseEventChannel.RaiseRMBPressEvent();
        }

        private void OnRightMouseButtonReleased()
        {
            onMouseEventChannel.RaiseRMBReleaseEvent();
            rightMouseButtonHoldFrames = 0;
        }

        private void OnRightMouseButtonHold()
        {
            onMouseEventChannel.RaiseRMBHoldEvent();
            rightMouseButtonHoldFrames++;
            onMouseEventChannel.RaiseRMBHoldFramesEvent(rightMouseButtonHoldFrames);
        }

        private void OnMouseMoving()
        {
            var mousePositionInt = Vector2Int.RoundToInt(mousePosition * 10f);
            var mouseMoveDeltaInt = Vector2Int.RoundToInt(mouseMoveDelta * 100f);
            onMouseEventChannel.RaiseMousePositionEvent(mousePositionInt);
            onMouseEventChannel.RaiseMouseMoveDeltaEvent(mouseMoveDeltaInt);
        }

        private void OnMouseScrolling()
        {
            Debug.Log(mouseScrollDelta);
            var mouseScrollDeltaInt = (int)(mouseScrollDelta.y * 10f);
            onMouseEventChannel.RaiseMouseScrollDeltaEvent(mouseScrollDeltaInt);
        }
    }
}