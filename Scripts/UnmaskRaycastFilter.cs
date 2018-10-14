using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Coffee.UIExtensions
{
	/// <summary>
	/// Unmask Raycast Filter.
	/// The ray passes through the unmasked rectangle.
	/// </summary>
	[AddComponentMenu("UI/Unmask/UnmaskRaycastFilter", 2)]
	public class UnmaskRaycastFilter : MonoBehaviour, ICanvasRaycastFilter
	{
		//################################
		// Constant or Static Members.
		//################################
		Vector3[] s_WorldCorners = new Vector3[4];


		//################################
		// Serialize Members.
		//################################
		[Tooltip("Target unmask component. The ray passes through the unmasked rectangle.")]
		[SerializeField] Unmask m_TargetUnmask;


		//################################
		// Public Members.
		//################################
		/// <summary>
		/// Target unmask component. Ray through the unmasked rectangle.
		/// </summary>
		public Unmask targetUnmask{ get { return m_TargetUnmask; } set { m_TargetUnmask = value; } }

		/// <summary>
		/// Given a point and a camera is the raycast valid.
		/// </summary>
		/// <returns>Valid.</returns>
		/// <param name="sp">Screen position.</param>
		/// <param name="eventCamera">Raycast camera.</param>
		public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
		{
			// Skip if deactived.
			if (!isActiveAndEnabled || !m_TargetUnmask || !m_TargetUnmask.isActiveAndEnabled)
			{
				return true;
			}

			// Get world corners for the target.
			(m_TargetUnmask.transform as RectTransform).GetWorldCorners(s_WorldCorners);

			// Convert to screen positions.
			var cam = eventCamera ?? Camera.main;
			var p = cam.WorldToScreenPoint(sp);
			var a = cam.WorldToScreenPoint(s_WorldCorners[0]);
			var b = cam.WorldToScreenPoint(s_WorldCorners[1]);
			var c = cam.WorldToScreenPoint(s_WorldCorners[2]);
			var d = cam.WorldToScreenPoint(s_WorldCorners[3]);

			// check left/right side
			var ab = Cross(p - a, b - a) < 0.0;
			var bc = Cross(p - b, c - b) < 0.0;
			var cd = Cross(p - c, d - c) < 0.0;
			var da = Cross(p - d, a - d) < 0.0;

			// check inside
			return ab ^ bc ||bc ^ cd ||cd ^ da;
		}


		//################################
		// Private Members.
		//################################

		/// <summary>
		/// This function is called when the object becomes enabled and active.
		/// </summary>
		void OnEnable()
		{
		}

		/// <summary>
		/// Cross for Vector2.
		/// </summary>
		float Cross(Vector2 a, Vector2 b)
		{
			return a.x * b.y - a.y * b.x;
		}
	}
}