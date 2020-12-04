using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.ads
{
    public class Reward_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.ads.reward.Reward";
    }
    public class Reward :HmsClass<Reward_Data>
    {
        public Reward (): base() { }
        public string getName() {
            return Call<string>("getName");
        }
        public int getAmount() {
            return Call<int>("getAmount");
        }
    }
}