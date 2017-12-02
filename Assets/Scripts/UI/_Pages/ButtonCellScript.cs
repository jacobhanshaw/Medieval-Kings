using UnityEngine.UI;

public class ButtonCellScript : CellScript
{
	protected Button button;
	public delegate void CellClicked (int index);
	protected CellClicked CellClickedHandler;

	protected sealed override void Prepare ()
	{
		base.Prepare();

		button = gameObject.GetComponent<Button> ();
		button.onClick.AddListener (CellClickedFunction);
	}

	public void CellClickedFunction ()
	{
		if (CellClickedHandler != null)
			CellClickedHandler (index);
	}
}
