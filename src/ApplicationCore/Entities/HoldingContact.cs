using ApplicationCore.Abstract;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class HoldingContact: BaseContact
    {
        public int HoldingId { get; set; }
        public Holding Holding { get; set; }
    }
}
