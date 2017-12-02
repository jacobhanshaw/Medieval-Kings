using UnityEngine;

public class PagesScript : MonoBehaviour 
{
	public PageScript[] pages;

	public delegate void ContentUpdated ();
	public ContentUpdated ContentUpdatedListeners;

	public GameObject cellPrefab;

	public virtual int PageCount ()
	{
		return 0;
	}

	public virtual int StartPage ()
	{
		return 0;
	}

	public void UpdateLayout(Vector2 minPadding, Vector2 minSpacing)
	{
		foreach(PageScript page in pages)
			page.UpdateLayout(cellPrefab, minPadding, minSpacing);

		if(ContentUpdatedListeners != null)
			ContentUpdatedListeners ();
	}

	public void UpdatePage(int index, int pageNumber)
	{
		pages[index].UpdatePage(pageNumber);
	}
}
