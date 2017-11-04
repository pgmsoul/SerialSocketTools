using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace SocketSerialTools {
	[Serializable]
	class SendDataStruct {
		public string hash, name, data, encode;
		public SendDataStruct() {
			hash = "";
			name = "";
			data = "";
			encode = "ascii";
		}
		public SendDataStruct(string hash, string name, string data, string encode) {
			this.hash = hash;
			this.name = name;
			this.data = data;
			this.encode = encode;
		}
	}
	[Serializable]
	class SendDataStorage {
		public List<SendDataStruct> dataList = new List<SendDataStruct>();
		public string file_name;
		public override string ToString() {
			JsonSerializerSettings settings = new JsonSerializerSettings();
			settings.Formatting = Formatting.Indented;
			return JsonConvert.SerializeObject(this, settings);
		}
		public int IndexOf(string hash) {
			for (int i = 0; i < dataList.Count; i++) {
				SendDataStruct sd = dataList[i];
				if (sd.hash == hash)
					return i;
			}
			return -1;
		}
		public static SendDataStorage FromString(string json, string name) {
			DataContractJsonSerializer deseralizer = new DataContractJsonSerializer(typeof(SendDataStorage));
			try {
				using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json))) {
					SendDataStorage st = (SendDataStorage)deseralizer.ReadObject(ms);
					st.file_name = name;
					return st;
				}
			} catch {
			} finally {
			}
			return null;
		}
		public static SendDataStorage Load(string name = "") {
			if (name == "")
				name = ".jd";
			string folder = ".\\conf\\";
			Directory.CreateDirectory(folder);
			string path = folder + name;
			FileStream fs = null;
			try {
				fs = new FileStream(path, FileMode.Open);
				//防止文件太大（16M）
				if (fs.Length > 0x1000000) {
					fs.Close();
					return null;
				}
				byte[] data = new byte[fs.Length];
				fs.Seek(0, SeekOrigin.Begin);
				fs.Read(data, 0, data.Length);
				string js = System.Text.Encoding.UTF8.GetString(data);
				fs.Close();
				return FromString(js, name);
			} catch (IOException e) {
				Console.WriteLine(e.ToString());
			}
			return null;
		}
		public void Save() {
			string folder = ".\\conf\\";
			Directory.CreateDirectory(folder);
			string path = folder + file_name;
			FileStream fs = null;
			try {
				fs = new FileStream(path, FileMode.Create, FileAccess.Write);
				string str = this.ToString();
				byte[] data = System.Text.Encoding.UTF8.GetBytes(str);
				fs.Write(data, 0, data.Length);
				fs.Close();
			} catch {
				if (fs != null)
					fs.Close();
			} finally {
			}
		}
	}
}
