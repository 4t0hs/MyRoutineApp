using System.IO;
using System.Text.Json.Nodes;
using System.Windows;

namespace MyRoutineApp.Application {
	internal partial class ConfigurationManager {

		public delegate void WindowLoadedEventHandler(Window window);

		public event WindowLoadedEventHandler? OnWindowLoaded;

		private readonly static string PATH = @"S:\Visual Studio\01_コンソールアプリ\StartupApp\StartupApp\test\config.json";

		private readonly JsonParser _parser;

		public ConfigurationManager() {
			try {
				JsonNode root = JsonNode.Parse(ReadJson(PATH)) ?? throw new Exception("Configuration file parse failed.");
				_parser = new JsonParser(root);
			} catch (Exception ex) {
				throw new Exception(ex.Message);
			}
		}
		public bool TryGetConfiguration(string key, out Configuration? config) {
			config = null;
			try {
				config = GetConfiguration(key);
				return true;
			} catch {
				return false;
			}
		}

		public Configuration GetConfiguration(string key) {
			return new Configuration(_parser.GetObject(key));
		}

		public void NotifySettingWindowLoaded(object s, RoutedEventArgs e) {
			Window? window = s as Window;
			if (window != null) {
				OnWindowLoaded?.Invoke(window);
			}
		}

		private static string ReadJson(string path) {
			try {
				return File.ReadAllText(path);
			} catch (Exception e) {
				throw new Exception(e.Message);
			}
		}
	}
	internal partial class ConfigurationManager {
		private class JsonParser(JsonNode root) {

			private readonly JsonNode _root = root;

			public JsonObject GetObject(string path) {
				string[] keys = path.Split('.');

				for (int i = 0; i < keys.Length; i++) {
					JsonNode node = GetNode(keys[i]);
					if ((i + 1) == keys.Length) {
						return node.AsObject();
					} else {
						return new JsonParser(node).GetObject(ExcludeTopKey(path));
					}
				}
				throw new ArgumentException();
			}

			private static string ExcludeTopKey(string path) {
				string[] keys = path.Split(".").Skip(1).ToArray();
				return string.Join(".", keys);
			}

			private JsonNode GetNode(string key) {
				return (_root[key] ?? throw new KeyNotFoundException());
			}
		}
	}

}
