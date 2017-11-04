using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Diagnostics;

namespace SocketSerialTools {
	[Serializable]
	class Config {
		public List<string> serial_baud_rate = new List<String>();
		public string select_serial_port = "",file_name = "";
		public int select_baud_rate = 115200;
		public string send_encode = "ascii", recv_encode = "ascii";
		public bool use_escape = false;
		public Config() {
			string rates = "9600,19200,38400,43000,56000,57600,115200";
			string[] rl = rates.Split(',');
			for (int i = 0; i < rl.Length; i++) {
				serial_baud_rate.Add(rl[i]);
			}
		}
		public override string ToString() {
			JsonSerializerSettings settings = new JsonSerializerSettings();
			settings.Formatting = Formatting.Indented;
			return JsonConvert.SerializeObject(this, settings);
		}
		public static Config FromString(string json,string name) {
			DataContractJsonSerializer deseralizer = new DataContractJsonSerializer(typeof(Config));
			try {
				using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json))) {
					Config cfg = (Config)deseralizer.ReadObject(ms);
					cfg.file_name = name;
					return cfg;
				}
			}catch(Exception e){
				Debug.Print(e.Message);
			} finally {
			}
			return null;
		}
		public static Config Load(string name = "") {
			if (name == "") {
				name = ".cfg";
			}
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
				return FromString(js,name);
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
				fs = new FileStream(path, FileMode.Create,FileAccess.Write);
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
