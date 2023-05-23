using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS.Domain.Helpers.v1;

namespace CQRS.Domain.ValuesObjects.v1
{
    public record Document
    {
        public Document(string value)
        {
            Value = value.RemoveMaskCpf();
        }
        public string Value { get; set; }
    }

}
