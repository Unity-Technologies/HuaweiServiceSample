using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class TimeUnit_Data : IHmsBaseClass{
        public string name => "java.util.concurrent.TimeUnit";
    }
    public class TimeUnit :HmsClass<TimeUnit_Data>
    {
        public static TimeUnit NANOSECONDS => HmsUtil.GetStaticValue<TimeUnit>("NANOSECONDS");
    
        public static TimeUnit MICROSECONDS => HmsUtil.GetStaticValue<TimeUnit>("MICROSECONDS");
    
        public static TimeUnit MILLISECONDS => HmsUtil.GetStaticValue<TimeUnit>("MILLISECONDS");
    
        public static TimeUnit SECONDS => HmsUtil.GetStaticValue<TimeUnit>("SECONDS");
    
        public static TimeUnit MINUTES => HmsUtil.GetStaticValue<TimeUnit>("MINUTES");
    
        public static TimeUnit HOURS => HmsUtil.GetStaticValue<TimeUnit>("HOURS");
    
        public static TimeUnit DAYS => HmsUtil.GetStaticValue<TimeUnit>("DAYS");
    
        public TimeUnit (): base() { }
    }
}