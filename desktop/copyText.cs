using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desktop
{
    public partial class copyText : RichTextBox
    {
        public copyText()
        {
            InitializeComponent();
        }

        public copyText(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
