using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromiseExecutor : MonoBehaviour
{
	// Function to be assigned 
	public delegate void voidFunctionHolder();
	// Variable to be assigned via the function
	public voidFunctionHolder voidFunction;
	// Max time until the promise is destoryed
	private float MaxTime;
	// Optional Name of promise
	private string CallerName;

	// Function to be assigned
	public delegate void voidFunctionInterpolateHolder(float percentDone);
	// Varibable to be assigned via the function
	public voidFunctionInterpolateHolder voidFunctionInterpolate;
	// interpolating variable
	private float TimePassed;
	// interpolating bool
	private bool isInterpolate = false;

	private void Awake()
	{
		TimePassed = 0f;
	}

	private void Update()
	{
		if (isInterpolate)
		{
			TimePassed += Time.deltaTime;
			if (TimePassed < MaxTime)
			{
				voidFunctionInterpolate(TimePassed / MaxTime);
			}
			else
			{
				voidFunctionInterpolate(1);
				cleanUp();
			}
		}
	}

	public void AssignInterpolateFunction(voidFunctionInterpolateHolder F, float CallIn) {
		MaxTime = CallIn;
		isInterpolate = true;
		voidFunctionInterpolate = F;
	}

	public void AssignFunction(voidFunctionHolder F, float CallIn)
	{
		voidFunction = F;
		MaxTime = CallIn;
		StartCoroutine("WaitForTimer");
	}

	public IEnumerator WaitForTimer()
	{
		if (MaxTime < 0)
		{
			yield return null;
		}
		else
		{
			yield return new WaitForSeconds(MaxTime);
		}
		runFunction();
	}

	public void runFunction()
	{
		voidFunction();
		cleanUp();
	}

	public void cleanUp()
	{
		Destroy(this.gameObject);
	}
}
