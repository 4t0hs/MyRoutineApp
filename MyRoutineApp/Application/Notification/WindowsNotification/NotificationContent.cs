using Windows.Data.Xml.Dom;

namespace MyRoutineApp.Application.Notification {
	internal partial class WindowsNotification {
		private class ComponentBuilder {
			private XmlDocument _doc;
			public ComponentBuilder(XmlDocument doc) {
				_doc = doc;
			}
			public XmlElement createTitle(string title) {
				XmlElement element = createElement("text");
				element.SetAttribute("id", "1");
				element.InnerText = title;
				return element;
			}
			public XmlElement createBody(string text) {
				XmlElement element = createElement("text");
				element.SetAttribute("id", "2");
				element.InnerText = text;
				return element;
			}
			public XmlElement createImage(string src) {
				XmlElement image = createElement("image");
				image.SetAttribute("src", src);
				image.SetAttribute("id", "1");
				return image;
			}
			private XmlElement createElement(string name) {
				return _doc.CreateElement(name);
			}
		}
		public class NotificationContent {
			public XmlDocument document = new XmlDocument();
			private ComponentBuilder _componentBuilder;
			public NotificationContent() {
				initialize();
			}
			public NotificationContent(string title) {
				initialize();

				addTitle(title);
			}
			public NotificationContent(string title, params string[] messages) {
				initialize();

				addTitle(title);
				addBody(messages);
			}
			public NotificationContent(string title, string imagePath, params string[] messages) {
				initialize();

				addTitle(title);
				addBody(messages);
				addImage(imagePath);
			}
			private void initialize() {
				document.LoadXml(template);
				_componentBuilder = new ComponentBuilder(document);
			}
			public void addTitle(string title) {
				addBindingChild(_componentBuilder.createTitle(title));
			}
			public void addBody(params string[] messages) {
				string text = string.Join(Environment.NewLine, messages);
				addBindingChild(_componentBuilder.createBody(text));
			}
			public void addImage(string src) {
				addBindingChild(_componentBuilder.createImage(src));
			}
			private void addBindingChild(XmlElement childElement) {
				getBinding().AppendChild(childElement);
			}
			private XmlElement getBinding() {
				return getElementFirst("binding");
			}
			private XmlElement getElementFirst(string name) {
				XmlElement element = document.GetElementsByTagName(name).First() as XmlElement ?? throw new NullReferenceException();
				return element;
			}
			private string template {
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
