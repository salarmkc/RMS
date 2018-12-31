using System;

namespace ApplicationCore.Abstract
{
    public abstract class BaseEntity
    {
     public  virtual int Id { get; set; }
        public virtual int UserId { get; set; }
        public virtual ushort Status { get; set; }
        public virtual DateTime ModDateTime { get; set; }
        public virtual int ModByUserId { get; set; }
        public virtual string Comment { get; set; }
    }
}
