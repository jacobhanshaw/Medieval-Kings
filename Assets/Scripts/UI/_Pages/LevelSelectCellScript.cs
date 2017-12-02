using UnityEngine;
using UnityEngine.UI;

public sealed class LevelSelectCellScript : ButtonCellScript
{
	[SerializeField]
	private Text nameText;
	[SerializeField]
	private Image solvedImage;
	[SerializeField]
	private Text solvedText;
	[SerializeField]
	private Button deleteButton;

	CellClicked CellDeleteClickedHandler;

	const float DISABLED_ALPHA = 128f/255f;
	//Color DISABLED_TEXT_COLOR = new Color(0.1961f, 0.1961f, 0.1961f);

	public void UpdateWithIndexDelegateAndName (int aIndex, CellClicked aCellClickedHandler, CellClicked aCellDeleteClickedHandler, string aName, bool showImage)
	{
		if (!prepared)
			Prepare ();

		index = aIndex;
		button.interactable = aCellClickedHandler != null;
		if (aCellClickedHandler != null)
		{
			CellClickedHandler = aCellClickedHandler;
			if(nameText.color.a != 1f)
				nameText.color = new Color(nameText.color.r, nameText.color.g, nameText.color.b, 1f);
		}
		else
		{
			int nameNumber;
			bool isNumeric = int.TryParse(aName, out nameNumber);
			if(isNumeric)
				nameText.color = new Color(nameText.color.r, nameText.color.g, nameText.color.b, DISABLED_ALPHA);
		}

		nameText.text = aName;
		solvedImage.enabled = showImage;

		if(solvedText != null)
		{
			if(showImage)
				solvedText.text = (aIndex + 1).ToString();
			else
				solvedText.text = "";
		}

		CellDeleteClickedHandler = aCellDeleteClickedHandler;
		if(deleteButton != null)
			deleteButton.onClick.AddListener(DeleteButtonPressed);
	}

	void DeleteButtonPressed()
	{
		if(CellDeleteClickedHandler != null)
			CellDeleteClickedHandler(index);
	}
}
