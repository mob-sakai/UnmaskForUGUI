using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;


namespace Coffee.UIExtensions
{
	/// <summary>
	/// Reverse masking for parent Mask component.
	/// </summary>
	[ExecuteInEditMode]
	[AddComponentMenu("UI/Unmask/Unmask", 1)]
	public class Unmask : MonoBehaviour, IMaterialModifier
	{
		//################################
		// Constant or Static Members.
		//################################
		static readonly Vector2 s_Center = new Vector2(0.5f, 0.5f);


		//################################
		// Serialize Members.
		//################################
		[Tooltip("Fit graphic's transform to target transform.")]
		[SerializeField] RectTransform m_FitTarget;
		[Tooltip("Fit sprite's transform to target transform.")]
		[SerializeField] SpriteRenderer m_SpriteTarget;
		[Tooltip("Given the fit graphic's transform or sprite's transform, it will work as a offset to adjust fit target position")]
		[SerializeField] private Vector2 Offset;
		[Tooltip("Given the fit graphic's transform or sprite's transform, it will work as a scale factor to adjust fit target size")]
		[SerializeField] private float scaleFactor = 1f;
		[Tooltip("Fit graphic's transform to target transform on LateUpdate every frame.")]
		[SerializeField] bool m_FitOnLateUpdate;
		[Tooltip ("Unmask affects only for children.")]
		[SerializeField] bool m_OnlyForChildren = false;
		[Tooltip("Show the graphic that is associated with the unmask render area.")]
		[SerializeField] bool m_ShowUnmaskGraphic = false;


		//################################
		// Public Members.
		//################################
		/// <summary>
		/// The graphic associated with the unmask.
		/// </summary>
		public Graphic graphic{ get { return _graphic ?? (_graphic = GetComponent<Graphic>()); } }

		/// <summary>
		/// Fit graphic's transform to target transform.
		/// </summary>
		public RectTransform fitTarget
		{
			get { return m_FitTarget; }
			set
			{
				m_FitTarget = value;
				FitTo(m_FitTarget,m_FitTarget.rect.size*scaleFactor,Offset);
			}
		}

		public SpriteRenderer spriteTarget
		{
			get { return m_SpriteTarget; }
			set 
			{
				m_SpriteTarget = value;
				FitTo(m_SpriteTarget.gameObject.transform, m_SpriteTarget.size * scaleFactor,Offset);
			}
		}

		/// <summary>
		/// Fit graphic's transform to target transform on LateUpdate every frame.
		/// </summary>
		public bool fitOnLateUpdate{ get { return m_FitOnLateUpdate; } set { m_FitOnLateUpdate = value; } }

		/// <summary>
		/// Show the graphic that is associated with the unmask render area.
		/// </summary>
		public bool showUnmaskGraphic
		{
			get { return m_ShowUnmaskGraphic; }
			set
			{
				m_ShowUnmaskGraphic = value;
				SetDirty();
			}
		}

		/// <summary>
		/// Unmask affects only for children.
		/// </summary>
		public bool onlyForChildren
		{
			get { return m_OnlyForChildren; }
			set
			{
				m_OnlyForChildren = value;
				SetDirty ();
			}
		}

		/// <summary>
		/// Perform material modification in this function.
		/// </summary>
		/// <returns>Modified material.</returns>
		/// <param name="baseMaterial">Configured Material.</param>
		public Material GetModifiedMaterial(Material baseMaterial)
		{
			if (!isActiveAndEnabled)
			{
				return baseMaterial;
			}

			Transform stopAfter = MaskUtilities.FindRootSortOverrideCanvas(transform);
			var stencilDepth = MaskUtilities.GetStencilDepth(transform, stopAfter);
			var desiredStencilBit = 1 << stencilDepth;
			
			StencilMaterial.Remove(_unmaskMaterial);
			_unmaskMaterial = StencilMaterial.Add(baseMaterial, desiredStencilBit - 1, StencilOp.Invert, CompareFunction.Equal, m_ShowUnmaskGraphic ? ColorWriteMask.All : (ColorWriteMask)0, desiredStencilBit - 1, (1 << 8) - 1);


			// Unmask affects only for children.
			var canvasRenderer = graphic.canvasRenderer;
			if (m_OnlyForChildren)
			{
				StencilMaterial.Remove (_revertUnmaskMaterial);
				_revertUnmaskMaterial = StencilMaterial.Add(baseMaterial, (1 << 7), StencilOp.Invert, CompareFunction.Equal, (ColorWriteMask)0, (1 << 7), (1 << 8) - 1);
				canvasRenderer.hasPopInstruction = true;
				canvasRenderer.popMaterialCount = 1;
				canvasRenderer.SetPopMaterial (_revertUnmaskMaterial, 0);
			}
			else
			{
				canvasRenderer.hasPopInstruction = false;
				canvasRenderer.popMaterialCount = 0;
			}

			return _unmaskMaterial;
		}

