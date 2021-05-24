using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromiseFactory : MonoBehaviour
{
	public GameObject PromiseExecutor;

	public void createPromise(PromiseExecutor.voidFunctionHolder F, float timeTo)
	{
		GameObject promiseObject = GameObject.Instantiate(PromiseExecutor);
		PromiseExecutor tempPromise = promiseObject.GetComponent<PromiseExecutor>();

		tempPromise.AssignFunction( F , timeTo);
	}

	public void createPromise(PromiseExecutor.voidFunctionHolder F, float timeTo, string CallerName)
	{
		GameObject promiseObject = GameObject.Instantiate(PromiseExecutor);
		promiseObject.name = $"Promise {CallerName}";
		PromiseExecutor tempPromise = promiseObject.GetComponent<PromiseExecutor>();

		tempPromise.AssignFunction( F, timeTo);
	}

	public void createInterpolatePromise(PromiseExecutor.voidFunctionInterpolateHolder F, float timeTo)
	{
		GameObject promiseObject = GameObject.Instantiate(PromiseExecutor);
		PromiseExecutor tempPromise = promiseObject.GetComponent<PromiseExecutor>();

		tempPromise.AssignInterpolateFunction( F , timeTo);
	}
	public void createInterpolatePromise(PromiseExecutor.voidFunctionInterpolateHolder F, float timeTo, string CallerName)
	{
		GameObject promiseObject = GameObject.Instantiate(PromiseExecutor);
		promiseObject.name = $"Interpolate Promise {CallerName}";
		PromiseExecutor tempPromise = promiseObject.GetComponent<PromiseExecutor>();

		tempPromise.AssignInterpolateFunction( F , timeTo);
	}
}
