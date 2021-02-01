using HuaweiService;
using HuaweiService.CloudDB;
namespace HuaweiServiceDemo {
	public class ObjectTypeInfoHelper_Data : IHmsBaseClass {
		public string name => "com.huawei.agc.clouddb.quickstart.model.ObjectTypeInfoHelper";
	}
	public class ObjectTypeInfoHelper : HmsClass<ObjectTypeInfoHelper_Data> {
		public ObjectTypeInfoHelper () : base () { }
		public static ObjectTypeInfo getObjectTypeInfo() {
		return CallStatic<ObjectTypeInfo>("getObjectTypeInfo");
		}
	}
}
