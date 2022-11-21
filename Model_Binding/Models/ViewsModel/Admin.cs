using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace Model_Binding.Models.ViewsModel
{
    public class Admin
    {
        //[BindNever]
        public string isimsoyisim { get; set; } 

       
        public Admin()
        {
            this.isimsoyisim = "Oğuzcan Kandemir";
        }
    }
  
    

}
