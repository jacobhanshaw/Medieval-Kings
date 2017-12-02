using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DossierPagesScript : PagesScript {

	public override int PageCount ()
	{
		return GameManager.Instance.characters.Length;
	}

	public override int StartPage ()
	{
		return 0;
	}
}
