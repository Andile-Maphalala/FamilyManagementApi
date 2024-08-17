using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyManagment.Domain.Common
{
    public interface KeyedEntity<TKey> where TKey : struct, IEquatable<TKey>
    {
        public TKey Id { get; set; }
    }
}
