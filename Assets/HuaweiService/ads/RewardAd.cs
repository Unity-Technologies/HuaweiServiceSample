using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.ads
{
    public class RewardAd_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.ads.reward.RewardAd";
    }
    public class RewardAd :HmsClass<RewardAd_Data>
    {
        public RewardAd (Context arg0, string arg1): base(arg0, arg1) { }
        public RewardAd (): base() { }
        public Reward getReward() {
            return Call<Reward>("getReward");
        }
        public static RewardAd createRewardAdInstance(Context arg0) {
            return CallStatic<RewardAd>("createRewardAdInstance", arg0);
        }
        public string getData() {
            return Call<string>("getData");
        }
        public string getUserId() {
            return Call<string>("getUserId");
        }
        public RewardAdListener getRewardAdListener() {
            return Call<RewardAdListener>("getRewardAdListener");
        }
        public void pause() {
            Call("pause");
        }
        public void pause(Context arg0) {
            Call("pause", arg0);
        }
        public void resume() {
            Call("resume");
        }
        public void resume(Context arg0) {
            Call("resume", arg0);
        }
        public void setData(string arg0) {
            Call("setData", arg0);
        }
        public void setUserId(string arg0) {
            Call("setUserId", arg0);
        }
        public bool isLoaded() {
            return Call<bool>("isLoaded");
        }
        public void loadAd(AdParam arg0, RewardAdLoadListener arg1) {
            Call("loadAd", arg0, arg1);
        }
        public void loadAd(string arg0, AdParam arg1) {
            Call("loadAd", arg0, arg1);
        }
        public void setRewardAdListener(RewardAdListener arg0) {
            Call("setRewardAdListener", arg0);
        }
        public void setRewardVerifyConfig(RewardVerifyConfig arg0) {
            Call("setRewardVerifyConfig", arg0);
        }
        public void show(Activity arg0, RewardAdStatusListener arg1) {
            Call("show", arg0, arg1);
        }
        public void show() {
            Call("show");
        }
        public void show(Activity arg0, RewardAdStatusListener arg1, bool arg2) {
            Call("show", arg0, arg1, arg2);
        }
    }
}