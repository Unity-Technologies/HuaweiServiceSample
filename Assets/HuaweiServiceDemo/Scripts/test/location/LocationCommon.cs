using HuaweiService;
namespace HuaweiServiceDemo{
    public class LocationCommon{
        public const string ACTION_PROCESS_LOCATION = "com.huawei.hms.location.ACTION_PROCESS_LOCATION";
        public static PendingIntent mPendingIntent = null;
        private static void setPermission(string[] s,int arg){
            Context ctx = new Context();
            int PMPG = AndroidUtil.GetPMPermissionGranted();
            bool needSet = false;
            for(int i=0;i<s.Length;i++){
                if(ActivityCompat.checkSelfPermission(ctx,s[i]) != PMPG){
                    needSet = true;
                    break;
                }
            }
            if(needSet){
                ActivityCompat.requestPermissions(ctx,s,arg);
            }
        }
        public static void SetPermission(string[] s1,string[] s2){
            if(AndroidUtil.GetAndroidVersion() <= AndroidUtil.GetAndroidVersionCodeP()){
                setPermission(s1,1);
            }else{
                setPermission(s2,2);
            }
        }
        public static PendingIntent GetPendingIntent(){
            if(mPendingIntent != null){
                return mPendingIntent;
            }
            Context ctx = new Context();
            Intent intent = new Intent(ctx,BroadcastRegister.CreateLocationReceiver(new LocationBroadcast()));
            intent.setAction(ACTION_PROCESS_LOCATION);
            mPendingIntent = PendingIntent.getBroadcast(ctx,0,intent,PendingIntent.FLAG_UPDATE_CURRENT);
            return mPendingIntent;
        }
    }
}