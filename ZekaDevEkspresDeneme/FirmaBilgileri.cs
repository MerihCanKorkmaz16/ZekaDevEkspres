using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZekaDevEkspresDeneme
{
    public class FirmaBilgileri
    {
        DateTime teklifverilentarih;
        string firmaisim;
        decimal firmafiyat;
       

        public DateTime Teklifverilentarih
        {
            get
            {
                return teklifverilentarih;
            }

            set
            {
                teklifverilentarih = value;
            }
        }

        public string Firmaisim
        {
            get
            {
                return firmaisim;
            }

            set
            {
                firmaisim = value;
            }
        }

        public decimal Firmafiyat
        {
            get
            {
                return firmafiyat;
            }

            set
            {
                firmafiyat = value;
            }
        }

        
    }
}
