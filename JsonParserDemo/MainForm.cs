using Newtonsoft.Json;
using Spire.Pdf.Graphics;
using Spire.PdfViewer.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonParserDemo
{
    public partial class MainForm : Form
    {
        public SaleInfo saleInfo { get; set; }
        public Step01 step01Data { get; set; }
        public Step02 step02Data { get; set; }
        public Step03 step03 { get; set; }
        public BKSingature bKSingature { get; set; }
        public string pdf { get; set; }
        public JsonResult jsonResult { get; private set; }

        public MainForm()
        {
            InitializeComponent();
        }


        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            var function = CbFunction.SelectedItem;
            if (CbFunction.SelectedItem != null)
            {
                switch (function)
                {
                    case "Post":
                        GetDataWithPost();
                        break;
                    default:
                        GetDataWithFile();
                        break;
                }

               //btnParserJson_Click(sender,e);
            }
            else
            {
                MessageBox.Show("請先選擇檔案來源");
            }

        }


        private void btnParserJson_Click(object sender, EventArgs e)
        {
            var data = jsonResult.JsonResultData;
            if (String.IsNullOrEmpty(data))
            {
                MessageBox.Show("匯入無資料，請再確認");
            }
            else
            {
                //data = AdjustData(data);
                var json = JsonConvert.DeserializeObject<List<KeyValue>>(data);
                tabControl1.Controls.Clear();
                foreach (var item in json)
                {
                    try
                    {
                        Type type = FindTypeFromAssembly(item);

                        var tabPage = new TabPage();
                        tabPage.SuspendLayout();
                        tabPage.Text = item._key;

                        if (type != null)
                        {
                            tabPage = StringToDataGridView(tabPage, type, item);
                        }
                        else if (item._key == "PDF")
                        {
                            tabPage = StringToBase64PDFView(tabPage, item);
                        }
                        else
                        {
                            tabPage = StringToView(tabPage, item);
                        }


                        tabControl1.Controls.Add(tabPage);

                    }
                    catch (Exception ex)
                    {
                            Console.WriteLine(ex.Message);
                    }
                }
            }

        }

        private static Type FindTypeFromAssembly(KeyValue item)
        {
            var directory = new DirectoryInfo(Directory.GetCurrentDirectory());
            var files = directory.GetFiles("*Model.dll");
            Type type = null;

            //先載入在執行目錄下的dll檔取出Type
            foreach(var file in files)
            {
                var assembly = Assembly.LoadFile(file.FullName);
                type = assembly.GetTypes().FirstOrDefault(x => string.Equals(x.Name, item._key, StringComparison.OrdinalIgnoreCase));
            }

            //如果dll檔中沒有相對應的dll檔，預設從JsonParserDemo取出Type
            if (type == null)
            {
                Assembly assembly = Assembly.Load("JsonParserDemo");
                type = assembly.GetTypes().FirstOrDefault(x => string.Equals(x.Name, item._key, StringComparison.OrdinalIgnoreCase));
            }
            return type;
        }

        private TabPage StringToView(TabPage tabPage, KeyValue item)
        {
            var textbox = new TextBox();
            textbox.Multiline = true;
            textbox.Size = new System.Drawing.Size(824, 335);
            textbox.Text = item._value;
            tabPage.Controls.Add(textbox);
            tabPage.Text = item._key;
            return tabPage;
        }

        private TabPage StringToBase64PDFView(TabPage tabPage, KeyValue item)
        {
            pdf = item._value;
            MemoryStream ms = new MemoryStream(Convert.FromBase64String(pdf));
            var pdfViewer = new PdfDocumentViewer();

            pdfViewer.LoadFromStream(ms);

            pdfViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            pdfViewer.AutoScroll = true;
            pdfViewer.PageLayoutMode = Spire.PdfViewer.Forms.PageLayoutMode.SinglePageContinuous;
            pdfViewer.Size = new System.Drawing.Size(824, 335);
            pdfViewer.ViewerMode = Spire.PdfViewer.Forms.PdfViewerMode.PdfViewerMode.MultiPage;
            pdfViewer.ZoomFactor = 1F;
            pdfViewer.ZoomMode = Spire.PdfViewer.Forms.ZoomMode.Default;

            tabPage.Controls.Add(pdfViewer);

            return tabPage;
        }

        private static TabPage StringToDataGridView(TabPage tabPage,Type type, KeyValue item)
        {

            var jsondata = JsonConvert.DeserializeObject(item._value, type);
            var bgs = new BindingSource();
            bgs.DataSource = jsondata;
            var dgv = new DataGridView();
            dgv.Size = new System.Drawing.Size(824, 335);
            tabPage.Controls.Add(dgv);

            dgv.DataSource = bgs;

            return tabPage;
        }

        private void GetDataWithFile()
        {
            string file = TbFile.Text;
            string fileContent = File.ReadAllText(file);
            jsonResult = JsonConvert.DeserializeObject<JsonResult>(fileContent);

            MessageBox.Show("已取完成");
           // MessageBox.Show(fileContent);
        }

        private void GetDataWithPost()
        {
            var userAgent = "JUSTIN";
            var uri = TbFile.Text;
            var data = TbPostData.Text;// "{\"orderserial\":\"SCSB2009218xgxWnZ454\"}";// tb_data.Text;
            var contentType = "Application/JSON";
            if (String.IsNullOrEmpty(uri))
            {
                MessageBox.Show("請先輸入要Post的Uri");
            } else if (String.IsNullOrEmpty(uri))
            {
                MessageBox.Show("請先輸入要Post的Uri");
            }
            else
            {
                WebClient webClient = new WebClient();
                try
                {
                    webClient.Headers[HttpRequestHeader.ContentType] = contentType;
                    webClient.Headers[HttpRequestHeader.UserAgent] = userAgent;
                    webClient.Encoding = Encoding.UTF8;
                    string response = webClient.UploadString(uri, data);
                    jsonResult = JsonConvert.DeserializeObject<JsonResult>(response);
                    Console.WriteLine(response);
                    MessageBox.Show("已取完成");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


        }

        private static string AdjustData(string data)
        {
            data = data.Replace("_key:", "\"_key\":\"");
            data = data.Replace(",_value:", "\",\"_value\":\"");
            data = data.Replace("\\\\\\/", "\\").Replace("\\\\/\\", "\\");
            data = data.Replace("\\\\\\", "\\\"");
            data = data.Replace("\\", "\\\"");
            data = data.Replace("},{", "\"},{");
            data = data.Replace("}]", "\"}]");
            return data;
        }

        private void CbFunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            var function = CbFunction.SelectedItem;
            switch (function)
            {
                case "File":
                    OpenFileDialog file = new OpenFileDialog();
                    file.ShowDialog();
                    this.TbFile.Text = file.FileName;
                    TbPostData.Enabled = false;
                    break;
                case "Post":
                    TbPostData.Enabled = true;
                    break;
                default:
                    break;
            }
        }
    }

    public class KeyValue
    {
        public string _key { get; set; }
        public string _value { get; set; }
    }

    public class JsonResult
    {
        public string JsonStatus { get; set; }
        public string JsonResultData { get; set; }
        public string JsonMsg { get; set; }
        public string Token { get; set; }
    }

    public class SaleInfo
    {
        public string SalesNo { get; set; }
        public string SalesUID { get; set; }
        public string SalesName { get; set; }
        public string SalesUnit { get; set; }
        public string SalesID { get; set; }
        public string SalesUnitName { get; set; }
        public string AOType { get; set; }
        public string SalesCanSaleA { get; set; }
    }

    public class Step01
    {
        public string CASE_SN { get; set; }
        public string inscompany { get; set; }
        public string packagecode { get; set; }
        public string policyperiod { get; set; }
        public string effectdate { get; set; }
        public string county { get; set; }
        public string district { get; set; }
        public string zipcode { get; set; }
        public string BLD_ADDR { get; set; }
        public string iscarpublic { get; set; }
        public string BLD_FLS { get; set; }
        public string BLDMATE_CD { get; set; }
        public string BLDROOFMATE_CD { get; set; }
        public string BLD_AREA { get; set; }
        public string BLD_DT { get; set; }
        public string fireamt { get; set; }
        public string totalprem { get; set; }
        public string loanbank { get; set; }
        public string loanbranch { get; set; }
        public string buynextyear { get; set; }
        public List<string> paymethod { get; set; }
        public string PremiumAccount { get; set; }
        public string SalesBrancdID { get; set; }
        public string SaleCode { get; set; }
        public List<string> memoflag { get; set; }
        public string CUSTOMERPOS { get; set; }
        public string fireprem { get; set; }
        public string quakeamt { get; set; }
        public string quakeprem { get; set; }
        public string IMPSEQ { get; set; }
        public string APPLICATIONDATE { get; set; }
        public string LicenceNo_Prod { get; set; }
        public string SalesName { get; set; }
        public string branchname { get; set; }
        public string insprinturl { get; set; }
        public string fulladdress { get; set; }
        public string newbuy { get; set; }
        public string constructionclasscode { get; set; }
        public string constructionclass { get; set; }
    }

    public class Step02
    {
        public string ownerid { get; set; }
        public string ownername { get; set; }
        public string ownerbirthday { get; set; }
        public string Representative { get; set; }
        public string RepresentativeID { get; set; }
        public string RepresentativeBD { get; set; }
        public string mobilephone { get; set; }
        public string homephone { get; set; }
        public string occupation_class { get; set; }
        public string occupation_classother { get; set; }
        public string jobtitle { get; set; }
        public string county { get; set; }
        public string district { get; set; }
        public string zipcode { get; set; }
        public string address { get; set; }
        public string ownernational { get; set; }
        public string ownertype { get; set; }
        public string ownergender { get; set; }
        public string owneridtype { get; set; }
        public string Representativenational { get; set; }
        public string RepresentativeIDtype { get; set; }
        public string owneraddressnational { get; set; }
        public string fulladdress { get; set; }
    }

    public class Step03
    {
        public string relationship { get; set; }
        public string insid { get; set; }
        public string insname { get; set; }
        public string insbirthday { get; set; }
        public string insnational { get; set; }
        public string instype { get; set; }
        public string insgender { get; set; }
        public string insidtype { get; set; }
        public string orderserial { get; set; }
        public string firebkpolicyserial { get; set; }
        public string quakebkpolicyserial { get; set; }
    }

    public class BKSingature
    {
        public int iden { get; set; }
        public string SignStatus { get; set; }
        public string BKPolicySerial { get; set; }
        public string SignId { get; set; }
        public string SignName { get; set; }
        public string SignDate { get; set; }
        public string SignIP { get; set; }
        public string SignKey { get; set; }
    }

}
