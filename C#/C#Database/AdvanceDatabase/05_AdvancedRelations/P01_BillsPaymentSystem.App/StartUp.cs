using P01_BillsPaymentSystem.Data;
using System;

namespace P01_BillsPaymentSystem
{
    public class Program
    {
        public static void Main()
        {
			var db = new BillsPaymentSystemContext();

			using (db)
			{
				db.Database.EnsureDeleted();

				db.Database.EnsureCreated();
			}
        }
    }
}
