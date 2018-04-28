using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
public class DateManager : MonoBehaviour {
    private static DateManager _instance;
    //XmlAttribute xmla;
    public XmlDocument DateSource;
    public XmlElement date;
    public XmlElement date1;
    public XmlNode node1;
    string m_XmlName = "/Configs/config.xml";
    string m_XmlPath;
    public Dictionary<string, string> ClothConfig = new Dictionary<string, string>();
    private void Awake()
    {
        _instance = this;
        m_XmlPath = Application.dataPath + m_XmlName;
        if (!File.Exists(m_XmlPath))
        {
            DateSource = new XmlDocument();
            date = DateSource.CreateElement("Cloth");
            DateSource.AppendChild(date);
            XmlElement elment = DateSource.CreateElement("Sex");
            elment.InnerText = "0";
            date.AppendChild(elment);
            /*
                                                {"eyes","1"},
                                                {"hair","1" },
                                                { "top","1"},
                                                { "pants","1"},
                                                { "shoes","1"},
                                                {"face",
             */
            elment = DateSource.CreateElement("eyes");
            elment.InnerText = "1";
            date.AppendChild(elment);
            elment = DateSource.CreateElement("hair");
            elment.InnerText = "1";
            date.AppendChild(elment);
            elment = DateSource.CreateElement("top");
            elment.InnerText = "1";
            date.AppendChild(elment);
            elment = DateSource.CreateElement("pants");
            elment.InnerText = "1";
            date.AppendChild(elment);
            elment = DateSource.CreateElement("shoes");
            elment.InnerText = "1";
            date.AppendChild(elment);
            elment = DateSource.CreateElement("face");
            elment.InnerText = "1";
            date.AppendChild(elment);
            DateSource.Save(m_XmlPath);
        }
        else
        {
            DateSource = new XmlDocument();
            DateSource.Load(m_XmlPath);
        }
        initdate();
        //changenode("Sex/Attribute","Boy");
    }
    private void initdate()
    {
        XmlNodeList nodes = DateSource.SelectSingleNode("Cloth").ChildNodes;
        foreach(XmlElement ele in nodes)
        {
            ClothConfig.Add(ele.Name,ele.InnerText);
        }
        int i = 1;
    }
    public void changenode(string nodename,string nodevalue)
    {
        node1 = DateSource.SelectSingleNode(nodename);
        node1.InnerText = nodevalue;
        DateSource.Save(m_XmlPath);
    }
    public static DateManager GetInstance()
    {
        return _instance;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SaveCloth()
    {
        /*
                                                {"eyes","1"},
                                                {"hair","1" },
                                                { "top","1"},
                                                { "pants","1"},
                                                { "shoes","1"},
                                                {"face",
             */
        changenode("Cloth/eyes",AvatarSys.getInstance().getClothConfig("eyes"));
        changenode("Cloth/hair", AvatarSys.getInstance().getClothConfig("hair"));
        changenode("Cloth/top", AvatarSys.getInstance().getClothConfig("top"));
        changenode("Cloth/pants", AvatarSys.getInstance().getClothConfig("pants"));
        changenode("Cloth/shoes", AvatarSys.getInstance().getClothConfig("shoes"));
        changenode("Cloth/face", AvatarSys.getInstance().getClothConfig("face"));
    }
}
