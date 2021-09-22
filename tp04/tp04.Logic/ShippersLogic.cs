using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp04.Entities;

namespace tp04.Logic
{

    public class ShippersLogic : BaseLogic, IABMLogic<Shippers>
    {
        public List<Shippers> GetAll()
        {
            return context.Shippers.ToList();
        }

        public void Add(Shippers newShipper)
        {
            context.Shippers.Add(newShipper);
            context.SaveChanges();
        }

        public void Update(Shippers shipper)
        {
                var shippersToUpdate = context.Shippers.Find(shipper.ShipperID);

                shippersToUpdate.CompanyName = shipper.CompanyName;
                shippersToUpdate.Phone = shipper.Phone;


                context.SaveChanges();
        }

        public void Delete(int id)
        {
            var shipperToDelete = context.Shippers.Find(id);

            context.Shippers.Remove(shipperToDelete);

            context.SaveChanges();
        }



    }
}
