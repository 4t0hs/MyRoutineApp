using Windows.Data.Xml.Dom;

namespace MyRoutineApp.Application.Notification {
	internal partial class WindowsNotification {
		private class NotificationComponent(XmlDocument doc) {

			private XmlDocument _doc = doc;

			public XmlElement CreateTitle(string title) {
				XmlElement element = CreateElement("text");
				element.SetAttribute("id", "1");
				element.InnerText = title;
				return element;
			}

			public XmlElement CreateBody(string text) {
				XmlElement element = CreateElement("text");
				element.SetAttribute("id", "2");
				element.InnerText = text;
				return element;
			}

			public XmlElement CreateImage(string src) {
				XmlElement image = CreateElement("image");
				image.SetAttribute("src", src);
				image.SetAttribute("id", "1");
				return image;
			}

			private XmlElement CreateElement(string name) {
				return _doc.CreateElement(name);
			}
		}
		public class NotificationContent {

			public XmlDocument document = new XmlDocument();

			private readonly NotificationComponent _component;

			public NotificationContent() {
				document.LoadXml(Template);
				_component = new NotificationComponent(document);
			}

			public void AddTitle(string title) {
				AddBindingChild(_component.CreateTitle(title));
			}

			public void AddBody(params string[] messages) {
				string text = string.Join(Environment.NewLine, messages);
				AddBindingChild(_component.CreateBody(text));
			}

			public void AddImage(string src) {
				AddBindingChild(_component.CreateImage(src));
			}

			private void AddBindingChild(XmlElement childElement) {
				GetBinding().AppendChild(childElement);
			}

			private XmlElement GetBinding() {
				return GetElementFirst("binding");
			}

			private XmlElement GetElementFirst(string name) {
				XmlElement element = document.GetElementsByTagName(name).First() as XmlElement
					?? throw new NullReferenceException();
				return element;
			}

			private static string Template {
				get {
					return @"
							<toast>
								<visual>
									<binding template='ToastImageAndText02'>
										<text></text>
									</binding>
								</visual>
							</toast>";
				}
			}
		}
	}
}
