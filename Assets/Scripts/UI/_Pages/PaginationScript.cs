using UnityEngine;

public class PaginationScript : MonoBehaviour {

	public float spacing;
	public GameObject togglerTemplate;

	private GameObject[] toggles;

	public void SetUpPaginationToggles (int pageCount)
	{
		if(toggles == null)
		{
			if(pageCount <= 0)
				return;
			
			toggles = new GameObject[pageCount];
			for(int i = 0; i < pageCount; ++i)
			{
				toggles[i] = Instantiate(togglerTemplate, Vector3.zero, Quaternion.identity) as GameObject;
				toggles[i].transform.SetParent(transform);
			}
		}
		else if(toggles.Length != pageCount)
		{
			GameObject[] newToggles = new GameObject[pageCount];
			if(toggles.Length > pageCount)
			{
				for(int i = toggles.Length - 1; i >= pageCount; --i)
					Destroy(toggles[i].gameObject);
			}
			else
			{
				for(int i = toggles.Length; i < pageCount; ++i)
				{
					newToggles[i] = Instantiate(togglerTemplate, Vector3.zero, Quaternion.identity) as GameObject;
					newToggles[i].transform.SetParent(transform);
				}
			}

			for(int i = 0; i < Mathf.Min(toggles.Length, pageCount); ++i)
				newToggles[i] = toggles[i];
			toggles = newToggles;
		}

		float toggleWidth = toggles[0].GetComponent<RectTransform> ().sizeDelta.x;
		float totalSpace = toggleWidth * (float)pageCount + spacing * (float)(pageCount - 1);
		float position = -totalSpace/2.0f + toggleWidth/2.0f;
		for(int i = 0; i < toggles.Length; ++i)
		{
			toggles[i].transform.localPosition = new Vector2(position, 0);
			toggles[i].transform.localScale = new Vector2(1.0f, 1.0f);
			position += toggleWidth + spacing;
		}
	}
}
