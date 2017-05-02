using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaterInfo {

	public string Name;
	public int Level;
	public int Hp;

	private static CharaterInfo info = null;

	public static CharaterInfo ShareInfo
	{
		get
		{
			if(info==null)
			{
				info = new CharaterInfo();
			}
			return info;
		}
	}


}
