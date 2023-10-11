using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tflpro.Browser;

namespace tflpro.Drivers
{

    public class Page
    {


        public WebBrowser WebBrowser { get; set; }

        public Page(WebBrowser webBrowser)
        {
            WebBrowser = webBrowser;
        }
    }
}



