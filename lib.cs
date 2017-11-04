using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace SocketSerialTools {
	public class lib {
		public static string getFileName(string path) {
			if(path==null) return "";
			int pos = path.LastIndexOf("\\");
			return path.Substring(pos+1);
		}
		[Serializable]
		class Json {
			public string Value = null;
		}
		/// <summary>
		/// 分析转义序列字符串
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string getEscapeString(string str) {
			str = "{\"Value\":\"" + str + "\"}";
			DataContractJsonSerializer deseralizer = new DataContractJsonSerializer(typeof(Json));
			try {
				using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(str))) {
					Json cfg = (Json)deseralizer.ReadObject(ms);
					return cfg.Value;
				}
			} catch {
			} finally {
			}
			return null;
		}
	}
}
