using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;

namespace Review_Project.MVVM.Model
{
    public class XmlPostGenerator
    {
        private string _filePathXML;

        private XmlDocument _xmlDoc;

        private XmlElement _root;
      
        public XmlDocument XmlDocument
        { 
            get { return _xmlDoc; } 
        }

        public XmlElement Contents
        {
            get { return _root; }
        }

        public XmlPostGenerator(string filePath)
        {
            _filePathXML = filePath;

            // Create root element
            _xmlDoc = new XmlDocument();
            _root = _xmlDoc.CreateElement("Contents");
            _xmlDoc.AppendChild(_root);
            SavePostFileXML();
        }

        public XmlPostGenerator(string filePath, bool isRender)
        {
            _filePathXML = filePath;
        }


        public bool WritePostFileXML(PostContent postContent)
        {
            try
            {
                _xmlDoc.Load(_filePathXML);

                XmlNode root = _xmlDoc.SelectSingleNode("Contents");
                XmlElement content = _xmlDoc.CreateElement("Content");
                XmlElement tilte = _xmlDoc.CreateElement("Title");
                tilte.InnerText = postContent.Title;
                content.AppendChild(tilte);
                foreach (Block block in postContent.Content.Blocks)
                {
                    if (block is Paragraph paragraph)
                    {
                        
                        XmlElement lineParagraph = _xmlDoc.CreateElement("Paragraph");
                        XmlElement p = _xmlDoc.CreateElement("p");
                        bool isNewLine = false;
                        foreach (Inline inline in paragraph.Inlines)
                        {

                            if(inline is LineBreak)
                            {

                                if (p.ChildNodes.Count > 0)
                                {
                                    lineParagraph.AppendChild(p);
                                    p = _xmlDoc.CreateElement("p");
                                }
                                isNewLine = true;
                                continue;
                            }


                            if (inline is Run run)
                            {
                                XmlElement fontInline = _xmlDoc.CreateElement("inline");
                                if (run.FontWeight == FontWeights.Bold)
                                {
                                    XmlAttribute bold = _xmlDoc.CreateAttribute("FontWeight");
                                    bold.Value = "Bold";
                                    fontInline.Attributes.Append(bold);
                                }
                                if (run.FontStyle == FontStyles.Italic)
                                {
                                    XmlAttribute italic = _xmlDoc.CreateAttribute("FontStyle");
                                    italic.Value = "Italic";
                                    fontInline.Attributes.Append(italic);
                                }
                                if (run.TextDecorations == TextDecorations.Underline)
                                {
                                    XmlAttribute underLine = _xmlDoc.CreateAttribute("FontDecorate");
                                    underLine.Value = "Underline";
                                    fontInline.Attributes.Append(underLine);
                                }
                                fontInline.InnerText = run.Text;
                                p.AppendChild(fontInline);

                            }
                            else if (inline is InlineUIContainer uiContainer && uiContainer.Child is Image)
                            {
                                XmlElement img = _xmlDoc.CreateElement("img");
                                Image image = (Image)uiContainer.Child;
                                string imageUrl = image.Source.ToString();
                                img.SetAttribute("src", imageUrl);

                                lineParagraph.AppendChild(img);
                            }
                        }

                        if (p.ChildNodes.Count > 0)
                        {
                            lineParagraph.AppendChild(p);
                        }

                        if (lineParagraph.ChildNodes.Count > 0)
                        {
                            content.AppendChild(lineParagraph);
                        }

                    }   
                }

                root.AppendChild(content);

                SavePostFileXML();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }


        public static void CreateUIFromXMLFile(XmlNode nodeXML, Panel panelUI)
        {
            if(nodeXML == null)
            {
                return;
            }

            foreach (XmlNode childNodeXML in nodeXML.ChildNodes)
            {
                if(childNodeXML.Name == "Title")
                {
                    TextBlock textContent = new TextBlock();
                    textContent.FontWeight = FontWeights.SemiBold;
                    textContent.FontSize = 23;
                    textContent.Foreground = Brushes.White;
                    textContent.Text = childNodeXML.InnerText;
                    panelUI.Children.Add(textContent);
                    continue;
                }
                else if(childNodeXML.Name == "p")
                {
                    TextBlock textContent = new TextBlock();
                    textContent.TextWrapping = TextWrapping.Wrap;
                    textContent.Foreground = Brushes.White;
                    textContent.FontSize= 20;

                    foreach (XmlNode nodeInline in childNodeXML.ChildNodes)
                    {
                        Run runText = new Run();
                        
                        foreach (XmlAttribute attribute in nodeInline.Attributes)
                        {
                            if (attribute.Name == "FontWeight")
                            {
                                runText.FontWeight = FontWeights.SemiBold;
                            }
                            if (attribute.Name == "FontStyle")
                            {
                                if (attribute.Value == "Italic")
                                {
                                    runText.FontStyle = FontStyles.Italic;
                                }
                            }
                            if (attribute.Name == "FontDecorate")
                            {
                                if (attribute.Value == "Underline")
                                {
                                    runText.TextDecorations = TextDecorations.Underline;
                                }
                            }
                        }
                        runText.FontSize = 16;
                        runText.Text = nodeInline.InnerText;
                        textContent.Inlines.Add(runText);
                    }
                    panelUI.Children.Add(textContent);
                }
                else if(childNodeXML.Name == "img")
                {
                    Image imageContent = new Image();
                    imageContent.Source = new BitmapImage(new Uri(childNodeXML.Attributes.GetNamedItem("src").Value));
                    imageContent.Width = 500;
                    imageContent.Height = 500;
                    panelUI.Children.Add(imageContent);
                }
                else
                {
                    StackPanel panel = new StackPanel();
                    CreateUIFromXMLFile(childNodeXML, panel);
                    panelUI.Children.Add(panel);
                }
            }
        }


        public bool SavePostFileXML()
        {
            try
            {
                _xmlDoc.Save(_filePathXML);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
