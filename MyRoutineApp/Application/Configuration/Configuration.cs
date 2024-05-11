using System.Text.Json.Nodes;

namespace MyRoutineApp.Application {
	internal class Configuration {

		private readonly JsonObject _elements;

		public Configuration(JsonObject jsonObject) {
			_elements = jsonObject;
		}
		public T Get<T>(string key) {
			JsonNode node = _elements[key] ?? throw new KeyNotFoundException(key);
			return node.GetValue<T>();
		}
		public T Get<T>(string key, T defaultValue) {
			JsonNode? node = _elements[key];
			if (node == null) {
				return defaultValue;
			}
			return node.AsObject().GetValue<T>();
		}
		public List<T> GetList<T>(string key) {
			JsonNode node = _elements[key] ?? throw new KeyNotFoundException(key);
			List<T> list = new List<T>();

			foreach (var value in node.AsArray()) {
				if (value != null) {
					list.Add(value.GetValue<T>());
				}
			}
			return list;
		}
		public List<T> GetList<T>(string key, List<T> defaultList) {
			try {
				return GetList<T>(key);
			} catch {
				return defaultList;
			}
		}
		public T[] GetArray<T>(string key) {
			return GetList<T>(key).ToArray();
		}
		public T[] GetArray<T>(string key, T[] defaultArray) {
			try {
				return GetArray<T>(key);
			} catch {
				return defaultArray;
			}
		}

		public Configuration GetChild(string key) {
			JsonNode node = _elements[key] ?? throw new KeyNotFoundException();
			return new Configuration(node.AsObject());
		}
	}

}
