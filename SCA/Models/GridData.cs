using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCA.Models
{
    /// <summary>
    /// Для превю гріда
    /// </summary>
    public class GridData
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }
        
    }
    /// <summary>
    /// Для превю верхніх кнопок гріда
    /// </summary>
    public class GridTopMenu
    {
        public bool Export { get; set; }

        public bool Insert { get; set; }

        public bool Tags { get; set; }

        public GridTopMenu()
        {
            Export = true;
            Insert = true;
            Tags = true;
        }
    }
}