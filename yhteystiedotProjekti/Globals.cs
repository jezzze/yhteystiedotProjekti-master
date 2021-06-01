using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yhteystiedotProjekti
{
    class Globals
    {

        // tämää class tekee sen kirjautuneen käyttäjän globaaliksi kaikkialla tässä sovelluksessa
        public static int GlobalkayttajaId { get; private set; }

        public static void setGlobalkayttajaId(int kayttajaId)
        {
            GlobalkayttajaId = kayttajaId;
        }

    }
}
