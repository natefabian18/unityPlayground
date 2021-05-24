using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
	public static Constants C;

	private void Awake()
	{
		if (Constants.C == null)
		{
			Constants.C = this;
			Debug.Log("Constants init");
			initVars();
		}
	}

	private void initVars() { 
		
	}
}
