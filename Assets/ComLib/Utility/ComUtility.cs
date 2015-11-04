using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace ComLib
{
	public class ComUtility
	{
		//------------------------------------------------------------------------------------------------------------------------
		// time
		public static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

		public static long DateTimeToSeconds ( DateTime date_ )
		{
			if(date_ == DateTime.MinValue)
			{
				return -1;
			}

			TimeSpan span = (date_ - UnixEpoch);
			return (int)Math.Floor(span.TotalSeconds);
		}

		public static void UnixTimeToDateTime ()
		{}
		
		//------------------------------------------------------------------------------------------------------------------------
		// release

		public static void ClearListUsingDestructor<T> ( ref List<T> list_ ) where T : class
		{
			T[] array = null;
			
			if(list_ != null && list_.Count > 0)
			{
				array = list_.ToArray();
				for(int i = 0; i < array.Length; i++)
				{
					array[i] = null;
				}
				array = null;
				list_.Clear();
			}
			list_ = null;
		}

		public static void ClearListUsingDestroy<T> ( ref List<T> list_ ) where T : Component
		{
			T[] array = null;
			
			if(list_ != null && list_.Count > 0)
			{
				array = list_.ToArray();
				for(int i = 0; i < array.Length; i++)
				{
					GameObject.Destroy(array[i].gameObject);
				}
				array = null;
				list_.Clear();
			}
			list_ = null;
		}
	}
}