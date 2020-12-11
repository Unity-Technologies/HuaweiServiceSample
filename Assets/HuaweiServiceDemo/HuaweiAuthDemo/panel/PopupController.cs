using System.Collections;
using System.Collections.Generic;
using HuaweiAuthDemo;
using TMPro;
using UnityEngine;

namespace HuaweiAuthDemo
{
     public class PopupController : MonoBehaviour
    {
        public GameObject errorPopup;
        public GameObject infoPopup;

        CanvasGroup m_ErrorCanvas;
        CanvasGroup m_InfoCanvas;
        TextMeshProUGUI m_InfoText;
        TextMeshProUGUI m_ErrorText;

        public float timeBeforeHide = 2.0f;
        public float fadeTime = .3f;
        public float verticalTextMargin = 15.0f;

        private float m_BasePopupHeight;

        private bool m_IsShowingPopup = false;
        private Coroutine m_ShowPopupCoroutine = null;

        private void Awake()
        {
            m_BasePopupHeight = (transform as RectTransform).sizeDelta[1];

            m_ErrorText = errorPopup.GetComponentInChildren<TextMeshProUGUI>();
            m_ErrorText.text = "";

            m_InfoText = infoPopup.GetComponentInChildren<TextMeshProUGUI>();
            m_InfoText.text = "";

            m_ErrorCanvas = errorPopup.GetComponent<CanvasGroup>();
            m_ErrorCanvas.alpha = 0.0f;

            m_InfoCanvas = infoPopup.GetComponent<CanvasGroup>();
            m_InfoCanvas.alpha = 0.0f;
        }

        public void ShowInfo(string message)
        {
            if(m_InfoText != null)
            {
                StopShowingPopup();
                m_InfoText.text = message;

                m_ShowPopupCoroutine = StartCoroutine(ShowPopupCoroutine(m_InfoCanvas, m_InfoText));
            }
        }

        public void ShowError(Error error)
        {
            if (m_ErrorText != null)
            {
                StopShowingPopup();
                if (error.errorClass == ErrorClass.ActionCancelled)
                {
                    return;
                }

                m_ErrorText.text = error.message ?? error.type;
                m_ShowPopupCoroutine = StartCoroutine(ShowPopupCoroutine(m_ErrorCanvas, m_ErrorText));
            }
        }

        private void StopShowingPopup()
        {
            if (m_IsShowingPopup)
            {
                StopCoroutine(m_ShowPopupCoroutine);
                m_IsShowingPopup = false;
            }
        }

        /// <summary>
        /// Expand/Shrink the container if the text doesnt fit
        /// </summary>
        private void ResizeContainer(TextMeshProUGUI textMesh)
        {
            // This call ensures that the height of the text will be correct during this frame

            RectTransform rectTransform = transform as RectTransform;
            Vector2 rectSize = rectTransform.sizeDelta;

            float textHeightWithMargin = textMesh.GetRenderedValues()[1] + verticalTextMargin * 2;
            float newHeight = textHeightWithMargin <= m_BasePopupHeight ? m_BasePopupHeight : textHeightWithMargin;

            rectTransform.sizeDelta = new Vector2(rectSize[0], newHeight);
        }

        IEnumerator ShowPopupCoroutine(CanvasGroup canvas, TextMeshProUGUI textMesh)
        {
            m_IsShowingPopup = true;
            ResizeContainer(textMesh);
            yield return FadeInCanvas(canvas);
            yield return new WaitForSeconds(timeBeforeHide);
            yield return FadeOutCanvas(canvas);
            m_IsShowingPopup = false;
        }

        IEnumerator FadeInCanvas(CanvasGroup canvas)
        {
            yield return StartCoroutine(FadeCanvas(canvas,0.0f, 1.0f, fadeTime));
        }

        IEnumerator FadeOutCanvas(CanvasGroup canvas)
        {
            yield return StartCoroutine(FadeCanvas(canvas, 1.0f, 0.0f, fadeTime));
        }

        IEnumerator FadeCanvas(CanvasGroup canvas, float startAlpha, float endAlpha, float duration)
        {
            float startTime = Time.time;
            float endTime = Time.time + duration;
            float elapsedTime = 0f;

            canvas.alpha = startAlpha;

            while (Time.time < endTime)
            {
                elapsedTime = Time.time - startTime;
                float percentage = 1 / (duration / elapsedTime);
                canvas.alpha = startAlpha > endAlpha ? 1-percentage : percentage;
                yield return new WaitForEndOfFrame();
            }

            canvas.alpha = endAlpha;
        }
    }
}