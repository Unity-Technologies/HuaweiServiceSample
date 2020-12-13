using UnityEngine;
using System.Collections.Generic;
namespace HuaweiService.CloudFunction
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
        public long convert(long arg0, TimeUnit arg1) {
            return Call<long>("convert", arg0, arg1);
        }
        public void sleep(long arg0) {
            Call("sleep", arg0);
        }
        public void timedWait(AndroidJavaObject arg0, long arg1) {
            Call("timedWait", arg0, arg1);
        }
        public long toDays(long arg0) {
            return Call<long>("toDays", arg0);
        }
        public long toHours(long arg0) {
            return Call<long>("toHours", arg0);
        }
        public long toMicros(long arg0) {
            return Call<long>("toMicros", arg0);
        }
        public long toMillis(long arg0) {
            return Call<long>("toMillis", arg0);
        }
        public long toMinutes(long arg0) {
            return Call<long>("toMinutes", arg0);
        }
        public long toNanos(long arg0) {
            return Call<long>("toNanos", arg0);
        }
        public long toSeconds(long arg0) {
            return Call<long>("toSeconds", arg0);
        }
        public static TimeUnit valueOf(string arg0) {
            return CallStatic<TimeUnit>("valueOf", arg0);
        }
        public static TimeUnit[] values() {
            return CallStatic<TimeUnit[]>("values");
        }
    }
}