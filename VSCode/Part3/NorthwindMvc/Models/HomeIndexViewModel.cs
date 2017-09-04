    using System.Collections.Generic; 

    namespace Packt.CS7 
    { 
      public class HomeIndexViewModel 
      { 
        public int VisitorCount; 
        public IList<Category> Categories { get; set; } 
        public IList<Product> Products { get; set; } 
      } 
    } 