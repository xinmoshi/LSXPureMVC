using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using LitJson;

public class TestProxy : Proxy {

	public new const string NAME = "TestProxy";
	CharaterInfo cInfo;

	public TestProxy():base(NAME)
	{
		cInfo = CharaterInfo.ShareInfo;
	}

	public void ChangeLevel(object info)
	{
		
		//将json数据打包到CharaterInfo里面去
		string cInfoJson = JsonMapper.ToJson(info);
		JsonData cInfoData = JsonMapper.ToObject(cInfoJson);

		cInfo.Name = cInfoData["name"].ToString();
		cInfo.Level = int.Parse(cInfoData["level"].ToString());
		cInfo.Hp = int.Parse(cInfoData["hp"].ToString());

		//让UI去修改数据 转发数据到UI界面
		SendNotification(NotificationConst.LevelChange, cInfo);
	}
}
