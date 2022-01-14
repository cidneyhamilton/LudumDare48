using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cyborg.Clinic {

				public class HideInWeb : MonoBehaviour
				{
								// Start is called before the first frame update
								void Start()
								{
												if (Application.isEditor || Application.platform == RuntimePlatform.WebGLPlayer) {
																gameObject.SetActive(false);
												}
								}

				}

}
