using HuaweiService;
using HuaweiService.CloudDB;
using UnityEngine;

namespace HuaweiServiceDemo {
	public class BookInfo_Data : IHmsBaseClass {
		public string name => "com.huawei.agc.clouddb.quickstart.model.BookInfo";
	}
	public class BookInfo : HmsClass<BookInfo_Data>, IDatabaseModel {
		private int _id;
		private string _bookName;
		private string _author;
		private double _price;
		private string _publisher;
		private Date _publishTime;
		private bool _shadowFlag = true;
		public BookInfo () : base () { }
		public int Id {
			get { return Call<int> ("getId");}
			set { Call ("setId" , new Integer(value)); }
		}
		public string BookName {
			get { return Call<string> ("getBookName");}
			set { Call ("setBookName" , value); }
		}
		public string Author {
			get { return Call<string> ("getAuthor");}
			set { Call ("setAuthor" , value); }
		}
		public double Price {
			get { return Call<double> ("getPrice");}
			set { Call ("setPrice" , new Double(value)); }
		}
		public string Publisher {
			get { return Call<string> ("getPublisher");}
			set { Call ("setPublisher" , value); }
		}
		public Date PublishTime {
			get { return Call<Date> ("getPublishTime");}
			set { Call ("setPublishTime" , value); }
		}
		public bool ShadowFlag {
			get { return Call<bool> ("getShadowFlag");}
			set { Call ("setShadowFlag" , new Boolean(value)); }
		}
		public AndroidJavaObject GetObj() {
			return obj;
		}
		public void SetObj(AndroidJavaObject obj) {
			this.obj = obj;
		}
		public string getObjectTypeName() {
			return Call<string>("getObjectTypeName");
		}
		public string getPackageName() {
			return Call<string>("getPackageName");
		}
	}
}
