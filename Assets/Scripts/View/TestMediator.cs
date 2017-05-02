using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PureMVC.Patterns;
using LitJson;

public class TestMediator : Mediator {

	public new const string NAME = "TestMediator";

	private Text levelText;
	private Text hpText;
	private Button levelUpButton;

	private int level = 1;
	private int hp = 1000;

	public TestMediator( GameObject root):base(NAME)
	{
		levelText = GameUtility.GetChildComponent<Text>(root, "Text/LevelText");
		hpText = GameUtility.GetChildComponent<Text>(root, "Text/HPText");
		levelUpButton = GameUtility.GetChildComponent<Button>(root, "LevelUpButton");

		levelUpButton.onClick.AddListener(delegate {
			OnClickLevelUpButton();
		});
	}

	//发送升级请求消息  可以假想成服务器传来的消息
	private void OnClickLevelUpButton()
	{
		level += 1;
		hp += 100;

		//假设是服务器传过来的Json数据
		JsonData serverInfoData = new JsonData();
		serverInfoData["name"] = "lsx";
		serverInfoData["level"] = level.ToString();
		serverInfoData["hp"] = hp.ToString();

		SendNotification(NotificationConst.LevelUp, serverInfoData);
	}


	//增加监听任务到消息序列
	public override IList<string> ListNotificationInterests ()
	{
		IList<string> list = new List<string>();
		list.Add(NotificationConst.LevelChange);
		return list;
	}

	//监听消息回调
	public override void HandleNotification (PureMVC.Interfaces.INotification notification)
	{
		switch(notification.Name)
		{
		case NotificationConst.LevelChange:

			//改变界面
			CharaterInfo cInfo = CharaterInfo.ShareInfo;

			levelText.text = "LV:" + cInfo.Level.ToString();
			hpText.text = "HP:" + cInfo.Hp.ToString();

			Debug.Log("name:"+cInfo.Name + " level:"+cInfo.Level + " hp:"+cInfo.Hp);
			break;
			default :
			break;
		}
	}
}
