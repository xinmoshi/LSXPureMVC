using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using LitJson;

public class TestCommand : SimpleCommand {
	public new const string NAME = "TestCommand";

	public override void Execute (PureMVC.Interfaces.INotification notification)
	{
		switch(notification.Name)
		{
		case NotificationConst.LevelUp:
			
			Debug.Log("接收到请求消息");

			object cInfoObj = notification.Body;

			TestProxy proxy = Facade.RetrieveProxy(TestProxy.NAME) as TestProxy;
			proxy.ChangeLevel(cInfoObj);

			break;
		}

	}
}
