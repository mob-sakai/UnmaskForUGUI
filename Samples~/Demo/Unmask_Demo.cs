using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UIExtensions.Demos
{
    public class Unmask_Demo : MonoBehaviour
    {
        [SerializeField] Unmask unmask = null;
        [SerializeField] Unmask[] smoothingUnmasks = new Unmask[0];
        [SerializeField] Graphic transition = null;
        [SerializeField] Image transitionImage = null;
        [SerializeField] Sprite unity_chan = null;
        [SerializeField] Sprite unity_frame = null;

        public void AutoFitToButton(bool flag)
        {
            unmask.fitOnLateUpdate = flag;
        }

        public void SetTransitionColor(bool flag)
        {
            transition.color = flag ? Color.white : Color.black;
        }

        public void SetTransitionImage(bool flag)
        {
            transitionImage.sprite = flag ? unity_chan : unity_frame;
            transitionImage.SetNativeSize();
            var size = transitionImage.rectTransform.rect.size;
            transitionImage.rectTransform.sizeDelta = new Vector2(150, size.y / size.x * 150);
        }

        public void EnableSmoothing(bool flag)
        {
            foreach (var unmask in smoothingUnmasks)
            {
                unmask.edgeSmoothing = flag ? 1 : 0;
            }
        }
    }
}