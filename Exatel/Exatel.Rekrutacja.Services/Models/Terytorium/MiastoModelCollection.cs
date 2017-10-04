using System;




namespace Exatel.Models.Terytorium
{
    public class MiastoModelCollection : System.Collections.Generic.List<MiastoModel>
    {
        public MiastoModelCollection()
        {
        }




        public MiastoModelCollection(System.Collections.Generic.IEnumerable<MiastoModel> list):base(list)
        {
        }
    }
}
