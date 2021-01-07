using UnityEngine.InputSystem.Layouts;

namespace UnityEngine.InputSystem
{
    [InputControlLayout(stateType = typeof(HORIPADSwitchControllerHID))]
#if UNITY_EDITOR
    [UnityEditor.InitializeOnLoad]
#endif
    public class HORIPADSwitchController : Gamepad
    {
        /// <summary>
        /// The last used/added GameCube controller.
        /// </summary>
        public new static HORIPADSwitchController current { get; private set; }

        public override void MakeCurrent()
        {
            base.MakeCurrent();
            current = this;
        }

        protected override void OnRemoved()
        {
            base.OnRemoved();
            if (current == this)
            {
                current = null;
            }
        }

        static HORIPADSwitchController()
        {
            InputDeviceMatcher matcher = new InputDeviceMatcher().
                WithInterface("HID").
                WithCapability("vendorId", 0x0f0d).
                WithCapability("productId", 0xc1);
            InputSystem.RegisterLayout<HORIPADSwitchController>("HORIPAD Switch Controller", matches: matcher);
        }

        //gonna call the constractor like this
        [RuntimeInitializeOnLoadMethod]
        public static void Init()
        {

        }
    }
}
