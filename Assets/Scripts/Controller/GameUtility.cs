using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUtility : MonoBehaviour {

	/// <summary>
	/// Gets the child.获取子节点
	/// </summary>
	public static Transform GetChild(GameObject root, string path)
	{
		Transform tra = root.transform.Find(path);
		if(tra == null)
			Debug.LogError(path+"没有找到");
		return tra;
	}

	/// <summary>
	/// Gets the child component.获取子节点组件
	/// </summary>
	public static T GetChildComponent<T>(GameObject root, string path) where T : Component
	{
		Transform tra = root.transform.Find(path);
		if(tra == null) Debug.LogError(path+"没有找到");
		T t = tra.GetComponent<T>();
		return t;
	}
		
}
