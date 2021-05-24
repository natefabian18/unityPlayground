using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromiseTester : MonoBehaviour
{
	//there is a better way to do this using emerable types, too bad!
	public bool[] promiseTestOption = { false, false, false, false };

	private PromiseFactory promiseFactory;

	private Vector3 startPosition;
	private Vector3 endPosition;

	// Start is called before the first frame update
	void Start()
	{
		startPosition = this.gameObject.transform.position;
		endPosition = this.gameObject.transform.position + new Vector3(5f, 0, 0);

		promiseFactory = GameObject.FindGameObjectWithTag("PromiseFactory").GetComponent<PromiseFactory>();

		promiseFactory.createPromise(beginTest, 5f, "begin Test");
	}

	public void beginTest() {
		if (promiseTestOption[0])
		{
			promiseFactory.createPromise(testFunction, 5f);
		}
		else if (promiseTestOption[1])
		{
			promiseFactory.createPromise(testFunction, 2f, "Dave");
		}
		else if (promiseTestOption[2])
		{
			promiseFactory.createInterpolatePromise(testInterpolateFunction, 3f);
		}
		else if (promiseTestOption[3])
		{
			promiseFactory.createInterpolatePromise(testInterpolateFunction, 1f, "Charles");
		}
	}

	public void testFunction()
	{
		Debug.Log($"{this.gameObject.name} test function ran");
		this.gameObject.transform.position += new Vector3(5f, 0, 0);
	}

	public void testInterpolateFunction(float percentage)
	{
		Debug.Log($"{this.gameObject.name} test function ran with {System.Math.Round(percentage * 100, 2)}% complete");
		this.transform.position = Vector3.Lerp(startPosition, endPosition, percentage);
	}
}
