using System.Windows.Forms;

namespace UI
{
    public partial class MemberManager : Form
    {

        public MemberManager()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        } 
        
        private void MemberManager_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
