using System.Windows.Forms;
namespace InternetExplorerExtension
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string InputText
        {
            get { return this.textBox1.Text; }
            set { this.textBox1.Text = value; }
        }
    }
}