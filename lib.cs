using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Net.Sockets;
using System.Net;

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
		// 获得本机局域网IP地址  
		public static string[] getIPAddress() {
			IPHostEntry he = Dns.GetHostEntry(Dns.GetHostName());
			List<String> ips = new List<String>();
			for (int i = 0; i < he.AddressList.Length;i++ ) {
				ips.Add(he.AddressList[i].ToString());
			}
			return ips.ToArray();
		}
		public static ushort getValidPort(string port) {
			ushort iPort = 0xFFFF;
			UInt16.TryParse(port, out iPort);
			return iPort;
		}

		public static IPAddress getValidIP(string ip) {
			IPAddress lip = null;
			//测试IP是否有效  
			try {
				//是否为空  
				if (!IPAddress.TryParse(ip, out lip)) {
					return null;
				}
			} catch (Exception e) {
				//ArgumentException,   
				//FormatException,   
				//OverflowException  
				return null;
			}
			return lip;
		}
	}
}
