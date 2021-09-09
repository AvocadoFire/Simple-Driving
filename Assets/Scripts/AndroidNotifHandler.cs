using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;
using System;

public class AndroidNotifHandler : MonoBehaviour
{
    private const string ChannelId = "notification_channel";
    public void ScheduleNotification(DateTime dateTime)
    {
        AndroidNotificationChannel notificationChannel = new AndroidNotificationChannel
        {
            Id = ChannelId, 
            Name = "Notification Channel",
            Description = "Some random description",
            Importance = Importance.Default
        };
    }

}
