using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class DataApi<T>
    {
        public List<T> teams { get; set; }
        public T team { get; set; }

    }
}
