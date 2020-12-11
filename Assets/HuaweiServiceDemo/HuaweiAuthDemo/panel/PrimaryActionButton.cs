using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HuaweiAuthDemo
{

        public enum PrimaryActionType
        {
            FormSubmission,
            SettingsAction
        }

        /// <summary>
        /// Button for "primary action" with changing text color depending on its state
        /// </summary>
        public class PrimaryActionButton : Button
        {
            public PrimaryActionType actionType;
            public Color activeButtonTextColor;
            public Color inactiveButtonTextColor;
            public TextMeshProUGUI buttonText;

            protected override void DoStateTransition(SelectionState state, bool instant)
            {
                base.DoStateTransition(state, instant);

                if(buttonText != null)
                {
                    switch (state) {
                        case SelectionState.Disabled:
                            buttonText.color = inactiveButtonTextColor;
                            break;
                        case SelectionState.Normal:
                            buttonText.color = activeButtonTextColor;
                            break;
                    }
                }
            }
        }
    }
