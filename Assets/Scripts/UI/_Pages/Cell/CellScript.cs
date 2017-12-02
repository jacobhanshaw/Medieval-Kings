using UnityEngine;

public class CellScript : MonoBehaviour
{
	protected bool prepared;
	public int index { get; protected set; }

	protected virtual void Prepare ()
	{
		prepared = true;
	}
}
