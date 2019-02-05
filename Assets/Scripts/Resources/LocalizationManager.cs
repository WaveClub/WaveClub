using System.Xml;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager {
	public string LanguageCode { get; set; }

	private static LocalizationManager instance;
	public static LocalizationManager Instance {
		get {
			if (instance == null)
				instance = new LocalizationManager ();
			return instance;
		}
	}

	public static Dictionary<string, string> getConfig(string xpath) {
		XmlDocument doc = new XmlDocument ();
		Dictionary<string, string> result = new Dictionary<string, string> ();

		var file = LocalizationManager.Instance.LoadResource();
		doc.LoadXml (file.text);

        XmlElement root = doc.DocumentElement;
        foreach (XmlNode node in root.SelectNodes(xpath)) {
            foreach (XmlNode child in node.ChildNodes) {
                result.Add(child.Name, child.InnerText);
            }
        }
		return result;
	}

	private TextAsset LoadResource() {
		return Resources.Load (LanguageCode, typeof(TextAsset)) as TextAsset;
	}

	private LocalizationManager() {
		if (LanguageCode == null)
			LanguageCode = "RU";
	}
}
