using UnityEngine;
using System.Collections;

namespace ComLib
{
	public class ComMonoBehaviour : MonoBehaviour 
	{
		public MonoBehaviour Mono
		{
			get
			{
				return this;
			}
		}
	}
}