    namespace Packt.CS7 
    { 
      public class User 
      { 
        public string Name { get; set; } 
        public string Salt { get; set; } 
        public string SaltedHashedPassword { get; set; } 
        public string[] Roles { get; set; }
      } 
    }