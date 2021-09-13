using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_IOS
using Unity.Notifications.iOS;
#endif

public class iOSNotificationHandler : MonoBehaviour
{
#if UNITY_IOS

    public void ScheduleNotification(int minutes)
    {
        iOSNotification notification = new iOSNotification
        {
            Title = "Energy Recharged",
            Subtitle = "Your energy has been recharged",
            Body = "Your energy has been recharged, come back to play again!",
            ShowInForeground = true, //pops up over other things
            ForegroundPresentationOption = (PresentationOption.Alert | PresentationOption.Sound), //have four different options
            CategoryIdentifier = "category_a", //this is the default
            ThreadIdentifier = "thread1", //this is the default
            Trigger = new iOSNotificationTimeIntervalTrigger  //what causes it to pop up
            {
                TimeInterval = new System.TimeSpan(0, minutes, 0),
                Repeats = false //make sure to use this!
            }
        };

        iOSNotificationCenter.ScheduleNotification(notification);
    }

#endif
}
