using ApplicationCore.Abstract;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class BranchContact:BaseContact
    {
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
    }
}
