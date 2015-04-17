using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchronicWorldDAL
{
    class SynchronicWorldInitializer : DropCreateDatabaseIfModelChanges<SynchronicWorldContext>
    {
        public override void InitializeDatabase(SynchronicWorldContext context)
        {
            base.InitializeDatabase(context);
        }

        protected override void Seed(SynchronicWorldContext context)
        {
            base.Seed(context);
        }

    }
}
