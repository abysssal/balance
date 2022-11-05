using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;

public class DiscordController : MonoBehaviour
{
    public Discord.Discord discord;

    private void Start()
    {
        discord = new Discord.Discord(1035365514345709608, (System.UInt64)Discord.CreateFlags.Default);
        var activityManager = discord.GetActivityManager();
        var activity = new Discord.Activity
        {
            State = "Shooting circles to defend a circle",
            Details = "haha gun go pew pew",
            Assets =
            {
                LargeImage = "balanceiconthing"
            }
        };
        activityManager.UpdateActivity(activity, (res) =>
        {
            if (res == Result.Ok)
            {
                Debug.Log("Discord successfully connected!");
            } else
            {
                Debug.LogError("Discord connection failed");
            }
        });
    }

    private void Update()
    {
        discord.RunCallbacks();
    }
}
