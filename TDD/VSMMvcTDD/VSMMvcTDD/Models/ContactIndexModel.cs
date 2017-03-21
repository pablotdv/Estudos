using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Grid.Mvc.Ajax.GridExtensions;

namespace VSMMvcTDD.Models
{
    public class ContactIndexModel
    {
        public AjaxGrid<ContactViewModel> Contacts { get; set; }
    }
}