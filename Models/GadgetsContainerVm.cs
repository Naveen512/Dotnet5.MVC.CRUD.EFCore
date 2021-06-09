using System.Collections.Generic;
using Dotnet5.MVC.CRUD.EF.Data.Entities;

namespace Dotnet5.MVC.CRUD.EF.Models
{
    public class GadgetsContainerVm
    {
        public List<Gadgets> AllGadgets { get; set; }
    }
}