using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UIExtensions.Demos
{
	public class Unmask_Demo : MonoBehaviour
	{
		[SerializeField] Button target;
		[SerializeField] Unmask unmask;
		[SerializeField] Graphic transition;
		[SerializeField] Image transitionImage;
		[SerializeField] Sprite unity_chan;
		[SerializeField] Sprite unity_frame;

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
	}
}