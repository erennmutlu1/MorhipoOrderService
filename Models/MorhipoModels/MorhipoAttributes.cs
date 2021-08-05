using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorhipoOrderService.Models.MorhipoModels
{
    public class MorhipoAttributesModel
    {
        [Key]
        public long Id { get; set; }
        public string name { get; set; }
        public string value { get; set; }

    }
}
