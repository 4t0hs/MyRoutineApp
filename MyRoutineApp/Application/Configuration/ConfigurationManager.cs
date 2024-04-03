using System.IO;
using System.Text.Json.Nodes;

namespace MyRoutineApp.Application {
	internal partial class ConfigurationManager {
		private readonly static string PATH = @"S:\Visual Studio\01_コンソールアプリ\StartupApp\StartupApp\test\config.json";
		private readonly JsonParser _parser;
		public ConfigurationManager() {
			try {
				JsonNode root = JsonNode.Parse(readJson(PATH)) ?? throw new Exception("Configuration file parse failed.");
				_parser = new JsonParser(root);
			} catch (Exception ex) {
				throw new Exception(ex.Message);
			}
		}
		public Configuration getConfiguration(string key) {
			return new Configuration(_parser.getObject(key));
		}
		public bool tryGetConfiguration(string key, out Configuration? config) {
			config = null;
			try {
				config = getConfiguration(key);
				return true;
			} catch {
				return false;
			}
		}
		private string readJson(string path) {
			try {
				return File.ReadAllText(path);
			} catch (Exception e) {
				throw new Exception(e.Message);
			}
		}
	}
	internal partial class ConfigurationManager {
		private class JsonParser {
			private readonly JsonNode _root;
			public JsonParser(JsonNode root) {
				_root = root;
			}
			public JsonObject getObject(string path) {
				string[] keys = path.Split('.');

				for (int i = 0; i < keys.Length; i++) {
					JsonNode node = getNode(keys[i]);
					if ((i + 1) == keys.Length) {
						return node.AsObject();
					} else {
						return new JsonParser(node).getObject(excludeTopKey(path));
					}
				}
				throw new ArgumentException();
			}
			private string excludeTopKey(string path) {
				string[] keys = path.Split(".").Skip(1).ToArray();
				return string.Join(".", keys);
			}
			private JsonNode getNode(string key) {
				return (_root[key] ?? throw new KeyNotFoundException());
			}
		}
	}

}
