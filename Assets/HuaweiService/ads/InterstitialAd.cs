using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.ads
{
    public class InterstitialAd_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.ads.InterstitialAd";
    }
    public class InterstitialAd :HmsClass<InterstitialAd_Data>
    {
        public InterstitialAd (Context arg0): base(arg0) { }
        public InterstitialAd (): base() { }
        public string getAdId() {
            return Call<string>("getAdId");
        }
        public AdListener getAdListener() {
            return Call<AdListener>("getAdListener");
        }
        public bool isLoaded() {
            return Call<bool>("isLoaded");
        }
        public bool isLoading() {
            return Call<bool>("isLoading");
        }
        public void loadAd(AdParam arg0) {
            Call("loadAd", arg0);
        }
        public void setAdId(string arg0) {
            Call("setAdId", arg0);
        }
        public void setAdListener(AdListener arg0) {
            Call("setAdListener", arg0);
        }
        public void show() {
            Call("show");
        }
    }
}