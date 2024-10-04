using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeRestorant.Models.Entities
{
    public abstract class BaseEntity
    {
        public string Isim { get; set; }
        public decimal Fiyat { get; set; }

        // Her üründe isim fiyat var

        public override string ToString()
        {
            return $"{Isim} {Fiyat:C2}";
        }

    }
}
