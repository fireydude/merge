using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Certainty.Merge
{
    public partial class Main : Form
    {
        string _resultCompare;

        public Main()
        {
            InitializeComponent();
            var sr = File.OpenText(@"C:\_src2\CertaintyMerge\CertaintyMerge\RouteConfig.cs");
            var contentString = sr.ReadToEnd();

            var compares = new List<Compare>();

            _resultCompare = string.Empty;
            Compare compare;
            string remaining;
            while (Compare.GetNext(contentString, out compare, out remaining))
            {
                compares.Add(compare);
                contentString = remaining;
                _resultCompare += string.Format(@"{0}{1}{2}{3}{4}", compare.PrefixText, compare.C1Title, compare.C1Content, compare.C2Title, compare.C2Content);
            }
            _resultCompare += contentString;

            label1.Text = _resultCompare;
        }
    }
}