		/// <summary>
		/// Fit to target transform.
		/// </summary>
		/// <param name="target">Target transform.</param>
		public void FitTo(RectTransform target)
		{
			FitTo(target,target.rect.size,Vector2.zero);
		}

		public void FitTo(RectTransform target, Vector2 offset)
		{
			FitTo(target,target.rect.size,offset);
		}
		
		public void FitTo(Transform target, Vector2 size)
		{
			FitTo(target,size,Vector2.zero);
		}
		
		public void FitTo(RectTransform target, Vector2 size, Vector3 offSet)
		{
			var rt = transform as RectTransform;
			
			rt.pivot = target.pivot;
			rt.position = target.position + offSet;
			rt.rotation = target.rotation;

			var s1 = target.lossyScale;
			var s2 = rt.parent.lossyScale;
			rt.localScale = new Vector3(s1.x / s2.x, s1.y / s2.y, s1.z / s2.z);
			rt.sizeDelta = size;
			rt.anchorMax = rt.anchorMin = s_Center;
		}

		public void FitTo(Transform target, Vector2 size, Vector3 offSet)
		{
			var rt = transform as RectTransform;
			
			rt.position = target.position + offSet;
			rt.rotation = target.rotation;

			var s1 = target.lossyScale;
			var s2 = rt.parent.lossyScale;
			rt.localScale = new Vector3(s1.x / s2.x, s1.y / s2.y, s1.z / s2.z);
			rt.sizeDelta = size;
			rt.anchorMax = rt.anchorMin = s_Center;
		}


		//################################
		// Private Members.
		//################################
		Material _unmaskMaterial;
		Material _revertUnmaskMaterial;
		Graphic _graphic;

		/// <summary>
		/// This function is called when the object becomes enabled and active.
		/// </summary>
		void OnEnable()
		{
			if (m_FitTarget)
			{
				FitTo(m_FitTarget,m_FitTarget.rect.size * scaleFactor,Offset);
			} else if (m_SpriteTarget) 
			{
				FitTo(m_SpriteTarget.gameObject.transform, m_SpriteTarget.size * scaleFactor,Offset);
			}
			SetDirty();
		}

		/// <summary>
		/// This function is called when the behaviour becomes disabled () or inactive.
		/// </summary>
		void OnDisable()
		{
			StencilMaterial.Remove (_unmaskMaterial);
			StencilMaterial.Remove (_revertUnmaskMaterial);
			_unmaskMaterial = null;
			_revertUnmaskMaterial = null;

			if (graphic)
			{
				var canvasRenderer = graphic.canvasRenderer;
				canvasRenderer.hasPopInstruction = false;
				canvasRenderer.popMaterialCount = 0;
				graphic.SetMaterialDirty();
			}
			SetDirty ();
		}

		/// <summary>
		/// LateUpdate is called every frame, if the Behaviour is enabled.
		/// </summary>
		void LateUpdate()
		{
#if UNITY_EDITOR
			if ((m_FitTarget || m_SpriteTarget) && (m_FitOnLateUpdate || !Application.isPlaying))
#else
			if ((m_FitTarget || m_SpriteTarget) && m_FitOnLateUpdate)
#endif
			{
				if (m_FitTarget) {
					FitTo(m_FitTarget,m_FitTarget.rect.size * scaleFactor,Offset);
				} else if (m_SpriteTarget) {
					FitTo(m_SpriteTarget.gameObject.transform, m_SpriteTarget.size * scaleFactor,Offset);
				}
			}
		}

#if UNITY_EDITOR
		/// <summary>
		/// This function is called when the script is loaded or a value is changed in the inspector (Called in the editor only).
		/// </summary>
		void OnValidate()
		{
			SetDirty();
		}
#endif

		/// <summary>
		/// Mark the graphic as dirty.
		/// </summary>
		void SetDirty()
		{
			if (graphic)
			{
				graphic.SetMaterialDirty();
			}
		}
	}
}