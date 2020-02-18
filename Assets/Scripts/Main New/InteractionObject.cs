using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractionObject : MonoBehaviour
{
	public abstract Color GetColor();

	public abstract void Execute();
}
